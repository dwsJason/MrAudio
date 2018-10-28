namespace MrAudio
{
    partial class MrAudio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MrAudio));
            this.waveInfoBox = new System.Windows.Forms.GroupBox();
            this.buttonRealloc = new System.Windows.Forms.Button();
            this.checkPinned = new System.Windows.Forms.CheckBox();
            this.buttonResample = new System.Windows.Forms.Button();
            this.resampleBox = new System.Windows.Forms.ComboBox();
            this.buttonNormalize = new System.Windows.Forms.Button();
            this.comboBoxResampleRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPlayRate = new System.Windows.Forms.ComboBox();
            this.playButton = new System.Windows.Forms.Button();
            this.pictureBoxWave = new System.Windows.Forms.PictureBox();
            this.audioBankBox = new System.Windows.Forms.GroupBox();
            this.fastObjectListView1 = new BrightIdeasSoftware.FastObjectListView();
            this.index = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.address = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.size = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.freq = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.openSoundBankDialog = new System.Windows.Forms.OpenFileDialog();
            this.importAudioDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveSoundBankDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.pictureBoxGuide = new System.Windows.Forms.PictureBox();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.waveInfoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWave)).BeginInit();
            this.audioBankBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGuide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.SuspendLayout();
            // 
            // waveInfoBox
            // 
            this.waveInfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waveInfoBox.Controls.Add(this.buttonRealloc);
            this.waveInfoBox.Controls.Add(this.checkPinned);
            this.waveInfoBox.Controls.Add(this.buttonResample);
            this.waveInfoBox.Controls.Add(this.resampleBox);
            this.waveInfoBox.Controls.Add(this.buttonNormalize);
            this.waveInfoBox.Controls.Add(this.comboBoxResampleRate);
            this.waveInfoBox.Controls.Add(this.label1);
            this.waveInfoBox.Controls.Add(this.comboBoxPlayRate);
            this.waveInfoBox.Controls.Add(this.playButton);
            this.waveInfoBox.Location = new System.Drawing.Point(4, 4);
            this.waveInfoBox.Margin = new System.Windows.Forms.Padding(4);
            this.waveInfoBox.Name = "waveInfoBox";
            this.waveInfoBox.Padding = new System.Windows.Forms.Padding(4);
            this.waveInfoBox.Size = new System.Drawing.Size(472, 320);
            this.waveInfoBox.TabIndex = 0;
            this.waveInfoBox.TabStop = false;
            this.waveInfoBox.Text = "Wave Information";
            // 
            // buttonRealloc
            // 
            this.buttonRealloc.Location = new System.Drawing.Point(81, 39);
            this.buttonRealloc.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRealloc.Name = "buttonRealloc";
            this.buttonRealloc.Size = new System.Drawing.Size(75, 23);
            this.buttonRealloc.TabIndex = 11;
            this.buttonRealloc.Text = "Reallocate";
            this.buttonRealloc.UseVisualStyleBackColor = true;
            // 
            // checkPinned
            // 
            this.checkPinned.AutoSize = true;
            this.checkPinned.Location = new System.Drawing.Point(9, 46);
            this.checkPinned.Margin = new System.Windows.Forms.Padding(4);
            this.checkPinned.Name = "checkPinned";
            this.checkPinned.Size = new System.Drawing.Size(59, 17);
            this.checkPinned.TabIndex = 10;
            this.checkPinned.Text = "Pinned";
            this.checkPinned.UseVisualStyleBackColor = true;
            this.checkPinned.CheckedChanged += new System.EventHandler(this.checkPinned_CheckedChanged);
            // 
            // buttonResample
            // 
            this.buttonResample.Location = new System.Drawing.Point(81, 15);
            this.buttonResample.Margin = new System.Windows.Forms.Padding(4);
            this.buttonResample.Name = "buttonResample";
            this.buttonResample.Size = new System.Drawing.Size(75, 23);
            this.buttonResample.TabIndex = 9;
            this.buttonResample.Text = "Resample";
            this.buttonResample.UseVisualStyleBackColor = true;
            // 
            // resampleBox
            // 
            this.resampleBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resampleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resampleBox.FormattingEnabled = true;
            this.resampleBox.Items.AddRange(new object[] {
            "Resample Hz",
            "Resample Bytes"});
            this.resampleBox.Location = new System.Drawing.Point(302, 42);
            this.resampleBox.Margin = new System.Windows.Forms.Padding(4);
            this.resampleBox.Name = "resampleBox";
            this.resampleBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.resampleBox.Size = new System.Drawing.Size(99, 21);
            this.resampleBox.TabIndex = 8;
            // 
            // buttonNormalize
            // 
            this.buttonNormalize.Location = new System.Drawing.Point(0, 15);
            this.buttonNormalize.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNormalize.Name = "buttonNormalize";
            this.buttonNormalize.Size = new System.Drawing.Size(75, 23);
            this.buttonNormalize.TabIndex = 7;
            this.buttonNormalize.Text = "Normalize";
            this.buttonNormalize.UseVisualStyleBackColor = true;
            // 
            // comboBoxResampleRate
            // 
            this.comboBoxResampleRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxResampleRate.FormattingEnabled = true;
            this.comboBoxResampleRate.Items.AddRange(new object[] {
            "26000",
            "22050",
            "11025",
            "5500",
            "2500"});
            this.comboBoxResampleRate.Location = new System.Drawing.Point(407, 42);
            this.comboBoxResampleRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxResampleRate.Name = "comboBoxResampleRate";
            this.comboBoxResampleRate.Size = new System.Drawing.Size(65, 21);
            this.comboBoxResampleRate.TabIndex = 5;
            this.comboBoxResampleRate.Text = "26000";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(322, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Playback Rate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPlayRate
            // 
            this.comboBoxPlayRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPlayRate.FormattingEnabled = true;
            this.comboBoxPlayRate.Items.AddRange(new object[] {
            "44100",
            "22050",
            "11025",
            "8000"});
            this.comboBoxPlayRate.Location = new System.Drawing.Point(407, 15);
            this.comboBoxPlayRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPlayRate.Name = "comboBoxPlayRate";
            this.comboBoxPlayRate.Size = new System.Drawing.Size(65, 21);
            this.comboBoxPlayRate.TabIndex = 2;
            this.comboBoxPlayRate.Text = "44100";
            this.comboBoxPlayRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayRate_SelectedIndexChanged);
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Image = ((System.Drawing.Image)(resources.GetObject("playButton.Image")));
            this.playButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.playButton.Location = new System.Drawing.Point(407, 110);
            this.playButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(65, 29);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pictureBoxWave
            // 
            this.pictureBoxWave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxWave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxWave.Location = new System.Drawing.Point(3, 31);
            this.pictureBoxWave.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxWave.Name = "pictureBoxWave";
            this.pictureBoxWave.Size = new System.Drawing.Size(1000, 64);
            this.pictureBoxWave.TabIndex = 12;
            this.pictureBoxWave.TabStop = false;
            // 
            // audioBankBox
            // 
            this.audioBankBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.audioBankBox.Controls.Add(this.fastObjectListView1);
            this.audioBankBox.Location = new System.Drawing.Point(4, 4);
            this.audioBankBox.Margin = new System.Windows.Forms.Padding(4);
            this.audioBankBox.Name = "audioBankBox";
            this.audioBankBox.Padding = new System.Windows.Forms.Padding(4);
            this.audioBankBox.Size = new System.Drawing.Size(507, 324);
            this.audioBankBox.TabIndex = 0;
            this.audioBankBox.TabStop = false;
            this.audioBankBox.Text = "Audio Bank";
            // 
            // fastObjectListView1
            // 
            this.fastObjectListView1.AllColumns.Add(this.index);
            this.fastObjectListView1.AllColumns.Add(this.name);
            this.fastObjectListView1.AllColumns.Add(this.address);
            this.fastObjectListView1.AllColumns.Add(this.size);
            this.fastObjectListView1.AllColumns.Add(this.freq);
            this.fastObjectListView1.AllowColumnReorder = true;
            this.fastObjectListView1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.fastObjectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastObjectListView1.CellEditUseWholeCell = false;
            this.fastObjectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.name,
            this.address,
            this.size,
            this.freq});
            this.fastObjectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastObjectListView1.FullRowSelect = true;
            this.fastObjectListView1.GridLines = true;
            this.fastObjectListView1.Location = new System.Drawing.Point(6, 19);
            this.fastObjectListView1.Margin = new System.Windows.Forms.Padding(4);
            this.fastObjectListView1.Name = "fastObjectListView1";
            this.fastObjectListView1.SelectedBackColor = System.Drawing.SystemColors.WindowFrame;
            this.fastObjectListView1.ShowGroups = false;
            this.fastObjectListView1.Size = new System.Drawing.Size(494, 299);
            this.fastObjectListView1.TabIndex = 0;
            this.fastObjectListView1.TintSortColumn = true;
            this.fastObjectListView1.UseAlternatingBackColors = true;
            this.fastObjectListView1.UseCompatibleStateImageBehavior = false;
            this.fastObjectListView1.View = System.Windows.Forms.View.Details;
            this.fastObjectListView1.VirtualMode = true;
            // 
            // index
            // 
            this.index.AspectName = "m_index";
            this.index.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.index.Text = "#";
            this.index.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.index.Width = 20;
            // 
            // name
            // 
            this.name.AspectName = "m_name";
            this.name.Text = "Wave Name";
            this.name.Width = 193;
            // 
            // address
            // 
            this.address.AspectName = "m_address";
            this.address.AspectToStringFormat = "${0:X2}00";
            this.address.Text = "Address";
            // 
            // size
            // 
            this.size.AspectName = "m_size";
            this.size.Text = "Size Bytes";
            this.size.Width = 66;
            // 
            // freq
            // 
            this.freq.AspectName = "m_freq";
            this.freq.Text = "Freq Hz";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1006, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBankToolStripMenuItem,
            this.loadBankToolStripMenuItem,
            this.saveBankToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.importAudioToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newBankToolStripMenuItem
            // 
            this.newBankToolStripMenuItem.Name = "newBankToolStripMenuItem";
            this.newBankToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.newBankToolStripMenuItem.Text = "New Bank";
            // 
            // loadBankToolStripMenuItem
            // 
            this.loadBankToolStripMenuItem.Name = "loadBankToolStripMenuItem";
            this.loadBankToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.loadBankToolStripMenuItem.Text = "Load Bank";
            // 
            // saveBankToolStripMenuItem
            // 
            this.saveBankToolStripMenuItem.Name = "saveBankToolStripMenuItem";
            this.saveBankToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveBankToolStripMenuItem.Text = "Save Bank";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // importAudioToolStripMenuItem
            // 
            this.importAudioToolStripMenuItem.Name = "importAudioToolStripMenuItem";
            this.importAudioToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.importAudioToolStripMenuItem.Text = "Import Audio";
            this.importAudioToolStripMenuItem.Click += new System.EventHandler(this.importAudioToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 507);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1006, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // openSoundBankDialog
            // 
            this.openSoundBankDialog.FileName = "*.xml";
            this.openSoundBankDialog.Title = "Open Sound Bank";
            // 
            // importAudioDialog
            // 
            this.importAudioDialog.Filter = "All Audio|*.ntp;*.mp3;*.wav;*.aif;*raw|MP3 Files|*.mp3|WAV files|*.wav|Amiga File" +
    "s|*.aif,*.aiff|RAW Files|*.raw|Ninja Tracker Plus|*.ntp";
            this.importAudioDialog.Multiselect = true;
            this.importAudioDialog.RestoreDirectory = true;
            this.importAudioDialog.Title = "Import Audio Files";
            // 
            // saveSoundBankDialog
            // 
            this.saveSoundBankDialog.RestoreDirectory = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(3, 100);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.waveInfoBox);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.audioBankBox);
            this.splitContainer3.Size = new System.Drawing.Size(999, 328);
            this.splitContainer3.SplitterDistance = 480;
            this.splitContainer3.TabIndex = 13;
            // 
            // pictureBoxGuide
            // 
            this.pictureBoxGuide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGuide.Location = new System.Drawing.Point(0, 435);
            this.pictureBoxGuide.Name = "pictureBoxGuide";
            this.pictureBoxGuide.Size = new System.Drawing.Size(1002, 32);
            this.pictureBoxGuide.TabIndex = 14;
            this.pictureBoxGuide.TabStop = false;
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMap.Location = new System.Drawing.Point(0, 472);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(1006, 32);
            this.pictureBoxMap.TabIndex = 15;
            this.pictureBoxMap.TabStop = false;
            // 
            // MrAudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 529);
            this.Controls.Add(this.pictureBoxMap);
            this.Controls.Add(this.pictureBoxGuide);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.pictureBoxWave);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MrAudio";
            this.Text = "MrAudio";
            this.waveInfoBox.ResumeLayout(false);
            this.waveInfoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWave)).EndInit();
            this.audioBankBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastObjectListView1)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGuide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox waveInfoBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importAudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox audioBankBox;
        private BrightIdeasSoftware.FastObjectListView fastObjectListView1;
        private BrightIdeasSoftware.OLVColumn index;
        private BrightIdeasSoftware.OLVColumn name;
        private BrightIdeasSoftware.OLVColumn address;
        private BrightIdeasSoftware.OLVColumn size;
        private BrightIdeasSoftware.OLVColumn freq;
        private System.Windows.Forms.OpenFileDialog openSoundBankDialog;
        private System.Windows.Forms.OpenFileDialog importAudioDialog;
        private System.Windows.Forms.SaveFileDialog saveSoundBankDialog;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPlayRate;
        private System.Windows.Forms.ComboBox comboBoxResampleRate;
        private System.Windows.Forms.Button buttonNormalize;
        private System.Windows.Forms.ComboBox resampleBox;
        private System.Windows.Forms.Button buttonResample;
        private System.Windows.Forms.Button buttonRealloc;
        private System.Windows.Forms.CheckBox checkPinned;
        private System.Windows.Forms.PictureBox pictureBoxWave;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PictureBox pictureBoxGuide;
        private System.Windows.Forms.PictureBox pictureBoxMap;
    }
}

