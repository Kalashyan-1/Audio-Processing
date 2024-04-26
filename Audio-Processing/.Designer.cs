using System;
using System.Windows.Forms;

namespace Audio_Processing
{
    partial class AudioProcessor
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
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.VolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.InputDev = new System.Windows.Forms.ComboBox();
            this.OutputDev = new System.Windows.Forms.ComboBox();
            this.InputDevLabel = new System.Windows.Forms.Label();
            this.OutputDevLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(136, 358);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(92, 35);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(412, 358);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(92, 35);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // VolumeTrackBar
            // 
            this.VolumeTrackBar.Location = new System.Drawing.Point(136, 233);
            this.VolumeTrackBar.Name = "VolumeTrackBar";
            this.VolumeTrackBar.Size = new System.Drawing.Size(356, 56);
            this.VolumeTrackBar.TabIndex = 3;
            this.VolumeTrackBar.Scroll += new System.EventHandler(this.VolumeTrackBar_Scroll);
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Location = new System.Drawing.Point(133, 214);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(53, 16);
            this.VolumeLabel.TabIndex = 4;
            this.VolumeLabel.Text = "Volume";
            // 
            // InputDev
            // 
            this.InputDev.FormattingEnabled = true;
            this.InputDev.Location = new System.Drawing.Point(136, 124);
            this.InputDev.Name = "InputDev";
            this.InputDev.Size = new System.Drawing.Size(121, 24);
            this.InputDev.TabIndex = 6;
            this.InputDev.SelectedIndexChanged += new System.EventHandler(this.InputDev_SelectedIndexChanged);
            // 
            // OutputDev
            // 
            this.OutputDev.FormattingEnabled = true;
            this.OutputDev.Location = new System.Drawing.Point(383, 124);
            this.OutputDev.Name = "OutputDev";
            this.OutputDev.Size = new System.Drawing.Size(121, 24);
            this.OutputDev.TabIndex = 7;
            this.OutputDev.SelectedIndexChanged += new System.EventHandler(this.OutputDev_SelectedIndexChanged);
            // 
            // InputDevLabel
            // 
            this.InputDevLabel.AutoSize = true;
            this.InputDevLabel.Location = new System.Drawing.Point(133, 96);
            this.InputDevLabel.Name = "InputDevLabel";
            this.InputDevLabel.Size = new System.Drawing.Size(81, 16);
            this.InputDevLabel.TabIndex = 8;
            this.InputDevLabel.Text = "Input Device";
            // 
            // OutputDevLabel
            // 
            this.OutputDevLabel.AutoSize = true;
            this.OutputDevLabel.Location = new System.Drawing.Point(380, 96);
            this.OutputDevLabel.Name = "OutputDevLabel";
            this.OutputDevLabel.Size = new System.Drawing.Size(91, 16);
            this.OutputDevLabel.TabIndex = 9;
            this.OutputDevLabel.Text = "Output Device";
            // 
            // AudioProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 513);
            this.Controls.Add(this.OutputDevLabel);
            this.Controls.Add(this.InputDevLabel);
            this.Controls.Add(this.OutputDev);
            this.Controls.Add(this.InputDev);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.VolumeTrackBar);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.MaximumSize = new System.Drawing.Size(663, 560);
            this.MinimumSize = new System.Drawing.Size(663, 560);
            this.Name = "AudioProcessor";
            this.Text = "Audio Processing";
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.TrackBar VolumeTrackBar;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.ComboBox InputDev;
        private System.Windows.Forms.ComboBox OutputDev;
        private System.Windows.Forms.Label InputDevLabel;
        private System.Windows.Forms.Label OutputDevLabel;
    }
}

