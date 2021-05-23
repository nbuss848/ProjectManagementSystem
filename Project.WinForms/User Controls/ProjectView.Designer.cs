
namespace Project.WinForms
{
    partial class ProjectViewListing
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.NumberOfTasks = new System.Windows.Forms.Label();
            this.btAddTask = new System.Windows.Forms.Button();
            this.btViewTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(95, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(58, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(18, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number Of Tasks:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbName.Location = new System.Drawing.Point(156, 39);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(114, 21);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "[Project Name]";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Description.Location = new System.Drawing.Point(156, 74);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(151, 21);
            this.Description.TabIndex = 4;
            this.Description.Text = "[Project Description]";
            // 
            // NumberOfTasks
            // 
            this.NumberOfTasks.AutoSize = true;
            this.NumberOfTasks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumberOfTasks.Location = new System.Drawing.Point(156, 110);
            this.NumberOfTasks.Name = "NumberOfTasks";
            this.NumberOfTasks.Size = new System.Drawing.Size(0, 21);
            this.NumberOfTasks.TabIndex = 5;
            // 
            // btAddTask
            // 
            this.btAddTask.AutoEllipsis = true;
            this.btAddTask.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btAddTask.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btAddTask.Location = new System.Drawing.Point(458, 145);
            this.btAddTask.Name = "btAddTask";
            this.btAddTask.Size = new System.Drawing.Size(92, 33);
            this.btAddTask.TabIndex = 6;
            this.btAddTask.Text = "Add Task";
            this.btAddTask.UseVisualStyleBackColor = false;
            this.btAddTask.Click += new System.EventHandler(this.btAddTask_Click);
            // 
            // btViewTask
            // 
            this.btViewTask.AutoEllipsis = true;
            this.btViewTask.BackColor = System.Drawing.Color.White;
            this.btViewTask.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btViewTask.Location = new System.Drawing.Point(598, 145);
            this.btViewTask.Name = "btViewTask";
            this.btViewTask.Size = new System.Drawing.Size(105, 33);
            this.btViewTask.TabIndex = 7;
            this.btViewTask.Text = "View Tasks";
            this.btViewTask.UseVisualStyleBackColor = false;
            this.btViewTask.Click += new System.EventHandler(this.btViewTask_Click);
            // 
            // ProjectViewListing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btViewTask);
            this.Controls.Add(this.btAddTask);
            this.Controls.Add(this.NumberOfTasks);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProjectViewListing";
            this.Size = new System.Drawing.Size(713, 188);
            this.Load += new System.EventHandler(this.ProjectView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
       // private System.Windows.Forms.Label Name;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label NumberOfTasks;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btAddTask;
        private System.Windows.Forms.Button btViewTask;
    }
}
