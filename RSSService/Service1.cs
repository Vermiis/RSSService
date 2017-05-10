using RSSReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSService
{
    public partial class RSSService : ServiceBase
    {
        public RSSService()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            TimerClass.SetTimer();
            TimerClass._timer.Start();
            //System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            TimerClass._timer.Stop();
        }

        protected override void OnStop()
        {
        }
    }
}
