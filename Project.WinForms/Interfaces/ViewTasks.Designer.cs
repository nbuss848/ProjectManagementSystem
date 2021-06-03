
namespace Project.WinForms.Interfaces
{
    partial class frmViewTasks
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
            this.lbHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbHeader.Location = new System.Drawing.Point(184, 9);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(171, 45);
            this.lbHeader.TabIndex = 0;
            this.lbHeader.Text = "[HEADER]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tasks";
            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.ItemHeight = 15;
            this.lstTasks.Location = new System.Drawing.Point(40, 118);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(494, 319);
            this.lstTasks.TabIndex = 2;
            // 
            // btClose
            // 
            this.btClose.AutoEllipsis = true;
            this.btClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btClose.Location = new System.Drawing.Point(442, 443);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(92, 39);
            this.btClose.TabIndex = 11;
            this.btClose.Text = "Ok";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmViewTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 493);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbHeader);
            this.Name = "frmViewTasks";
            this.Text = "Project - View Tasks";
            this.Load += new System.EventHandler(this.frmViewTasks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.Button btClose;
    }
}