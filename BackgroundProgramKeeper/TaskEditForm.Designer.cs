namespace BackgroundProgramKeeper
{
    partial class TaskEditForm
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
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.edtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtFilepath = new System.Windows.Forms.TextBox();
            this.edtParam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtWorkingDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.edtUpdateTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtStopAll = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.btnClose);
            this.gbActions.Controls.Add(this.btnSave);
            this.gbActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbActions.Location = new System.Drawing.Point(0, 189);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(484, 62);
            this.gbActions.TabIndex = 7;
            this.gbActions.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(387, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(288, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(121, 27);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(341, 20);
            this.edtName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Filepath";
            // 
            // edtFilepath
            // 
            this.edtFilepath.Location = new System.Drawing.Point(121, 53);
            this.edtFilepath.Name = "edtFilepath";
            this.edtFilepath.Size = new System.Drawing.Size(341, 20);
            this.edtFilepath.TabIndex = 11;
            // 
            // edtParam
            // 
            this.edtParam.Location = new System.Drawing.Point(121, 79);
            this.edtParam.Name = "edtParam";
            this.edtParam.Size = new System.Drawing.Size(341, 20);
            this.edtParam.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Parameters";
            // 
            // edtWorkingDir
            // 
            this.edtWorkingDir.Location = new System.Drawing.Point(121, 105);
            this.edtWorkingDir.Name = "edtWorkingDir";
            this.edtWorkingDir.Size = new System.Drawing.Size(341, 20);
            this.edtWorkingDir.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Working Directory";
            // 
            // edtUpdateTime
            // 
            this.edtUpdateTime.Location = new System.Drawing.Point(121, 157);
            this.edtUpdateTime.Name = "edtUpdateTime";
            this.edtUpdateTime.Size = new System.Drawing.Size(341, 20);
            this.edtUpdateTime.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Update Time";
            // 
            // edtStopAll
            // 
            this.edtStopAll.Location = new System.Drawing.Point(121, 131);
            this.edtStopAll.Name = "edtStopAll";
            this.edtStopAll.Size = new System.Drawing.Size(341, 20);
            this.edtStopAll.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Stop All";
            // 
            // TaskEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 251);
            this.Controls.Add(this.edtStopAll);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtUpdateTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.edtParam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edtWorkingDir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.edtFilepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbActions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TaskEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Info";
            this.Load += new System.EventHandler(this.TaskEditForm_Load);
            this.gbActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtFilepath;
        private System.Windows.Forms.TextBox edtParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtWorkingDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtUpdateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edtStopAll;
        private System.Windows.Forms.Label label6;
    }
}