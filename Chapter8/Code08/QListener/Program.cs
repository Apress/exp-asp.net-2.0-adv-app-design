using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace QListener
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new ListenerSvc() };
            ServiceBase.Run(ServicesToRun);
        }
    }
}