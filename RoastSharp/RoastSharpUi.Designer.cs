namespace RoastSharp
{
    partial class RoastSharpUi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoastSharpUi));
            this.ConnectButton = new System.Windows.Forms.Button();
            this.TempLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.RoastTimeLabel = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.RorLabel = new System.Windows.Forms.Label();
            this.AvgTempLabel = new System.Windows.Forms.Label();
            this.EventButton = new System.Windows.Forms.Button();
            this.EndButton = new System.Windows.Forms.Button();
            this.ScEndButton = new System.Windows.Forms.Button();
            this.ScStartButton = new System.Windows.Forms.Button();
            this.FcEndButton = new System.Windows.Forms.Button();
            this.FcStartButton = new System.Windows.Forms.Button();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.RoastChart = new LiveCharts.WinForms.CartesianChart();
            this.ControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConnectButton.BackColor = System.Drawing.Color.White;
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ConnectButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ConnectButton.Location = new System.Drawing.Point(12, 25);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(118, 24);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // TempLabel
            // 
            this.TempLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TempLabel.AutoSize = true;
            this.TempLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TempLabel.ForeColor = System.Drawing.Color.Yellow;
            this.TempLabel.Location = new System.Drawing.Point(749, 66);
            this.TempLabel.Name = "TempLabel";
            this.TempLabel.Size = new System.Drawing.Size(99, 24);
            this.TempLabel.TabIndex = 2;
            this.TempLabel.Text = "000.00°C";
            // 
            // StartButton
            // 
            this.StartButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StartButton.BackColor = System.Drawing.Color.Gainsboro;
            this.StartButton.Enabled = false;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StartButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.StartButton.Location = new System.Drawing.Point(150, 25);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(70, 56);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ControlPanel.Controls.Add(this.RoastTimeLabel);
            this.ControlPanel.Controls.Add(this.SettingsButton);
            this.ControlPanel.Controls.Add(this.RorLabel);
            this.ControlPanel.Controls.Add(this.AvgTempLabel);
            this.ControlPanel.Controls.Add(this.EventButton);
            this.ControlPanel.Controls.Add(this.EndButton);
            this.ControlPanel.Controls.Add(this.ScEndButton);
            this.ControlPanel.Controls.Add(this.ScStartButton);
            this.ControlPanel.Controls.Add(this.FcEndButton);
            this.ControlPanel.Controls.Add(this.FcStartButton);
            this.ControlPanel.Controls.Add(this.TimeLabel);
            this.ControlPanel.Controls.Add(this.ConnectButton);
            this.ControlPanel.Controls.Add(this.StartButton);
            this.ControlPanel.Controls.Add(this.TempLabel);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(1284, 99);
            this.ControlPanel.TabIndex = 8;
            // 
            // RoastTimeLabel
            // 
            this.RoastTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RoastTimeLabel.AutoSize = true;
            this.RoastTimeLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoastTimeLabel.ForeColor = System.Drawing.Color.White;
            this.RoastTimeLabel.Location = new System.Drawing.Point(1087, 13);
            this.RoastTimeLabel.Name = "RoastTimeLabel";
            this.RoastTimeLabel.Size = new System.Drawing.Size(108, 16);
            this.RoastTimeLabel.TabIndex = 14;
            this.RoastTimeLabel.Text = "Total Roast Time:";
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SettingsButton.BackColor = System.Drawing.Color.White;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SettingsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.SettingsButton.Location = new System.Drawing.Point(12, 57);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(118, 24);
            this.SettingsButton.TabIndex = 13;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // RorLabel
            // 
            this.RorLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RorLabel.AutoSize = true;
            this.RorLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RorLabel.ForeColor = System.Drawing.Color.Red;
            this.RorLabel.Location = new System.Drawing.Point(862, 25);
            this.RorLabel.Name = "RorLabel";
            this.RorLabel.Size = new System.Drawing.Size(210, 44);
            this.RorLabel.TabIndex = 12;
            this.RorLabel.Text = "00.0°C/min";
            // 
            // AvgTempLabel
            // 
            this.AvgTempLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AvgTempLabel.AutoSize = true;
            this.AvgTempLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgTempLabel.ForeColor = System.Drawing.Color.Aqua;
            this.AvgTempLabel.Location = new System.Drawing.Point(679, 25);
            this.AvgTempLabel.Name = "AvgTempLabel";
            this.AvgTempLabel.Size = new System.Drawing.Size(176, 44);
            this.AvgTempLabel.TabIndex = 11;
            this.AvgTempLabel.Text = "000.00°C";
            // 
            // EventButton
            // 
            this.EventButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EventButton.BackColor = System.Drawing.Color.Gainsboro;
            this.EventButton.Enabled = false;
            this.EventButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.EventButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventButton.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.EventButton.Location = new System.Drawing.Point(530, 25);
            this.EventButton.Name = "EventButton";
            this.EventButton.Size = new System.Drawing.Size(70, 56);
            this.EventButton.TabIndex = 10;
            this.EventButton.Text = "Event";
            this.EventButton.UseVisualStyleBackColor = false;
            this.EventButton.Click += new System.EventHandler(this.EventButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EndButton.BackColor = System.Drawing.Color.Gainsboro;
            this.EndButton.Enabled = false;
            this.EndButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.EndButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndButton.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.EndButton.Location = new System.Drawing.Point(606, 25);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(70, 56);
            this.EndButton.TabIndex = 9;
            this.EndButton.Text = "End";
            this.EndButton.UseVisualStyleBackColor = false;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // ScEndButton
            // 
            this.ScEndButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ScEndButton.BackColor = System.Drawing.Color.Gainsboro;
            this.ScEndButton.Enabled = false;
            this.ScEndButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ScEndButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScEndButton.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ScEndButton.Location = new System.Drawing.Point(454, 25);
            this.ScEndButton.Name = "ScEndButton";
            this.ScEndButton.Size = new System.Drawing.Size(70, 56);
            this.ScEndButton.TabIndex = 8;
            this.ScEndButton.Text = "SC End";
            this.ScEndButton.UseVisualStyleBackColor = false;
            this.ScEndButton.Click += new System.EventHandler(this.ScEndButton_Click);
            // 
            // ScStartButton
            // 
            this.ScStartButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ScStartButton.BackColor = System.Drawing.Color.Gainsboro;
            this.ScStartButton.Enabled = false;
            this.ScStartButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ScStartButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScStartButton.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ScStartButton.Location = new System.Drawing.Point(378, 25);
            this.ScStartButton.Name = "ScStartButton";
            this.ScStartButton.Size = new System.Drawing.Size(70, 56);
            this.ScStartButton.TabIndex = 7;
            this.ScStartButton.Text = "SC Start";
            this.ScStartButton.UseVisualStyleBackColor = false;
            this.ScStartButton.Click += new System.EventHandler(this.ScStartButton_Click);
            // 
            // FcEndButton
            // 
            this.FcEndButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FcEndButton.BackColor = System.Drawing.Color.Gainsboro;
            this.FcEndButton.Enabled = false;
            this.FcEndButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FcEndButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FcEndButton.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.FcEndButton.Location = new System.Drawing.Point(302, 25);
            this.FcEndButton.Name = "FcEndButton";
            this.FcEndButton.Size = new System.Drawing.Size(70, 56);
            this.FcEndButton.TabIndex = 6;
            this.FcEndButton.Text = "FC End";
            this.FcEndButton.UseVisualStyleBackColor = false;
            this.FcEndButton.Click += new System.EventHandler(this.FcEndButton_Click);
            // 
            // FcStartButton
            // 
            this.FcStartButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FcStartButton.BackColor = System.Drawing.Color.Gainsboro;
            this.FcStartButton.Enabled = false;
            this.FcStartButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FcStartButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FcStartButton.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.FcStartButton.Location = new System.Drawing.Point(226, 25);
            this.FcStartButton.Name = "FcStartButton";
            this.FcStartButton.Size = new System.Drawing.Size(70, 56);
            this.FcStartButton.TabIndex = 5;
            this.FcStartButton.Text = "FC Start";
            this.FcStartButton.UseVisualStyleBackColor = false;
            this.FcStartButton.Click += new System.EventHandler(this.FcStartButton_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.ForeColor = System.Drawing.Color.MintCream;
            this.TimeLabel.Location = new System.Drawing.Point(1079, 25);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(192, 44);
            this.TimeLabel.TabIndex = 4;
            this.TimeLabel.Text = "00:00:000";
            // 
            // RoastChart
            // 
            this.RoastChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoastChart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RoastChart.Location = new System.Drawing.Point(0, 86);
            this.RoastChart.Name = "RoastChart";
            this.RoastChart.Size = new System.Drawing.Size(1284, 475);
            this.RoastChart.TabIndex = 9;
            this.RoastChart.Text = "cartesianChart1";
            // 
            // RoastSharpUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.RoastChart);
            this.Controls.Add(this.ControlPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1300, 600);
            this.Name = "RoastSharpUi";
            this.Text = "Roast Sharp";
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label TempLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button EventButton;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.Button ScEndButton;
        private System.Windows.Forms.Button ScStartButton;
        private System.Windows.Forms.Button FcEndButton;
        private System.Windows.Forms.Button FcStartButton;
        private System.Windows.Forms.Label TimeLabel;
        private LiveCharts.WinForms.CartesianChart RoastChart;
        private System.Windows.Forms.Label AvgTempLabel;
        private System.Windows.Forms.Label RorLabel;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Label RoastTimeLabel;
    }
}

