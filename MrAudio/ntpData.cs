using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * NinjaForce NinjaTracker+ File Format
 *
 GOALs:
+ new file format
++ allow up to 31 MOD instruments (or more)
++ add stopper bytes to instruments where needed
++ pre-split instruments
++ pre-shift instruments
++ store sound ram positions of instruments
+ allow 5 octaves
+ store output channel (2x4ensoniq cards)
+ allow 1-15 channels (instead of always 14 for soundsmith)
+ store only the tracks that are needed
+ add all Protracker effects (except filter and maybe sample offset)
+ add missing e-effects except 0 and F (not really possible)
+ fix frequency problems
+ when instruments have the right size (256,512,1024,...) use free run for loops, no interrupts

-------------------------

header:
+ 4 bytes: identifier "nfc!"
+ 1 byte: version (currently 0)
+ 1 byte: number of tracks (1-15)
+ 1 byte: number of instruments (1-255)
+ 1 byte: number of patterns (1-255)
+ 1 byte: length of pattern order (1-255)

track data:
+ 1 byte: output channel for every track
          0= Front left
          1= Front right
          2= Surround left
          3= Surround right
          4= Front height left
          5= Front height right
          6= Surround back left
          7= Surround back right

instrument data:
+ 1 byte: type, consisting of bits %00000xyy
          with x:
          0= random size
          1= size matches an ideal size (256, 512, 1024, ...)
          with yy:
          0= not looped
          1= looped (entire instrument is one loop)
          2= loop header (the next instrument is of type 3)
          3= the loop
+ 2 bytes: length in bytes, GS style big endian first, not Amiga
+ 1 byte: volume (0-64)
+ 1 byte: finetune value (-8...7)
+ 1 byte: position in doc ram (page number)
+ 1 byte: wavelen/wavesize, the doc register

pattern order:
+ n bytes: list of pattern numbers

pattern data:
+ 4 bytes x number_of_tracks x 64 lines per pattern x number of patterns
++ 1 byte note (0-255)
++ 1 byte sample (0-255)
++ 1 byte effect (0-15)
++ 1 byte effect parameter (0-255)

sample data:1
+ n bytes, use length from instrument data
+ the sample data includes the stopper bytes if needed and is shifted to be doc usable
 */

namespace MrAudio
{
    public class ntpInstrument
    {
        public byte  m_type=0;
        public UInt16 m_length=0;
        public byte  m_volume=0;
        public byte  m_fineTune=0;
        public byte  m_address=0; // byte address in doc ram
        public byte  m_wavelen=0; // wavelen/wavesiz, the doc register

        public List<byte> m_waveData = new List<byte>();
    }
    public class ntpData
    {
        byte m_version=0xFF;         // Currently 0
        byte m_numTracks=0;        // 1-15
        byte m_numInstruments=0;   // 1-255
        byte m_numPatterns=0;      // 1-255
        byte m_numPatternOrder=0;  // 1-255 (or song length, in patterns)

        List<byte> m_trackData = new List<byte>();      // output channel for each track
        List<ntpInstrument> m_instruments = new List<ntpInstrument>();
        List<byte> m_patternOrder = new List<byte>();
        List<UInt32> m_patternData = new List<UInt32>();

        public byte GetVersion()
        {
            return m_version;
        }

        public ref List<ntpInstrument> GetInstruments()
        {
            return ref m_instruments;
        }

        public ntpData(string pathName)
        {
            using (BinaryReader b = new BinaryReader(
                File.Open(pathName, FileMode.Open)))
            {
                // Use BaseStream.
                long length = b.BaseStream.Length;
                UInt32 header = b.ReadUInt32();

                // ntp!
                if (0x2163666E == header)
                {
                    // Go For Reading, version byte will indicate success or not
                    // so we will delay writing this out
                    byte version = b.ReadByte();

                    if (0 != version) return;  // just exit, because not supported

                    m_numTracks = b.ReadByte();
                    m_numInstruments = b.ReadByte();
                    m_numPatterns = b.ReadByte();
                    m_numPatternOrder =b.ReadByte();

                    // Load in Track Channel Data
                    for (int idx = 0; idx < m_numTracks;++idx)
                        m_trackData.Add(b.ReadByte());

                    // Load in Instrument Data
                    for (int idx = 0; idx < m_numInstruments;++idx)
                    {
                        ntpInstrument inst = new ntpInstrument();

                        inst.m_type     = b.ReadByte();
                        inst.m_length   = b.ReadUInt16();
                        inst.m_volume   = b.ReadByte();
                        inst.m_fineTune = b.ReadByte();
                        inst.m_address  = b.ReadByte();
                        inst.m_wavelen  = b.ReadByte();
                        m_instruments.Add(inst);
                    }

                    // Load in the pattern play order
                    for (int idx = 0; idx < m_numPatternOrder; ++idx)
                        m_patternOrder.Add(b.ReadByte());

                    // Load in the Pattern Data itself
                    int numNotes = m_numTracks * m_numPatterns * 64;
                    for (int idx = 0; idx < numNotes; ++idx)
                        m_patternData.Add(b.ReadUInt32());

                    // Load in the wave data for each instrument
                    for (int idx = 0; idx < m_instruments.Count; ++idx)
                    {
                        ntpInstrument inst = m_instruments[idx];

                        for (int widx = 0; widx < inst.m_length; ++widx)
                            inst.m_waveData.Add(b.ReadByte());

                    }

                    m_version = version; // signal the load was good

                }
            }
        }
    }
}
