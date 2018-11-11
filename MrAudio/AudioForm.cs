﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using WaveFormRendererLib;

namespace MrAudio
{
    public partial class MrAudio : Form
    {
        public List<docData> docFiles = new List<docData>();
        docData m_dd = null;

        private bool m_checkupdate = false;

        private readonly WaveFormRenderer waveFormRenderer;
        private readonly WaveFormRendererSettings standardSettings;

        void MakeRuler(ref PictureBox pb)
        {
            Bitmap bmp = new Bitmap(1024, 32);

            int ySize = 128;
            int xStep = 512;

            while (ySize > 0)
            {
                int scaledY = (ySize / 4) + (ySize*4/4);
                if (scaledY > 32) scaledY = 32;
                if (scaledY < 1) scaledY = 1;
                for (int x = 0; x < 1024; x+=xStep)
                {
                    for (int y = (32-scaledY); y < 32; ++y)
                    {
                        bmp.SetPixel(x, y, Color.Black);
                    }
                }
                ySize >>= 1;
                xStep >>= 1;
            }

            pb.ClientSize = new Size(1024, 32);
            //pb.Scale(new SizeF(1.0f, 0.5f));
            pb.Image = bmp;
        }

        public MrAudio()
        {
            InitializeComponent();

            MakeRuler(ref pictureBoxGuide);

            this.Font = SystemFonts.DefaultFont; // DPI Awareness Ju Ju

            waveFormRenderer = new WaveFormRenderer();
            standardSettings = new StandardWaveFormRendererSettings() { Name = "Standard" };

            this.address.AspectToStringConverter = delegate (object x)
            {
                int addr = (int)x;

                if (addr >= 0)
                {
                    return String.Format("${0:X2}00", addr);
                }
                else
                {
                    return "<NONE>";
                }
            };
            // Default to Resampling to Rate
            resampleBox.SelectedIndex = 0;
            resampleBox.SelectedIndexChanged += new System.EventHandler(OnResampleTypeChanged);

            this.fastObjectListView1.SetObjects(docFiles);

            this.fastObjectListView1.SelectionChanged += new System.EventHandler(OnWaveSelectionChanged);

            comboBoxPlayRate.TextChanged += new System.EventHandler(comboBoxPlayRate_TextChanged);
           
        }

        private void comboBoxPlayRate_TextChanged(object sender, System.EventArgs e)
        {
#if false
            Int32 playRate = 0;

            if (Int32.TryParse(comboBoxPlayRate.Text, out playRate))
            {
                if (null != m_dd)
                {
                    m_dd.m_freq = playRate;
                    this.fastObjectListView1.SetObjects(docFiles);
                }
            }
#endif
        }

        //
        // User choosed to resample by rate, or by size
        //
        private void OnResampleTypeChanged(object sender, System.EventArgs e)
        {
            switch (resampleBox.SelectedIndex)
            {
                case 0:
                    // Frequency
                    comboBoxResampleRate.Items.Clear();
                    this.comboBoxResampleRate.Items.AddRange(new object[] {
                        "26000","22050",
                        "11025","5500","2500"});
                    break;
                case 1:
                    // Size
                    comboBoxResampleRate.Items.Clear();
                    this.comboBoxResampleRate.Items.AddRange(new object[] {
                        "32768","16384","8192",
                        "4096","2048","1024",
                        "512","256"
                    });
                    break;
            }
            comboBoxResampleRate.SelectedIndex = 1;
        }

        private void OnWaveSelectionChanged(object sender, System.EventArgs e)
        {
            //int selectedIndex = fastObjectListView1.SelectedIndex;

            m_dd = fastObjectListView1.SelectedObject as docData;

            labelName.Text = "";
            labelPath.Text = "";

            PaintMemory();

            //if ((selectedIndex >= 0)&&(selectedIndex < docFiles.Count))
            if (null != m_dd)
            {
                docData dd = m_dd;

                labelName.Text = dd.m_name;
                labelPath.Text = String.Format("{0}, {1} hz, {2} bytes", dd.m_path, dd.m_imFreq, dd.m_imSize);

                m_checkupdate = true;
                checkPinned.Checked = dd.m_pinned;
                m_checkupdate = false;
                comboBoxPlayRate.Text = String.Format("{0}",dd.m_freq);

                RenderWaveform();
#if false
                if (null != waveViewer.WaveStream)
                {
                    //waveViewer.WaveStream.Dispose();
                    //waveViewer.WaveStream = null;
                }

                WaveStream ws = m_dd.ToWaveStream();
                waveViewer.WaveStream = ws;
                if (null != ws)
                {
                    long estSamples = (long)(ws.TotalTime.TotalSeconds * ws.WaveFormat.SampleRate);
                    int spp = (int)(estSamples / waveViewer.Width);

                    waveViewer.SamplesPerPixel = Math.Max(spp, 32);
                }
#endif
            }
        }

        private void RenderWaveform()
        {
            pictureBoxWave.Image = null;
            if (null != m_dd)
            {
                Enabled = false;
                var settings = standardSettings;
                settings.Width = pictureBoxWave.Width;
                if (pictureBoxWave.Width > m_dd.m_size)
                {
                    settings.Width = m_dd.m_size;
                }
                settings.TopHeight = pictureBoxWave.Height / 2;
                settings.BottomHeight = pictureBoxWave.Height / 2;
                var peakProvider = new MaxPeakProvider();
                Task.Factory.StartNew(() => RenderThreadFunc(peakProvider, settings));
            }
        }

        private void RenderThreadFunc(IPeakProvider peakProvider, WaveFormRendererSettings settings)
        {
            Image image = null;
            try
            {
                string wavePath = m_dd.m_path;

                if (m_dd.m_waveData.Count() > 0)
                {
                    var s = m_dd.ToWaveStream();
                    var outpath = "temp.example.wav";
                    WaveFileWriter.CreateWaveFile(outpath, s);
                    wavePath = outpath;
                }
                image = waveFormRenderer.Render(wavePath, peakProvider, settings);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            BeginInvoke((Action)(() => FinishedRender(image)));
        }

        private void FinishedRender(Image image)
        {
            pictureBoxWave.Image = image;
            Enabled = true;
        }

        void importAudio(string pathName)
        {
            string ext = Path.GetExtension(pathName).ToLower();

            switch (ext)
            {
                case ".raw":
                    {
                        MediaFoundationReader mfr = new MediaFoundationReader(pathName);
                        
                        docData dd = new docData();
                        dd.m_name = Path.GetFileNameWithoutExtension(pathName);
                        dd.m_path = pathName;
                        dd.m_freq = mfr.WaveFormat.SampleRate;
                        dd.m_index = docFiles.Count;
                        dd.m_size = (int)0;
                        dd.m_imSize = dd.m_size;
                        dd.m_imFreq = dd.m_freq;
                        docFiles.Add(dd);
                        mfr.Dispose();
                    }
                    break;
                case ".aif":
                case ".aiff":
                    {
                        AiffFileReader wfr = new AiffFileReader(pathName);

                        docData dd = new docData();

                        dd.m_name = Path.GetFileNameWithoutExtension(pathName);
                        dd.m_path = pathName;
                        dd.m_freq = wfr.WaveFormat.SampleRate;
                        dd.m_index = docFiles.Count;
                        dd.m_size = (int)wfr.SampleCount;
                        dd.m_imSize = dd.m_size;
                        dd.m_imFreq = dd.m_freq;
                        docFiles.Add(dd);
                        wfr.Dispose();
                    }
                    break;
                case ".mp3":
                    {
                        int SampleCount = 0;
                        Mp3FileReader wfr = new Mp3FileReader(pathName);

                        Mp3Frame mp3Frame = wfr.ReadNextFrame();

                        while (mp3Frame != null)
                        {
                            SampleCount += mp3Frame.SampleCount;
                            mp3Frame = wfr.ReadNextFrame();
                        }

                        //ISampleProvider sp = wfr.ToSampleProvider();

                        docData dd = new docData();

                        dd.m_name = Path.GetFileNameWithoutExtension(pathName);
                        dd.m_path = pathName;
                        dd.m_freq = wfr.Mp3WaveFormat.SampleRate;
                        dd.m_index = docFiles.Count;
                        dd.m_size = SampleCount;
                        dd.m_imSize = dd.m_size;
                        dd.m_imFreq = dd.m_freq;
                        docFiles.Add(dd);
                        wfr.Dispose();
                    }
                    break;
                case ".wav":
                    {
                        //using (WaveFileReader reader = new WaveFileReader(pathName))
                        //{
                        //    reader.WaveFormat.
                        //    byte[] buffer = new byte[reader.Length];
                        //    int read = reader.Read(buffer, 0, buffer.Length);
                        //   short[] sampleBuffer = new short[read / 2];
                        //   Buffer.BlockCopy(buffer, 0, sampleBuffer, 0, read);
                        //}
                        WaveFileReader wfr = new WaveFileReader(pathName);

                        docData dd = new docData();

                        dd.m_name = Path.GetFileNameWithoutExtension(pathName);
                        dd.m_path = pathName;
                        dd.m_freq = wfr.WaveFormat.SampleRate;
                        dd.m_index = docFiles.Count;
                        dd.m_size = (int)wfr.SampleCount;
                        dd.m_imSize = dd.m_size;
                        dd.m_imFreq = dd.m_freq;
                        docFiles.Add(dd);
                        wfr.Dispose();
                    }
                    break;
                case ".ntp":
                    {
                        ntpData ninjaSong = new ntpData(pathName);

                        if (0==ninjaSong.GetVersion())
                        {
                            // It successfully loaded
                            // reserve some space for the instruments
                            List<ntpInstrument> instruments = ninjaSong.GetInstruments();

                            for (int idx = 0; idx < instruments.Count; ++idx)
                            {
                                ntpInstrument inst = instruments[idx];

                                docData dd = new docData();
                                dd.m_name = String.Format("{0}.{1}", Path.GetFileNameWithoutExtension(pathName), idx);
                                dd.m_path = pathName;
                                dd.m_freq = 10000; //$$JGA todo, take into account tuning
                                dd.m_index = docFiles.Count;
                                dd.m_size = inst.m_length;
                                dd.m_imSize = dd.m_size;
                                dd.m_imFreq = dd.m_freq;
                                dd.m_pinned = true;
                                dd.m_address = inst.m_address;
                                dd.m_waveData = inst.m_waveData;
                                docFiles.Add(dd);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            // Force the List View to Refresh
            this.fastObjectListView1.SetObjects(docFiles);

        }

        private void importAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = importAudioDialog.ShowDialog();
            if (DialogResult.OK == result)
            {
                for (int idx = 0; idx < importAudioDialog.FileNames.Length; ++idx)
                {
                    importAudio(importAudioDialog.FileNames[idx]);
                }
            }
        }

        private void checkPinned_CheckedChanged(object sender, EventArgs e)
        {
            if (null != m_dd && !m_checkupdate)
            {
                m_dd.m_pinned = !m_dd.m_pinned;
            }
        }

        private void comboBoxPlayRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void memoryMapBox_Enter(object sender, EventArgs e)
        {

        }

        //
        // Resample a WaveStream into another WaveStream
        // at a different resampling rate
        //
        private WaveStream ToFreq(WaveStream ws, int freq)
        {
            // Start at the beginning
            ws.Position = 0;

            if (freq == ws.WaveFormat.SampleRate)
                return ws;
            //-----------------------------------
            var outFormat = new WaveFormat(freq, 1);
            var resampler = new MediaFoundationResampler(ws, outFormat);
            resampler.ResamplerQuality = 60;

            //-----------------------------------
            ISampleProvider sp = resampler.ToSampleProvider();

            long numSamples = ws.Length * freq / ws.WaveFormat.SampleRate;

            float[] samples = new float[numSamples];

            int len = sp.Read(samples, 0, (int)numSamples);

            //short[] shortSamples = new short[len];
            byte[] buffer = new byte[len * 2];

            for (int idx = 0; idx < len; ++idx)
            {
                short sample = (short)(samples[idx] * 32768);
                int bidx = idx * 2;
                buffer[bidx + 0] = (byte)(sample & 0xFF);
                buffer[bidx + 1] = (byte)(sample >> 8);
            }

            var ms = new MemoryStream(buffer);
            var rs = new RawSourceWaveStream(ms, new WaveFormat(freq, 16, 1));
            return rs;
        }

        //
        // WaveStream to Byte Array
        //
        private byte[] ToByteArray(WaveStream ws)
        {
            ws.Position = 0;
            
            ISampleProvider sp = ws.ToSampleProvider();
            sp = sp.ToMono();

            long numSamples = ws.Length;

            float[] samples = new float[numSamples];

            int len = sp.Read(samples, 0, (int)numSamples);

            byte[] buffer = new byte[len];

            for (int idx = 0; idx < len; ++idx)
            {
                byte sample = (byte)(samples[idx] * 256);
                buffer[idx] = sample;
            }

            ws.Dispose();

            return buffer;
        }

        //
        // WaveStream to float Array
        //
        private float[] ToFloatArray(WaveStream ws)
        {
            ISampleProvider sp = ws.ToSampleProvider();
            sp = sp.ToMono();

            long numSamples = ws.Length;

            float[] samples = new float[numSamples];

            int len = sp.Read(samples, 0, (int)numSamples);

            float[] buffer = new float[len];

            for (int idx = 0; idx < len; ++idx)
            {
                buffer[idx] = samples[idx];
            }

            return buffer;
        }

        //
        // Convert a WaveStream, into another WaveStream
        // at a different Frequency
        // (Jump through hoops just to change the play rate, Ugh!)
        //
        private WaveStream AtFreq(WaveStream ws, int freq)
        {
            if (freq == ws.WaveFormat.SampleRate)
                return ws;

            ISampleProvider sp = ws.ToSampleProvider();
            sp = sp.ToMono();

            long numSamples = ws.Length;

            float[] samples = new float[numSamples];

            int len = sp.Read(samples, 0, (int)numSamples);

            //short[] shortSamples = new short[len];
            byte[] buffer = new byte[len * 2];

            for (int idx = 0; idx < len; ++idx)
            {
                short sample = (short)(samples[idx] * 32768);
                int bidx = idx * 2;
                buffer[bidx + 0] = (byte)(sample & 0xFF);
                buffer[bidx + 1] = (byte)(sample >> 8);
            }

            var ms = new MemoryStream(buffer);
            var rs = new RawSourceWaveStream(ms, new WaveFormat(freq, 16, 1));
            return rs;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (null != m_dd)
            {
                Int32 playRate = 0;

                if (!Int32.TryParse(comboBoxPlayRate.Text, out playRate))
                {
                    return;
                }

                WaveStream ws = m_dd.ToWaveStream();

                // Resample
                ws = ToFreq(ws, m_dd.m_freq);

                // Retune
                ws = AtFreq(ws, playRate);

                var wo = new WaveOutEvent();
                wo.NumberOfBuffers = 3;
                wo.Volume = 1.0f;
                wo.Init(ws);
                wo.Play();
                while (wo.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(100);
                }
                wo.Dispose();
                ws.Dispose();
            }

        }

        int docAlloc(ref int[] allocMap, int sizePages)
        {
            int addr = -1;
            int[] StepSizes = { 1,2,4,8,16,32,64,128,256 };
            int step = 1;

            // The Wave Size determines legal locations in RAM
            if (sizePages <= 256)
            {
               // Find Step
               for (int idx = 0; idx < StepSizes.Length; ++idx)
               {
                    step = StepSizes[idx];
                    if (StepSizes[idx] >= sizePages)
                        break;
               }

                // Search for a location
                for (int ca = 0; ca < 256; ca += step)
                {
                    // Test This address
                    int start = ca;
                    int end = ca + sizePages;
                    bool bFail = false;
                    for (int idx = start; idx < end; ++idx)
                    {
                        if (allocMap[idx] >= 0)
                        {
                            bFail = true;
                            break;
                        }
                    }
                    if (!bFail)
                    {
                        addr = start;
                        break;
                    }
                }
            }

            return addr;
        }

        //
        //  Attempt to Allocate all the wave data into the DOC
        //
        private void buttonRealloc_Click(object sender, EventArgs e)
        {
            int[] allocMap = new int[256];

            // -1 will indicate un-allocated
            for (int idx = 0; idx < allocMap.Length; ++idx)
            {
                allocMap[idx] = -1;
            }

            // Reserve Memory used by pinned waves
            foreach(docData dd in docFiles)
            {
                if (dd.m_pinned && (dd.m_address >= 0))
                {
                    int id = dd.m_index;
                    int length = (dd.m_size+255) / 256;
                    int endAddr = dd.m_address + length;

                    for (int addr = dd.m_address; addr <= endAddr; ++addr)
                    {
                        allocMap[addr] = id;
                    }
                }
                else
                {
                    dd.m_address = -1; // unallocated
                }
            }

            // Sort the unallocated Audio Objects by size
            List<docData> SortedList = docFiles.OrderByDescending(o => o.m_size).ToList();

            foreach(docData dd in SortedList)
            {
                if (!dd.m_pinned && (dd.m_address < 0))
                {
                    dd.m_address = docAlloc(ref allocMap, (dd.m_size + 255) / 256);

                    if (dd.m_address >= 0)
                    {
                        int id = dd.m_index;
                        int length = (dd.m_size + 255) / 256;
                        int endAddr = dd.m_address + length;

                        for (int addr = dd.m_address; addr < endAddr; ++addr)
                        {
                            allocMap[addr] = id;
                        }
                    }
                }
            }
            this.fastObjectListView1.SetObjects(docFiles);

            PaintMemory();
        }

        private void FillRect(ref Bitmap bmp, int x, int y, int w, int h, Color c)
        {
            for (int ypos = y; ypos < (y+h); ++ypos)
            {
                for(int xpos = x; xpos < (x+w); ++xpos)
                {
                    bmp.SetPixel(xpos, ypos, c);
                }
            }
        }
        /// <summary>
        ///  Plot the DocFiles List into the memory map window
        /// </summary>
        private void PaintMemory()
        {
            // Sort the unallocated Audio Objects by address
            List<docData> SortedList = docFiles.OrderBy(o => o.m_address).ToList();

            Bitmap bmp = new Bitmap(1024, 32);

            int idx = 0;

            foreach(docData dd in SortedList)
            {
                if (dd.m_address >= 0)
                {
                    if (dd.m_pinned)
                    {
                        Color fill = Color.DarkSlateBlue;
                        if (1 == (idx & 1))
                            fill = Color.DarkRed;

                        int x = dd.m_address * 4;
                        int w = ((dd.m_size + 255) / 256) * 4;
                        FillRect(ref bmp, x, 3, w, 26, fill);
                    }
                    else
                    {
                        Color fill = Color.DarkGray;
                        if (1 == (idx & 1))
                            fill = Color.LightGray;

                        int x = dd.m_address * 4;
                        int w = ((dd.m_size + 255) / 256) * 4;
                        FillRect(ref bmp, x, 2, w, 28, fill);
                    }

                    if (m_dd == dd)
                    {
                        // Draw Lasso
                        Color fill = Color.HotPink;

                        int x = dd.m_address * 4;
                        int w = ((dd.m_size + 255) / 256) * 4;
                        FillRect(ref bmp, x,  0, w, 3, fill);
                        FillRect(ref bmp, x, 29, w, 3, fill);
                        FillRect(ref bmp, x, 3, 3, 26, fill);
                        FillRect(ref bmp, x + w - 3, 3, 3, 26, fill);
                    }

                    ++idx;
                }
            }

            pictureBoxMap.ClientSize = new Size(1024, 32);
            pictureBoxMap.Image = bmp;

        }

        private void ButtonUnalloc_Click(object sender, EventArgs e)
        {
            if (null != m_dd)
            {
                m_dd.m_address = -1;
                this.fastObjectListView1.SetObjects(docFiles);
                PaintMemory();
            }
        }

        private void buttonResample_Click(object sender, EventArgs e)
        {
            if (null != m_dd)
            {
                int target_freq = 0;
                Int32.TryParse(comboBoxResampleRate.Text, out target_freq);

                WaveStream ws = m_dd.ToWaveStream();

                switch (resampleBox.SelectedIndex)
                {
                    case 0:
                        // Frequency
                        break;
                    case 1:
                        // Size
                        if (target_freq > 0)
                        {
                            int targetBytes = target_freq;

                            // What Freq would equal this number of bytes
                            float targetFreq = (float)target_freq;

                            targetFreq *= m_dd.m_imFreq;
                            targetFreq /= m_dd.m_imSize;

                            // The math is done here, if we set the resample quality to linear
                            // (lowest)

                            // since we are using a high resample quality, that applies a low-pass
                            // filter, our wave ends up being a little smaller, than expected

                            target_freq = (int)targetFreq;

                            // hunt for the ideal freq, to hit our target size
                            int prev_freq = target_freq;
                            while (true)
                            {
                                byte[] tempWave = ToByteArray(ToFreq(ws, target_freq));

                                int delta = targetBytes - tempWave.Length;

                                if (0 == delta)
                                    break;
                                if (delta < 0)
                                {
                                    target_freq = prev_freq;
                                    break;
                                }

                                prev_freq = target_freq;
                                target_freq++;
                            }
                        }
                        break;
                }
                // If we resample then convert to byte array, and take the length of that
                // then it should be accurate
                byte[] resampled_wave = ToByteArray(ToFreq(ws, target_freq));
                m_dd.m_size = resampled_wave.Length;
                //m_dd.m_size = target_freq * m_dd.m_size / m_dd.m_freq;
                m_dd.m_freq = target_freq;
                comboBoxPlayRate.Text = String.Format("{0}", target_freq);

                m_dd.m_address = -1;
                this.fastObjectListView1.SetObjects(docFiles);
                PaintMemory();
                ws.Dispose();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (null != m_dd)
            {
                m_dd.m_freq = m_dd.m_imFreq;
                m_dd.m_size = m_dd.m_imSize;
                m_dd.m_address = -1;
                comboBoxPlayRate.Text = String.Format("{0}", m_dd.m_freq);
                this.fastObjectListView1.SetObjects(docFiles);
                PaintMemory();
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear Wave Info
            labelName.Text = "<None>";
            labelPath.Text = "";
            // Nothing Selected
            m_dd = null;
            // Empty List of Waves
            docFiles.Clear();
            // Refresh List View
            this.fastObjectListView1.SetObjects(docFiles);
            // Refresh Allocated Memory Map
            PaintMemory();
            // Refresh Selected Wave
            RenderWaveform();
        }

        //
        // Save out data into a bankfile, so we can load it back in later
        //
        void SaveBankDefinition(string pathname)
        {
            // I think all I need to know is
            // basename,pinned status
            // pathname,freq,size
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(pathname))
            {
                file.WriteLine("#/MrAudio");
                file.WriteLine("version=1");
                foreach (docData dd in docFiles)
                {
                    file.WriteLine(string.Format("{0},{1}", dd.m_name, dd.m_pinned));
                    String outString = string.Format("{0},{1},{2}", dd.m_path, dd.m_freq, dd.m_size);
                    file.WriteLine(outString);
                }
            }
        }

        //
        //  Choose the name of the soundbank definition to save
        //
        private void saveBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveSoundBankDialog.ShowDialog();

            if (DialogResult.OK == result)
            {
                SaveBankDefinition(saveSoundBankDialog.FileName);
            }
        }
    }
}
