﻿namespace KeyEvents
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
            labelOutput = new Label();
            SuspendLayout();
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Location = new Point(12, 23);
            labelOutput.MaximumSize = new Size(650, 0);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(45, 15);
            labelOutput.TabIndex = 0;
            labelOutput.Text = "Output";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(labelOutput);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "KeyPress";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyPress += Form1_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxInput;
        private Label labelOutput;
    }
}