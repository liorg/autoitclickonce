namespace WinformDemo
{
    partial class WinformDemo
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
            this.lblClipBoard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblClipBoard
            // 
            this.lblClipBoard.AutoSize = true;
            this.lblClipBoard.Location = new System.Drawing.Point(90, 81);
            this.lblClipBoard.Name = "lblClipBoard";
            this.lblClipBoard.Size = new System.Drawing.Size(16, 13);
            this.lblClipBoard.TabIndex = 0;
            this.lblClipBoard.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblClipBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClipBoard;
    }
}

