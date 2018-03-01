using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BackgroundProgramKeeper
{
    public partial class TaskEditForm : Form
    {
        ProcessTaskInfo m_TaskInfo = null;

        public TaskEditForm()
        {
            InitializeComponent();
        }

        private void TaskEditForm_Load(object sender, EventArgs e)
        {
            m_TaskInfo = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_TaskInfo = new ProcessTaskInfo();
            m_TaskInfo.Name = edtName.Text;
            m_TaskInfo.Filepath = edtFilepath.Text;
            m_TaskInfo.Parameters = edtParam.Text;
            m_TaskInfo.WorkingDir = edtWorkingDir.Text;
            m_TaskInfo.UpdateTime = edtUpdateTime.Text;
            m_TaskInfo.StopAll = edtStopAll.Text;

            this.DialogResult = DialogResult.OK;
        }

        public void SetTask(ProcessTaskInfo taskInfo)
        {
            m_TaskInfo = new ProcessTaskInfo(taskInfo);

            edtName.Text = m_TaskInfo.Name;
            edtFilepath.Text = m_TaskInfo.Filepath;
            edtParam.Text = m_TaskInfo.Parameters;
            edtWorkingDir.Text = m_TaskInfo.WorkingDir;
            edtUpdateTime.Text = m_TaskInfo.UpdateTime;
            edtStopAll.Text = m_TaskInfo.StopAll;
        }

        public ProcessTaskInfo GetTask()
        {
            return m_TaskInfo == null ? null : new ProcessTaskInfo(m_TaskInfo);
        }
    }
}
