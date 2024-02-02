namespace RoastSharp
{
    partial class SettingsUi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsUi));
            this.ComPortLabel = new System.Windows.Forms.Label();
            this.ComPortDropDown = new System.Windows.Forms.ComboBox();
            this.SamplesLabel = new System.Windows.Forms.Label();
            this.RorSampleTimeLabel = new System.Windows.Forms.Label();
            this.RorDelayTimeLabel = new System.Windows.Forms.Label();
            this.SamplesTextBox = new System.Windows.Forms.NumericUpDown();
            this.RorSampleTimeTextBox = new System.Windows.Forms.NumericUpDown();
            this.RorDelayTimeTextBox = new System.Windows.Forms.NumericUpDown();
            this.EnableLoggingCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableLoggingLabel = new System.Windows.Forms.Label();
            this.BaudRateLabel = new System.Windows.Forms.Label();
            this.BaudRateDropDown = new System.Windows.Forms.ComboBox();
            this.XStepsLabel = new System.Windows.Forms.Label();
            this.XStepsTextBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.SamplesTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RorSampleTimeTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RorDelayTimeTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XStepsTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ComPortLabel
            // 
            this.ComPortLabel.AutoSize = true;
            this.ComPortLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPortLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ComPortLabel.Location = new System.Drawing.Point(13, 13);
            this.ComPortLabel.Name = "ComPortLabel";
            this.ComPortLabel.Size = new System.Drawing.Size(75, 16);
            this.ComPortLabel.TabIndex = 0;
            this.ComPortLabel.Text = "COM port:";
            // 
            // ComPortDropDown
            // 
            this.ComPortDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPortDropDown.FormattingEnabled = true;
            this.ComPortDropDown.Location = new System.Drawing.Point(95, 10);
            this.ComPortDropDown.Name = "ComPortDropDown";
            this.ComPortDropDown.Size = new System.Drawing.Size(207, 21);
            this.ComPortDropDown.TabIndex = 1;
            // 
            // SamplesLabel
            // 
            this.SamplesLabel.AutoSize = true;
            this.SamplesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SamplesLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SamplesLabel.Location = new System.Drawing.Point(13, 64);
            this.SamplesLabel.Name = "SamplesLabel";
            this.SamplesLabel.Size = new System.Drawing.Size(186, 16);
            this.SamplesLabel.TabIndex = 5;
            this.SamplesLabel.Text = "Moving average samples:";
            // 
            // RorSampleTimeLabel
            // 
            this.RorSampleTimeLabel.AutoSize = true;
            this.RorSampleTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RorSampleTimeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RorSampleTimeLabel.Location = new System.Drawing.Point(13, 91);
            this.RorSampleTimeLabel.Name = "RorSampleTimeLabel";
            this.RorSampleTimeLabel.Size = new System.Drawing.Size(171, 16);
            this.RorSampleTimeLabel.TabIndex = 6;
            this.RorSampleTimeLabel.Text = "ROR sample time (sec):";
            // 
            // RorDelayTimeLabel
            // 
            this.RorDelayTimeLabel.AutoSize = true;
            this.RorDelayTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RorDelayTimeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RorDelayTimeLabel.Location = new System.Drawing.Point(13, 118);
            this.RorDelayTimeLabel.Name = "RorDelayTimeLabel";
            this.RorDelayTimeLabel.Size = new System.Drawing.Size(159, 16);
            this.RorDelayTimeLabel.TabIndex = 7;
            this.RorDelayTimeLabel.Text = "ROR delay time (sec):";
            // 
            // SamplesTextBox
            // 
            this.SamplesTextBox.Location = new System.Drawing.Point(238, 65);
            this.SamplesTextBox.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.SamplesTextBox.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.SamplesTextBox.Name = "SamplesTextBox";
            this.SamplesTextBox.Size = new System.Drawing.Size(64, 20);
            this.SamplesTextBox.TabIndex = 8;
            this.SamplesTextBox.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // RorSampleTimeTextBox
            // 
            this.RorSampleTimeTextBox.Location = new System.Drawing.Point(238, 91);
            this.RorSampleTimeTextBox.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.RorSampleTimeTextBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RorSampleTimeTextBox.Name = "RorSampleTimeTextBox";
            this.RorSampleTimeTextBox.Size = new System.Drawing.Size(64, 20);
            this.RorSampleTimeTextBox.TabIndex = 9;
            this.RorSampleTimeTextBox.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // RorDelayTimeTextBox
            // 
            this.RorDelayTimeTextBox.Location = new System.Drawing.Point(238, 117);
            this.RorDelayTimeTextBox.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.RorDelayTimeTextBox.Name = "RorDelayTimeTextBox";
            this.RorDelayTimeTextBox.Size = new System.Drawing.Size(64, 20);
            this.RorDelayTimeTextBox.TabIndex = 10;
            this.RorDelayTimeTextBox.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // EnableLoggingCheckBox
            // 
            this.EnableLoggingCheckBox.AutoSize = true;
            this.EnableLoggingCheckBox.Checked = true;
            this.EnableLoggingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableLoggingCheckBox.Location = new System.Drawing.Point(238, 170);
            this.EnableLoggingCheckBox.Name = "EnableLoggingCheckBox";
            this.EnableLoggingCheckBox.Size = new System.Drawing.Size(80, 17);
            this.EnableLoggingCheckBox.TabIndex = 11;
            this.EnableLoggingCheckBox.Text = "checkBox1";
            this.EnableLoggingCheckBox.UseVisualStyleBackColor = true;
            // 
            // EnableLoggingLabel
            // 
            this.EnableLoggingLabel.AutoSize = true;
            this.EnableLoggingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableLoggingLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EnableLoggingLabel.Location = new System.Drawing.Point(13, 169);
            this.EnableLoggingLabel.Name = "EnableLoggingLabel";
            this.EnableLoggingLabel.Size = new System.Drawing.Size(120, 16);
            this.EnableLoggingLabel.TabIndex = 12;
            this.EnableLoggingLabel.Text = "Enable CSV log:";
            // 
            // BaudRateLabel
            // 
            this.BaudRateLabel.AutoSize = true;
            this.BaudRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaudRateLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BaudRateLabel.Location = new System.Drawing.Point(13, 38);
            this.BaudRateLabel.Name = "BaudRateLabel";
            this.BaudRateLabel.Size = new System.Drawing.Size(78, 16);
            this.BaudRateLabel.TabIndex = 13;
            this.BaudRateLabel.Text = "Baud rate:";
            // 
            // BaudRateDropDown
            // 
            this.BaudRateDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaudRateDropDown.FormattingEnabled = true;
            this.BaudRateDropDown.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.BaudRateDropDown.Location = new System.Drawing.Point(95, 37);
            this.BaudRateDropDown.Name = "BaudRateDropDown";
            this.BaudRateDropDown.Size = new System.Drawing.Size(207, 21);
            this.BaudRateDropDown.TabIndex = 14;
            this.BaudRateDropDown.Text = "115200";
            // 
            // XStepsLabel
            // 
            this.XStepsLabel.AutoSize = true;
            this.XStepsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XStepsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.XStepsLabel.Location = new System.Drawing.Point(13, 144);
            this.XStepsLabel.Name = "XStepsLabel";
            this.XStepsLabel.Size = new System.Drawing.Size(101, 16);
            this.XStepsLabel.TabIndex = 15;
            this.XStepsLabel.Text = "X steps (sec):";
            // 
            // XStepsTextBox
            // 
            this.XStepsTextBox.Location = new System.Drawing.Point(238, 143);
            this.XStepsTextBox.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.XStepsTextBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.XStepsTextBox.Name = "XStepsTextBox";
            this.XStepsTextBox.Size = new System.Drawing.Size(64, 20);
            this.XStepsTextBox.TabIndex = 16;
            this.XStepsTextBox.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // SettingsUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(318, 200);
            this.Controls.Add(this.XStepsTextBox);
            this.Controls.Add(this.XStepsLabel);
            this.Controls.Add(this.BaudRateDropDown);
            this.Controls.Add(this.BaudRateLabel);
            this.Controls.Add(this.EnableLoggingLabel);
            this.Controls.Add(this.EnableLoggingCheckBox);
            this.Controls.Add(this.RorDelayTimeTextBox);
            this.Controls.Add(this.RorSampleTimeTextBox);
            this.Controls.Add(this.SamplesTextBox);
            this.Controls.Add(this.RorDelayTimeLabel);
            this.Controls.Add(this.RorSampleTimeLabel);
            this.Controls.Add(this.SamplesLabel);
            this.Controls.Add(this.ComPortDropDown);
            this.Controls.Add(this.ComPortLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsUi";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.SamplesTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RorSampleTimeTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RorDelayTimeTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XStepsTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ComPortLabel;
        private System.Windows.Forms.ComboBox ComPortDropDown;
        private System.Windows.Forms.Label SamplesLabel;
        private System.Windows.Forms.Label RorSampleTimeLabel;
        private System.Windows.Forms.Label RorDelayTimeLabel;
        private System.Windows.Forms.NumericUpDown SamplesTextBox;
        private System.Windows.Forms.NumericUpDown RorSampleTimeTextBox;
        private System.Windows.Forms.NumericUpDown RorDelayTimeTextBox;
        private System.Windows.Forms.CheckBox EnableLoggingCheckBox;
        private System.Windows.Forms.Label EnableLoggingLabel;
        private System.Windows.Forms.Label BaudRateLabel;
        private System.Windows.Forms.ComboBox BaudRateDropDown;
        private System.Windows.Forms.Label XStepsLabel;
        private System.Windows.Forms.NumericUpDown XStepsTextBox;
    }
}