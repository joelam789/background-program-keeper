using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BrightIdeasSoftware;

namespace BackgroundProgramKeeper
{
    public partial class MainForm : Form
    {
        Keeper m_Keeper = new Keeper();

        public MainForm()
        {
            InitializeComponent();
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public static void ReplaceObject(ObjectListView olv, Object oldObj, Object newObj)
        {
            if (oldObj != null && newObj != null && oldObj != newObj)
            {
                foreach (PropertyDescriptor item in TypeDescriptor.GetProperties(newObj))
                {
                    item.SetValue(oldObj, item.GetValue(newObj));
                }
            }
            if (oldObj != null) olv.UpdateObject(oldObj);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CommonLog.SetGuiControl(this, mmLog);

            try
            {
                var config = m_Keeper.ReloadConfig();

                nudInterval.Value = config.CheckInterval;
                listServiceNames.Items.Clear();
                foreach (var svcname in config.ServiceNames)
                    listServiceNames.Items.Add(svcname);

                var tasks = new List<ProcessTaskInfo>();
                var keys = config.ProcessTasks.Keys;
                foreach (var key in keys) tasks.Add(config.ProcessTasks[key]);
                olvTasks.SetObjects(tasks);

                btnOK.Enabled = false;
                btnCancel.Enabled = false;

                m_Keeper.Start(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit ?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                m_Keeper.Stop();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string svcName = "";
            if (InputBox("Add new service to watch", "Service Name", ref svcName) == DialogResult.OK)
            {
                svcName = svcName.Trim();
                if (svcName.Length > 0)
                {
                    List<string> list = new List<string>();
                    foreach (var item in listServiceNames.Items) list.Add(item.ToString());
                    if (list.IndexOf(svcName) < 0)
                    {
                        listServiceNames.Items.Add(svcName);
                        btnOK.Enabled = true;
                        btnCancel.Enabled = true;
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string svcName = "";
            if (listServiceNames.SelectedIndex >= 0) 
                svcName = listServiceNames.Items[listServiceNames.SelectedIndex].ToString();
            if (svcName.Length > 0)
            {
                DialogResult choice = MessageBox.Show("Do you really want to remove it from watch list: '" + svcName + "' ?",
                                                        "Remove service from watch list", MessageBoxButtons.YesNo);
                if (choice == DialogResult.Yes)
                {
                    listServiceNames.Items.RemoveAt(listServiceNames.SelectedIndex);
                    btnOK.Enabled = true;
                    btnCancel.Enabled = true;
                }
            }
        }

        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var config = m_Keeper.GetConfig();

            nudInterval.Value = config.CheckInterval;
            listServiceNames.Items.Clear();
            foreach (var svcname in config.ServiceNames)
                listServiceNames.Items.Add(svcname);

            var tasks = new List<ProcessTaskInfo>();
            var keys = config.ProcessTasks.Keys;
            foreach (var key in keys) tasks.Add(config.ProcessTasks[key]);
            olvTasks.SetObjects(tasks);

            btnOK.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int interval = Convert.ToInt32(nudInterval.Value);
            List<string> list = new List<string>();
            foreach (var item in listServiceNames.Items) list.Add(item.ToString());
            var tasks = new List<ProcessTaskInfo>();
            foreach (var item in olvTasks.Objects)
            {
                var task = item as ProcessTaskInfo;
                if (task != null) tasks.Add(new ProcessTaskInfo(task));
            }
            m_Keeper.UpdateConfig(interval, list, tasks);

            btnOK.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void menuNotify_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag.ToString() == "1")
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else if (e.ClickedItem.Tag.ToString() == "2")
            {
                Task.Factory.StartNew(() =>
                {
                    BeginInvoke((Action)(() =>
                    {
                        this.Close();
                    }));
                });
            }
        }

        private void notifyIconMain_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            TaskEditForm frmEdit = new TaskEditForm();
            DialogResult result = frmEdit.ShowDialog();
            if (result == DialogResult.OK)
            {
                var newTask = frmEdit.GetTask();
                if (newTask != null)
                {
                    olvTasks.AddObject(newTask);
                    btnOK.Enabled = true;
                    btnCancel.Enabled = true;
                }
            }
        }

        private void btnDelTask_Click(object sender, EventArgs e)
        {
            if (olvTasks.SelectedItem != null)
            {
                var task = olvTasks.SelectedItem.RowObject as ProcessTaskInfo;
                DialogResult choice = MessageBox.Show("Do you really want to remove this program task: '" + task.Name + "' ?",
                                                        "Remove program task", MessageBoxButtons.YesNo);
                if (choice == DialogResult.Yes)
                {
                    olvTasks.RemoveObject(task);
                    btnOK.Enabled = true;
                    btnCancel.Enabled = true;
                }
            }
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (olvTasks.SelectedItem != null)
            {
                var task = olvTasks.SelectedItem.RowObject as ProcessTaskInfo;

                TaskEditForm frmEdit = new TaskEditForm();
                frmEdit.SetTask(task);
                DialogResult result = frmEdit.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var newTask = frmEdit.GetTask();
                    if (newTask != null)
                    {
                        ReplaceObject(olvTasks, task, newTask);
                        btnOK.Enabled = true;
                        btnCancel.Enabled = true;
                    }
                }
            }
        }

        private void olvTasks_DoubleClick(object sender, EventArgs e)
        {
            btnEditTask.PerformClick();
        }

        
    }
}
