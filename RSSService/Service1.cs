using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace RSSService
{
    public partial class RSSService : ServiceBase
    {
        public RSSService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");
            RSSReader.Getter.xmel();
        }

        protected override void OnStop()
        {
        }
    }
}
