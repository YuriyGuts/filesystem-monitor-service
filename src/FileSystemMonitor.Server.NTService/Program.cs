//#define StartAsApplication

#if StartAsApplication
#else
using System.ServiceProcess;
#endif

namespace FileSystemMonitor.Server.NTService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

#if StartAsApplication
			StartAsApplication();
#else
            StartAsService();
#endif

        }

#if StartAsApplication
		private static void StartAsApplication()
		{
			(new FileSystemMonitorService()).ServiceEntryPoint();
		}
#else
        private static void StartAsService()
        {
            ServiceBase[] servicesToRun;
            servicesToRun = new ServiceBase[] { new FileSystemMonitorService() };
            ServiceBase.Run(servicesToRun);
        }
#endif

    }
}