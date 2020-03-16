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
            ((System.ComponentModel.ISupportInitialize)(this.SamplesTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RorSampleTimeTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RorDelayTimeTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ComPortLabel
            // 
            this.ComPortLabel.AutoSize = true;
            this.ComPortLabel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPortLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ComPortLabel.Location = new System.Drawing.Point(13, 13);
            this.ComPortLabel.Name = "ComPortLabel";
            this.ComPortLabel.Size = new System.Drawing.Size(62, 16);
            this.ComPortLabel.TabIndex = 0;
            this.ComPortLabel.Text = "COM Port:";
            // 
            // ComPortDropDown
            // 
            this.ComPortDropDown.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComPortDropDown.FormattingEnabled = true;
            this.ComPortDropDown.Location = new System.Drawing.Point(75, 10);
            this.ComPortDropDown.Name = "ComPortDropDown";
            this.ComPortDropDown.Size = new System.Drawing.Size(227, 24);
            this.ComPortDropDown.TabIndex = 1;
            // 
            // SamplesLabel
            // 
            this.SamplesLabel.AutoSize = true;
            this.SamplesLabel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SamplesLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SamplesLabel.Location = new System.Drawing.Point(13, 40);
            this.SamplesLabel.Name = "SamplesLabel";
            this.SamplesLabel.Size = new System.Drawing.Size(141, 16);
            this.SamplesLabel.TabIndex = 5;
            this.SamplesLabel.Text = "Moving average samples:";
            // 
            // RorSampleTimeLabel
            // 
            this.RorSampleTimeLabel.AutoSize = true;
            this.RorSampleTimeLabel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RorSampleTimeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RorSampleTimeLabel.Location = new System.Drawing.Point(13, 66);
            this.RorSampleTimeLabel.Name = "RorSampleTimeLabel";
            this.RorSampleTimeLabel.Size = new System.Drawing.Size(130, 16);
            this.RorSampleTimeLabel.TabIndex = 6;
            this.RorSampleTimeLabel.Text = "ROR sample time (sec):";
            // 
            // RorDelayTimeLabel
            // 
            this.RorDelayTimeLabel.AutoSize = true;
            this.RorDelayTimeLabel.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RorDelayTimeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RorDelayTimeLabel.Location = new System.Drawing.Point(13, 92);
            this.RorDelayTimeLabel.Name = "RorDelayTimeLabel";
            this.RorDelayTimeLabel.Size = new System.Drawing.Size(121, 16);
            this.RorDelayTimeLabel.TabIndex = 7;
            this.RorDelayTimeLabel.Text = "ROR delay time (sec):";
            // 
            // SamplesTextBox
            // 
            this.SamplesTextBox.Location = new System.Drawing.Point(238, 41);
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
            4,
            0,
            0,
            0});
            // 
            // RorSampleTimeTextBox
            // 
            this.RorSampleTimeTextBox.Location = new System.Drawing.Point(238, 67);
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
            5,
            0,
            0,
            0});
            // 
            // RorDelayTimeTextBox
            // 
            this.RorDelayTimeTextBox.Location = new System.Drawing.Point(238, 93);
            this.RorDelayTimeTextBox.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.RorDelayTimeTextBox.Name = "RorDelayTimeTextBox";
            this.RorDelayTimeTextBox.Size = new System.Drawing.Size(64, 20);
            this.RorDelayTimeTextBox.TabIndex = 10;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(318, 124);
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
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.SamplesTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RorSampleTimeTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RorDelayTimeTextBox)).EndInit();
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
    }
}