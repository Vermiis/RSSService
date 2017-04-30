using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

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
            //sync
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new RSSService()

            };
            ServiceBase.Run(ServicesToRun);
        }


    }
}
