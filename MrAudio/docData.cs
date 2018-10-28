﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace MrAudio
{
    public class docData
    {
        public int m_index = 0;
        public string m_name = "<none>";
        public string m_path = "<none>";
        public int m_freq = 0;
        public int m_size = 0;
        public int m_address = -1; // byte address in doc ram
        public List<byte> m_waveData = new List<byte>();
        public bool m_pinned = false;   // meaning it can't move

        public WaveStream ToWaveStream()
        {
            WaveStream result = null;

            string pathName = m_path;
            string ext = Path.GetExtension(pathName).ToLower();

            switch (ext)
            {
                case ".raw":
                    break;
                case ".aif":
                case ".aiff":
                    {
                        AiffFileReader wfr = new AiffFileReader(pathName);
                        return wfr;
                        //result = wfr.ToSampleProvider() as WaveStream;
                        //wfr.Dispose();
                    }
                    break;
                case ".mp3":
                    {
                        Mp3FileReader wfr = new Mp3FileReader(pathName);
                        return wfr;

                        //result = wfr.ToSampleProvider() as WaveStream;
                        //wfr.Dispose();
                    }
                    break;
                case ".wav":
                    {
                        WaveFileReader wfr = new WaveFileReader(pathName);
                        return wfr;

                        //result = wfr.ToSampleProvider() as WaveStream;
                        //wfr.Dispose();
                    }
                    break;
                case ".ntp":
                    {
                        var ms = new MemoryStream(m_waveData.ToArray());
                        var rs = new RawSourceWaveStream(ms, new WaveFormat(m_freq, 8, 1));
                        return rs;
                    }
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
