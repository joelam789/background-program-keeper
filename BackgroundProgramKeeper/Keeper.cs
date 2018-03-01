using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

using Newtonsoft.Json;

namespace BackgroundProgramKeeper
{
    public class Keeper
    {
        private KeeperConfig m_Config = new KeeperConfig();
        private bool m_Running = false;
        private bool m_HasUI = Environment.UserInteractive;
        private Timer m_Timer = null;

        private Dictionary<string, ProcessTask> m_ProcessTasks = new Dictionary<string, ProcessTask>();

        public void UpdateConfig(int checkInterval, List<string> serviceNames = null, List<ProcessTaskInfo> programTasks = null)
        {
            var isRunning = m_Timer != null;
            if (isRunning) Stop();
            lock (m_Config)
            {
                if (checkInterval > 0) m_Config.CheckInterval = checkInterval;
                if (serviceNames != null)
                {
                    m_Config.ServiceNames.Clear();
                    m_Config.ServiceNames.AddRange(serviceNames);
                }
                if (programTasks != null)
                {
                    m_Config.ProcessTasks.Clear();
                    foreach (var task in programTasks) m_Config.ProcessTasks.Add(task.Name, task);
                }
            }
            if (isRunning) Start(false);
        }

        public KeeperConfig GetConfig()
        {
            KeeperConfig config = new KeeperConfig();
            lock (m_Config)
            {
                config.CheckInterval = m_Config.CheckInterval;
                config.ServiceNames.AddRange(m_Config.ServiceNames);
                config.ProcessTasks = new Dictionary<string, ProcessTaskInfo>(m_Config.ProcessTasks);
            }
            return config;
        }

        public KeeperConfig ReloadConfig()
        {
            try
            {
                lock (m_Config)
                {
                    ConfigurationManager.RefreshSection("appSettings");

                    var appSettings = (NameValueCollection)ConfigurationManager.GetSection("appSettings");

                    if (appSettings.AllKeys.Contains("CheckInterval")) m_Config.CheckInterval = Convert.ToInt32(appSettings["CheckInterval"]);

                    if (appSettings.AllKeys.Contains("ServiceNames"))
                    {
                        var svcNameStr = appSettings["ServiceNames"].ToString().Trim();
                        string[] svcNames = svcNameStr.Length > 0 ? svcNameStr.Split(',') : new string[0];
                        m_Config.ServiceNames.Clear();
                        foreach (var svcname in svcNames) m_Config.ServiceNames.Add(svcname.Trim());
                    }

                    if (appSettings.AllKeys.Contains("ProgramGroup"))
                    {
                        var groupStr = appSettings["ProgramGroup"].ToString().Trim();
                        var taskGroup = JsonConvert.DeserializeObject<ProcessTaskGroup>(groupStr);
                        m_Config.ProcessTasks.Clear();
                        if (taskGroup != null && taskGroup.Tasks.Count > 0)
                        {
                            foreach (var task in taskGroup.Tasks) m_Config.ProcessTasks.Add(task.Name, task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonLog.Error("Failed to load settings from app config: " + ex.Message);
                CommonLog.Error(ex.StackTrace);
            }
            return GetConfig();
        }

        public void Stop()
        {
            if (m_Timer != null)
            {
                m_Timer.Dispose();
                m_Timer = null;
            }
            lock (m_ProcessTasks)
            {
                foreach (var item in m_ProcessTasks) item.Value.Stop();
                m_ProcessTasks.Clear();
            }
            m_Running = false;
        }

        public void Start(bool reloadConfig = true)
        {
            Stop();
            if (reloadConfig) ReloadConfig();
            m_Timer = new Timer(TryToKeepBackgroundProgramsRunning, m_Config, 500, 1000 * m_Config.CheckInterval);
        }

        private void TryToKeepBackgroundProgramsRunning(Object config)
        {
            if (m_Running) return;
            m_Running = true;
            try
            {
                if (!m_HasUI) ReloadConfig();
                TryToKeepServicesRunning(config);
                TryToKeepProgramsRunning(config);
            }
            finally
            {
                m_Running = false;
            }
        }

        private void TryToKeepServicesRunning(Object config)
        {
            var serviceNames = new List<string>();
            lock (m_Config) serviceNames.AddRange(m_Config.ServiceNames);

            var error = "";
            var output = "";

            if (ProcessTask.RunCmd("net", "start", out error, out output))
            {
                //CommonLog.Error(error);
                //CommonLog.Info(output);

                var missingNames = new List<string>();
                var currentNames = new List<string>();
                var currentSvcNames = output.Trim().Split('\n');
                foreach (var currentSvcName in currentSvcNames)
                {
                    currentNames.Add(currentSvcName.Trim());
                }
                foreach (var svcname in serviceNames)
                {
                    if (currentNames.IndexOf(svcname) < 0) missingNames.Add(svcname);
                }

                foreach (var svcname in missingNames)
                {
                    var runerror = "";
                    var runoutput = "";

                    CommonLog.Info("Try to start service - " + svcname);

                    if (ProcessTask.RunCmd("net", "start \"" + svcname + "\"", out runerror, out runoutput))
                    {
                        if (runerror.Length > 0) CommonLog.Error(runerror);
                        if (runoutput.Length > 0) CommonLog.Info(runoutput);
                    }
                    else
                    {
                        CommonLog.Error("Failed to start service - " + svcname);
                        CommonLog.Error(runoutput);
                    }
                }

            }
            else
            {
                CommonLog.Error("Failed to get running service list");
                CommonLog.Error(error);
            }
        }

        private void TryToKeepProgramsRunning(Object config)
        {
            Dictionary<string, ProcessTaskInfo> configTasks = null;
            lock (m_Config) configTasks = new Dictionary<string, ProcessTaskInfo>(m_Config.ProcessTasks);

            lock (m_ProcessTasks)
            {
                var keys = new List<string>();
                keys.AddRange(m_ProcessTasks.Keys);

                foreach (var key in keys)
                {
                    if (!configTasks.ContainsKey(key))
                    {
                        m_ProcessTasks[key].Stop();
                        m_ProcessTasks.Remove(key);
                        CommonLog.Info("Removed program - " + key);
                    }
                }

                keys.Clear();
                keys.AddRange(configTasks.Keys);

                foreach (var key in keys)
                {
                    if (m_ProcessTasks.ContainsKey(key))
                    {
                        // check if need to update it
                        var task = m_ProcessTasks[key];

                        //CommonLog.Info("task.TaskInfo.UpdateTime - " + task.TaskInfo.UpdateTime);
                        //CommonLog.Info("configTasks[key].UpdateTime - " + configTasks[key].UpdateTime);

                        if (!task.IsRunning() || String.Compare(configTasks[key].UpdateTime, task.TaskInfo.UpdateTime) == 1)
                        {
                            task.Stop();
                            m_ProcessTasks.Remove(key);
                            CommonLog.Info("Need to restart program - " + key);
                        }
                    }

                    if (!m_ProcessTasks.ContainsKey(key))
                    {
                        // create new 
                        CommonLog.Info("Try to start program - " + key);
                        var newTask = new ProcessTask(configTasks[key]);
                        if (newTask != null && newTask.IsReady())
                        {
                            newTask.Start();
                            if (newTask.IsRunning())
                            {
                                m_ProcessTasks.Add(key, newTask);
                                CommonLog.Info("Started program - " + key);
                            }
                        }
                    }

                    if (!m_ProcessTasks.ContainsKey(key))
                    {
                        CommonLog.Error("Failed to start program - " + key);
                    }
                }
            }
        }
    }

    public class KeeperConfig
    {
        public int CheckInterval { get; set; }
        public List<string> ServiceNames { get; set; }
        public Dictionary<string, ProcessTaskInfo> ProcessTasks { get; set; }

        public KeeperConfig()
        {
            CheckInterval = 5;
            ServiceNames = new List<string>();
            ProcessTasks = new Dictionary<string, ProcessTaskInfo>();
        }
    }
}
