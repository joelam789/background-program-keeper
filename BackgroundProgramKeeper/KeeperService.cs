using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace BackgroundProgramKeeper
{
    partial class KeeperService : ServiceBase
    {
        Keeper m_Keeper = new Keeper();

        public KeeperService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.

            CommonLog.Info("=== " + Program.SVC_NAME + " is starting ===");

            m_Keeper.Start();

        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.

            m_Keeper.Stop();

            CommonLog.Info("=== " + Program.SVC_NAME + " stopped ===");
        }
    }
}
