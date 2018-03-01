using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundProgramKeeper
{
    public class ProcessTask : IDisposable
    {
        private string m_Name = "";
        private ProcessWrapper m_Process = null;
        private ProcessTaskInfo m_TaskInfo = null;

        public static bool RunCmd(string exec, string args, out string error, out string output)
        {
            bool result = false;

            error = "";
            output = "";

            try
            {
                ProcessStartInfo pinfo = new ProcessStartInfo(exec, args);
                pinfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                pinfo.UseShellExecute = false;
                pinfo.CreateNoWindow = true;
                pinfo.RedirectStandardOutput = true;
                pinfo.RedirectStandardError = true;

                // just need to use system default text encoding
                //pinfo.StandardOutputEncoding = Encoding.UTF8;
                //pinfo.StandardErrorEncoding = Encoding.Default;

                using (Process process = Process.Start(pinfo))
                {
                    using (StreamReader reader = process.StandardError)
                    {
                        error += reader.ReadToEnd();
                    }

                    using (StreamReader reader = process.StandardOutput)
                    {
                        output += reader.ReadToEnd();
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                error += ex.Message;
            }

            return result;
        }

        public ProcessTask(ProcessTaskInfo task)
        {
            m_Name = String.Copy(task.Name);
            m_TaskInfo = new ProcessTaskInfo(task);
            m_Process = new ProcessWrapper(m_TaskInfo.Filepath, m_TaskInfo.Parameters, m_TaskInfo.WorkingDir, 
                                            m_TaskInfo.StopAll != null && m_TaskInfo.StopAll == "true");
            if (m_Process.ProcessState.Length <= 0) CommonLog.Error("Failed to init background program [" + m_Name + "]");
        }

        public void Dispose()
        {
            if (m_Process != null)
            {
                m_Process.Dispose();
                m_Process = null;
            }
        }

        public void Start()
        {
            try
            {
                if (m_Process != null) m_Process.Start();
            }
            catch (Exception ex)
            {
                CommonLog.Error("Failed to start background program [" + m_Name + "]: " + ex.Message);
                CommonLog.Error(ex.StackTrace);
            }
        }

        public void Stop()
        {
            try
            {
                if (m_Process != null) m_Process.Stop();
            }
            catch (Exception ex)
            {
                CommonLog.Error("Failed to stop background program [" + m_Name + "]: " + ex.Message);
                CommonLog.Error(ex.StackTrace);
            }
        }

        public string Name { get { return m_Name; } }

        public ProcessTaskInfo TaskInfo { get { return m_TaskInfo; } }

        public bool IsReady()
        {
            return m_Process != null && m_Process.ProcessState == ProcessWrapper.STATE_READY;
        }

        public bool IsRunning()
        {
            return m_Process != null && m_Process.ProcessState == ProcessWrapper.STATE_RUNNING;
        }
    }

    public class ProcessWrapper : IDisposable
    {
        public const string STATE_READY    = "ready";
        public const string STATE_RUNNING  = "running";
        public const string STATE_STOPPING = "stopping";
        public const string STATE_STOPPED  = "stopped";

        private Process m_RunningProcess = null;

        private string m_ProcessState = "";

        private string m_ExeName = "";

        private bool m_StopAll = false;


        //public Process RunningProcess
        //{
        //    get { return m_RunningProcess; }
        //}

        public string ProcessState
        {
            get 
            {
                lock (m_ProcessState)
                {
                    return String.Copy(m_ProcessState);
                }
            }
        }

        private void OnRunningProcessExited(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Stop();
                }
                catch { }
            });
        }

        public ProcessWrapper(string file, string args, string workingDir = "", bool stopAll = false)
        {
            string fileName = null;
            try
            {
                fileName = Path.GetFileName(file);
                if (fileName != null && fileName.Length > 0)
                {
                    if (!fileName.ToLower().Contains(".exe")) fileName = fileName + ".exe";
                }

                ProcessStartInfo pinfo = new ProcessStartInfo(file, args);

                string dir = workingDir == null ? "" : workingDir.Trim();

                if (dir.Length <= 0) dir = Path.GetDirectoryName(file);
                else
                {
                    dir = dir.Replace('\\', '/');
                    if (dir[0] != '/' && dir.IndexOf(":/") != 1) // if it is not abs path
                    {
                        string folder = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                        if (folder == null || folder.Trim().Length <= 0)
                        {
                            var entry = Assembly.GetEntryAssembly();
                            var location = "";
                            try
                            {
                                if (entry != null) location = entry.Location;
                            }
                            catch { }
                            if (location != null && location.Length > 0)
                            {
                                folder = Path.GetDirectoryName(location);
                            }
                        }
                        if (folder != null && folder.Length > 0) dir = folder.Replace('\\', '/') + "/" + dir;
                    }
                }

                pinfo.WorkingDirectory = dir;
                pinfo.UseShellExecute = false;
                pinfo.RedirectStandardInput = false;
                pinfo.RedirectStandardOutput = false;
                pinfo.RedirectStandardError = false;
                pinfo.CreateNoWindow = true;

                m_RunningProcess = new Process();
                m_RunningProcess.StartInfo = pinfo;
                m_RunningProcess.Exited += new EventHandler(OnRunningProcessExited);

                m_ExeName = fileName;
                m_StopAll = stopAll;
                m_ProcessState = STATE_READY;
            }
            catch (Exception ex)
            {
                CommonLog.Error("Failed to init background program [" + (fileName != null && fileName.Length > 0 ? fileName : file) + "]");
                CommonLog.Error(ex.StackTrace);
            }
        }

        public void Dispose()
        {
            Stop();
        }

        public bool Start()
        {
            if (m_RunningProcess == null) return false;
            else
            {
                lock (m_ProcessState)
                {
                    if (m_ProcessState == STATE_READY)
                    {
                        m_ProcessState = STATE_RUNNING;
                        if (m_RunningProcess != null) m_RunningProcess.Start();
                        if (m_RunningProcess == null || m_RunningProcess.HasExited) m_ProcessState = STATE_READY;
                    } 
                }
                
            }
            return ProcessState == STATE_RUNNING;
        }

        
        public void Stop()
        {
            lock (m_ProcessState)
            {
                if (m_ProcessState != STATE_STOPPING && m_ProcessState != STATE_STOPPED)
                {
                    m_ProcessState = STATE_STOPPING;
                    if (m_RunningProcess != null)
                    {
                        bool killed = false;
                        bool needToKill = false;
                        try
                        {
                            if (!m_RunningProcess.HasExited)
                            {
                                needToKill = true;
                                m_RunningProcess.Kill();
                                if (m_StopAll && m_ExeName != null && m_ExeName.Length > 0)
                                {
                                    var runerror = "";
                                    var runoutput = "";

                                    CommonLog.Info("Try to kill all processes named [" + m_ExeName + "]");

                                    if (ProcessTask.RunCmd("taskkill.exe", "/F /IM \"" + m_ExeName + "\"", out runerror, out runoutput))
                                    {
                                        if (runerror.Length > 0) CommonLog.Error(runerror);
                                        if (runoutput.Length > 0) CommonLog.Info(runoutput);
                                    }
                                    else
                                    {
                                        CommonLog.Error("Failed to kill all processes named [" + m_ExeName + "]");
                                        if (runerror.Length > 0) CommonLog.Error(runerror);
                                        if (runoutput.Length > 0) CommonLog.Error(runoutput);
                                    }
                                }
                                killed = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (needToKill && !killed)
                            {
                                CommonLog.Error("Failed to kill program - " + m_ExeName);
                                CommonLog.Error(ex.StackTrace);
                            }
                        }
                        
                        try
                        {
                            m_RunningProcess.Dispose();
                        }
                        catch { }
                    }
                    m_RunningProcess = null;
                    m_ProcessState = STATE_STOPPED;
                }
            }
        }
    }

    public class ProcessTaskInfo
    {
        public string Name { get; set; }

        public string UpdateTime { get; set; }

        public string WorkingDir { get; set; }

        public string Parameters { get; set; }

        public string Filepath { get; set; }

        public string StopAll { get; set; }


        public ProcessTaskInfo()
        {
            Name = "";
            Filepath = "";
            UpdateTime = "";
            Parameters = "";
            WorkingDir = "";
            StopAll = "";
        }

        public ProcessTaskInfo(ProcessTaskInfo src)
        {
            Name = String.Copy(src.Name);
            Filepath = String.Copy(src.Filepath);
            UpdateTime = String.Copy(src.UpdateTime);
            Parameters = String.Copy(src.Parameters);
            WorkingDir = String.Copy(src.WorkingDir);
            StopAll = String.Copy(src.StopAll);
        }
    }

    public class ProcessTaskGroup
    {
        public List<ProcessTaskInfo> Tasks { get; set; }

        public ProcessTaskGroup()
        {
            Tasks = new List<ProcessTaskInfo>();
        }
    }


}
