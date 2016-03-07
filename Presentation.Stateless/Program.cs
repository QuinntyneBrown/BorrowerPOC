using System;
using System.Diagnostics;
using System.Fabric;
using System.Threading;

namespace Presentation.Stateless
{
    internal static class Program
    {
        private static int counter = 0;

        private static object sync = new object();
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            if(counter == 0)
            lock (sync)
            {
                if (counter == 0)
                {
                        counter++;
                        LaunchService();
                }
            }
            
        }

        private static void LaunchService()
        {
            try
            {
                // Creating a FabricRuntime connects this host process to the Service Fabric runtime.
                using (FabricRuntime fabricRuntime = FabricRuntime.Create())
                {
                    // The ServiceManifest.XML file defines one or more service type names.
                    // RegisterServiceType maps a service type name to a .NET class.
                    // When Service Fabric creates an instance of this service type,
                    // an instance of the class is created in this host process.
                    
                    fabricRuntime.RegisterServiceType("PresentationMicroserviceBorrowerServiceType", typeof(BorrowerService));

                    ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(BorrowerService).Name);

                    Thread.Sleep(Timeout.Infinite);  // Prevents this host process from terminating so services keeps running.
                }
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
