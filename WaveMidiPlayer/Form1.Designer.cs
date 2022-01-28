namespace WaveMidiPlayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._examineButton = new System.Windows.Forms.Button();
            this._playPauseButton = new System.Windows.Forms.Button();
            this._filePathTextBox = new System.Windows.Forms.TextBox();
            this._volumeSlider = new WaveMidiPlayer.Slider();
            this.label1 = new System.Windows.Forms.Label();
            this._waveTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._stopButton = new System.Windows.Forms.Button();
            this._semitoneNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._semitoneNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _examineButton
            // 
            this._examineButton.Location = new System.Drawing.Point(344, 21);
            this._examineButton.Margin = new System.Windows.Forms.Padding(0);
            this._examineButton.Name = "_examineButton";
            this._examineButton.Size = new System.Drawing.Size(75, 25);
            this._examineButton.TabIndex = 0;
            this._examineButton.Text = "Examine";
            this._examineButton.UseVisualStyleBackColor = true;
            this._examineButton.Click += new System.EventHandler(this.OnExamineButtonClicked);
            // 
            // _playPauseButton
            // 
            this._playPauseButton.Location = new System.Drawing.Point(226, 90);
            this._playPauseButton.Name = "_playPauseButton";
            this._playPauseButton.Size = new System.Drawing.Size(95, 40);
            this._playPauseButton.TabIndex = 1;
            this._playPauseButton.Text = "Play";
            this._playPauseButton.UseVisualStyleBackColor = true;
            this._playPauseButton.Click += new System.EventHandler(this.OnPlayPauseButtonClicked);
            // 
            // _filePathTextBox
            // 
            this._filePathTextBox.Location = new System.Drawing.Point(12, 22);
            this._filePathTextBox.Name = "_filePathTextBox";
            this._filePathTextBox.PlaceholderText = "Midi file path...";
            this._filePathTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._filePathTextBox.Size = new System.Drawing.Size(329, 23);
            this._filePathTextBox.TabIndex = 2;
            // 
            // _volumeSlider
            // 
            this._volumeSlider.BackColor = System.Drawing.Color.Transparent;
            this._volumeSlider.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this._volumeSlider.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this._volumeSlider.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this._volumeSlider.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this._volumeSlider.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this._volumeSlider.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this._volumeSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._volumeSlider.ForeColor = System.Drawing.Color.Transparent;
            this._volumeSlider.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this._volumeSlider.Location = new System.Drawing.Point(85, 65);
            this._volumeSlider.Margin = new System.Windows.Forms.Padding(0);
            this._volumeSlider.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._volumeSlider.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._volumeSlider.Name = "_volumeSlider";
            this._volumeSlider.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._volumeSlider.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this._volumeSlider.ShowDivisionsText = true;
            this._volumeSlider.ShowSmallScale = false;
            this._volumeSlider.Size = new System.Drawing.Size(120, 20);
            this._volumeSlider.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._volumeSlider.TabIndex = 6;
            this._volumeSlider.Text = "slider1";
            this._volumeSlider.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this._volumeSlider.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this._volumeSlider.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this._volumeSlider.ThumbSize = new System.Drawing.Size(16, 16);
            this._volumeSlider.TickAdd = 0F;
            this._volumeSlider.TickColor = System.Drawing.Color.Transparent;
            this._volumeSlider.TickDivide = 0F;
            this._volumeSlider.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this._volumeSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.OnVolumeSliderScrolled);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Volume";
            // 
            // _waveTypeComboBox
            // 
            this._waveTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._waveTypeComboBox.FormattingEnabled = true;
            this._waveTypeComboBox.Location = new System.Drawing.Point(85, 100);
            this._waveTypeComboBox.Name = "_waveTypeComboBox";
            this._waveTypeComboBox.Size = new System.Drawing.Size(120, 23);
            this._waveTypeComboBox.TabIndex = 8;
            this._waveTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.OnWaveTypeValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Wave type";
            // 
            // _stopButton
            // 
            this._stopButton.Location = new System.Drawing.Point(327, 90);
            this._stopButton.Name = "_stopButton";
            this._stopButton.Size = new System.Drawing.Size(95, 40);
            this._stopButton.TabIndex = 10;
            this._stopButton.Text = "Stop";
            this._stopButton.UseVisualStyleBackColor = true;
            this._stopButton.Click += new System.EventHandler(this.OnStopButtonClicked);
            // 
            // _semitoneNumericUpDown
            // 
            this._semitoneNumericUpDown.Location = new System.Drawing.Point(85, 140);
            this._semitoneNumericUpDown.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this._semitoneNumericUpDown.Minimum = new decimal(new int[] {
            36,
            0,
            0,
            -2147483648});
            this._semitoneNumericUpDown.Name = "_semitoneNumericUpDown";
            this._semitoneNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this._semitoneNumericUpDown.TabIndex = 11;
            this._semitoneNumericUpDown.ValueChanged += new System.EventHandler(this.OnSemitoneChanged);
            this._semitoneNumericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnSemitoneKeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Semitones";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 175);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._semitoneNumericUpDown);
            this.Controls.Add(this._stopButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._waveTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._volumeSlider);
            this.Controls.Add(this._filePathTextBox);
            this.Controls.Add(this._playPauseButton);
            this.Controls.Add(this._examineButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Wave Midi Player";
            ((System.ComponentModel.ISupportInitialize)(this._semitoneNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button _examineButton;
        private Button _playPauseButton;
        private TextBox _filePathTextBox;
        private Slider _volumeSlider;
        private Label label1;
        private ComboBox _waveTypeComboBox;
        private Label label2;
        private Button _stopButton;
        private NumericUpDown _semitoneNumericUpDown;
        private Label label3;
    }
}