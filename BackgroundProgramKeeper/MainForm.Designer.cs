namespace BackgroundProgramKeeper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.pageSettings = new System.Windows.Forms.TabPage();
            this.gbPrograms = new System.Windows.Forms.GroupBox();
            this.olvTasks = new BrightIdeasSoftware.FastObjectListView();
            this.colTaskName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colFilepath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colParams = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colWorkingDir = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colStopAll = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colUpdateTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pnlTop2 = new System.Windows.Forms.Panel();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.btnDelTask = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.gbServiceNames = new System.Windows.Forms.GroupBox();
            this.listServiceNames = new System.Windows.Forms.ListBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbCheckInterval = new System.Windows.Forms.GroupBox();
            this.lblTimeUnit = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.pageLog = new System.Windows.Forms.TabPage();
            this.mmLog = new System.Windows.Forms.RichTextBox();
            this.menuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.tcMain.SuspendLayout();
            this.pageSettings.SuspendLayout();
            this.gbPrograms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvTasks)).BeginInit();
            this.pnlTop2.SuspendLayout();
            this.gbServiceNames.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.gbCheckInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.pageLog.SuspendLayout();
            this.menuNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(300, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(209, 453);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.pageSettings);
            this.tcMain.Controls.Add(this.pageLog);
            this.tcMain.Location = new System.Drawing.Point(12, 13);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(367, 421);
            this.tcMain.TabIndex = 4;
            // 
            // pageSettings
            // 
            this.pageSettings.Controls.Add(this.gbPrograms);
            this.pageSettings.Controls.Add(this.gbServiceNames);
            this.pageSettings.Controls.Add(this.gbCheckInterval);
            this.pageSettings.Location = new System.Drawing.Point(4, 22);
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.pageSettings.Size = new System.Drawing.Size(359, 395);
            this.pageSettings.TabIndex = 0;
            this.pageSettings.Text = "Settings";
            this.pageSettings.UseVisualStyleBackColor = true;
            // 
            // gbPrograms
            // 
            this.gbPrograms.Controls.Add(this.olvTasks);
            this.gbPrograms.Controls.Add(this.pnlTop2);
            this.gbPrograms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPrograms.Location = new System.Drawing.Point(3, 208);
            this.gbPrograms.Name = "gbPrograms";
            this.gbPrograms.Size = new System.Drawing.Size(353, 184);
            this.gbPrograms.TabIndex = 17;
            this.gbPrograms.TabStop = false;
            this.gbPrograms.Text = "Programs";
            // 
            // olvTasks
            // 
            this.olvTasks.AllColumns.Add(this.colTaskName);
            this.olvTasks.AllColumns.Add(this.colFilepath);
            this.olvTasks.AllColumns.Add(this.colParams);
            this.olvTasks.AllColumns.Add(this.colWorkingDir);
            this.olvTasks.AllColumns.Add(this.colStopAll);
            this.olvTasks.AllColumns.Add(this.colUpdateTime);
            this.olvTasks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTaskName,
            this.colFilepath,
            this.colParams,
            this.colWorkingDir,
            this.colStopAll,
            this.colUpdateTime});
            this.olvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvTasks.FullRowSelect = true;
            this.olvTasks.HasCollapsibleGroups = false;
            this.olvTasks.Location = new System.Drawing.Point(3, 49);
            this.olvTasks.Name = "olvTasks";
            this.olvTasks.ShowGroups = false;
            this.olvTasks.Size = new System.Drawing.Size(347, 132);
            this.olvTasks.TabIndex = 16;
            this.olvTasks.UseCompatibleStateImageBehavior = false;
            this.olvTasks.View = System.Windows.Forms.View.Details;
            this.olvTasks.VirtualMode = true;
            this.olvTasks.DoubleClick += new System.EventHandler(this.olvTasks_DoubleClick);
            // 
            // colTaskName
            // 
            this.colTaskName.AspectName = "Name";
            this.colTaskName.Text = "Name";
            this.colTaskName.Width = 80;
            // 
            // colFilepath
            // 
            this.colFilepath.AspectName = "Filepath";
            this.colFilepath.Text = "Filepath";
            this.colFilepath.Width = 180;
            // 
            // colParams
            // 
            this.colParams.AspectName = "Parameters";
            this.colParams.Text = "Parameters";
            this.colParams.Width = 180;
            // 
            // colWorkingDir
            // 
            this.colWorkingDir.AspectName = "WorkingDir";
            this.colWorkingDir.Text = "Working Directory";
            this.colWorkingDir.Width = 150;
            // 
            // colStopAll
            // 
            this.colStopAll.AspectName = "StopAll";
            this.colStopAll.Text = "Stop All";
            this.colStopAll.Width = 80;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.AspectName = "UpdateTime";
            this.colUpdateTime.Text = "UpdateTime";
            this.colUpdateTime.Width = 150;
            // 
            // pnlTop2
            // 
            this.pnlTop2.Controls.Add(this.btnEditTask);
            this.pnlTop2.Controls.Add(this.btnDelTask);
            this.pnlTop2.Controls.Add(this.btnAddTask);
            this.pnlTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop2.Location = new System.Drawing.Point(3, 16);
            this.pnlTop2.Name = "pnlTop2";
            this.pnlTop2.Size = new System.Drawing.Size(347, 33);
            this.pnlTop2.TabIndex = 15;
            // 
            // btnEditTask
            // 
            this.btnEditTask.Location = new System.Drawing.Point(165, 3);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(75, 23);
            this.btnEditTask.TabIndex = 2;
            this.btnEditTask.Text = "Edit";
            this.btnEditTask.UseVisualStyleBackColor = true;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // btnDelTask
            // 
            this.btnDelTask.Location = new System.Drawing.Point(84, 3);
            this.btnDelTask.Name = "btnDelTask";
            this.btnDelTask.Size = new System.Drawing.Size(75, 25);
            this.btnDelTask.TabIndex = 1;
            this.btnDelTask.Text = "Delete";
            this.btnDelTask.UseVisualStyleBackColor = true;
            this.btnDelTask.Click += new System.EventHandler(this.btnDelTask_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(3, 3);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 25);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "Add";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // gbServiceNames
            // 
            this.gbServiceNames.Controls.Add(this.listServiceNames);
            this.gbServiceNames.Controls.Add(this.pnlTop);
            this.gbServiceNames.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbServiceNames.Location = new System.Drawing.Point(3, 65);
            this.gbServiceNames.Name = "gbServiceNames";
            this.gbServiceNames.Size = new System.Drawing.Size(353, 143);
            this.gbServiceNames.TabIndex = 16;
            this.gbServiceNames.TabStop = false;
            this.gbServiceNames.Text = "Service Names";
            // 
            // listServiceNames
            // 
            this.listServiceNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listServiceNames.FormattingEnabled = true;
            this.listServiceNames.Location = new System.Drawing.Point(3, 49);
            this.listServiceNames.Name = "listServiceNames";
            this.listServiceNames.Size = new System.Drawing.Size(347, 91);
            this.listServiceNames.TabIndex = 15;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnDel);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(3, 16);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(347, 33);
            this.pnlTop.TabIndex = 14;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(84, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 25);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbCheckInterval
            // 
            this.gbCheckInterval.Controls.Add(this.lblTimeUnit);
            this.gbCheckInterval.Controls.Add(this.nudInterval);
            this.gbCheckInterval.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCheckInterval.Location = new System.Drawing.Point(3, 3);
            this.gbCheckInterval.Name = "gbCheckInterval";
            this.gbCheckInterval.Size = new System.Drawing.Size(353, 62);
            this.gbCheckInterval.TabIndex = 15;
            this.gbCheckInterval.TabStop = false;
            this.gbCheckInterval.Text = "Check Interval";
            // 
            // lblTimeUnit
            // 
            this.lblTimeUnit.AutoSize = true;
            this.lblTimeUnit.Location = new System.Drawing.Point(240, 25);
            this.lblTimeUnit.Name = "lblTimeUnit";
            this.lblTimeUnit.Size = new System.Drawing.Size(47, 13);
            this.lblTimeUnit.TabIndex = 12;
            this.lblTimeUnit.Text = "seconds";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(87, 23);
            this.nudInterval.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(146, 20);
            this.nudInterval.TabIndex = 11;
            this.nudInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudInterval.ValueChanged += new System.EventHandler(this.nudInterval_ValueChanged);
            // 
            // pageLog
            // 
            this.pageLog.Controls.Add(this.mmLog);
            this.pageLog.Location = new System.Drawing.Point(4, 22);
            this.pageLog.Name = "pageLog";
            this.pageLog.Padding = new System.Windows.Forms.Padding(3);
            this.pageLog.Size = new System.Drawing.Size(359, 395);
            this.pageLog.TabIndex = 1;
            this.pageLog.Text = "Log";
            this.pageLog.UseVisualStyleBackColor = true;
            // 
            // mmLog
            // 
            this.mmLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mmLog.Location = new System.Drawing.Point(3, 3);
            this.mmLog.Name = "mmLog";
            this.mmLog.Size = new System.Drawing.Size(353, 389);
            this.mmLog.TabIndex = 0;
            this.mmLog.Text = "";
            // 
            // menuNotify
            // 
            this.menuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuNotify.Name = "menuNotify";
            this.menuNotify.Size = new System.Drawing.Size(104, 48);
            this.menuNotify.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuNotify_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem1.Tag = "1";
            this.toolStripMenuItem1.Text = "Show";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem2.Tag = "2";
            this.toolStripMenuItem2.Text = "Exit";
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.menuNotify;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Background Program Keeper";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.DoubleClick += new System.EventHandler(this.notifyIconMain_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 499);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Background Program Keeper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tcMain.ResumeLayout(false);
            this.pageSettings.ResumeLayout(false);
            this.gbPrograms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvTasks)).EndInit();
            this.pnlTop2.ResumeLayout(false);
            this.gbServiceNames.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.gbCheckInterval.ResumeLayout(false);
            this.gbCheckInterval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.pageLog.ResumeLayout(false);
            this.menuNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage pageSettings;
        private System.Windows.Forms.GroupBox gbServiceNames;
        private System.Windows.Forms.ListBox listServiceNames;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbCheckInterval;
        private System.Windows.Forms.Label lblTimeUnit;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.TabPage pageLog;
        private System.Windows.Forms.RichTextBox mmLog;
        private System.Windows.Forms.ContextMenuStrip menuNotify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.GroupBox gbPrograms;
        private System.Windows.Forms.Panel pnlTop2;
        private System.Windows.Forms.Button btnDelTask;
        private System.Windows.Forms.Button btnAddTask;
        private BrightIdeasSoftware.FastObjectListView olvTasks;
        private BrightIdeasSoftware.OLVColumn colTaskName;
        private BrightIdeasSoftware.OLVColumn colFilepath;
        private BrightIdeasSoftware.OLVColumn colParams;
        private BrightIdeasSoftware.OLVColumn colWorkingDir;
        private BrightIdeasSoftware.OLVColumn colUpdateTime;
        private System.Windows.Forms.Button btnEditTask;
        private BrightIdeasSoftware.OLVColumn colStopAll;
    }
}

