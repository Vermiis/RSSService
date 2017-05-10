using RSSService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSService
{
    static class Program
    {
        //git shell try
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

#if DEBUG

            RSSService myService = new RSSService();
            myService.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            //sync
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new RSSService()

            };
            ServiceBase.Run(ServicesToRun);
   
#endif
        }


    }
}
