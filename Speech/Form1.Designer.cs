﻿namespace Speech
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.LstCommands = new System.Windows.Forms.ListBox();
            this.TmrSpeaking = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // LstCommands
            // 
            this.LstCommands.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.LstCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstCommands.FormattingEnabled = true;
            this.LstCommands.Location = new System.Drawing.Point(0, 0);
            this.LstCommands.Name = "LstCommands";
            this.LstCommands.Size = new System.Drawing.Size(398, 347);
            this.LstCommands.TabIndex = 0;
            // 
            // TmrSpeaking
            // 
            this.TmrSpeaking.Enabled = true;
            this.TmrSpeaking.Interval = 1000;
            this.TmrSpeaking.Tick += new System.EventHandler(this.TmrSpeaking_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(398, 347);
            this.Controls.Add(this.LstCommands);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox LstCommands;
        private System.Windows.Forms.Timer TmrSpeaking;
    }
}

