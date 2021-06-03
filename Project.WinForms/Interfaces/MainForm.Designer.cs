
namespace Project.WinForms
{
    partial class MainForm
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
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpMain
            // 
            this.flpMain.AutoScroll = true;
            this.flpMain.Location = new System.Drawing.Point(114, 12);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(938, 426);
            this.flpMain.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 450);
            this.Controls.Add(this.flpMain);
            this.Name = "MainForm";
            this.Text = "Project - WinForms";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMain;
    }
}