using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Xml.Serialization;

namespace TeamFlash
{
    class Program
    {

        public const string ServiceName = "FlashService";

        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                // running as console app
                Start(args);
                Logger.VerboseEnabled = true;

                Stop();
            }
            else
            {
                // running as service
                using (var service = new Service())
                {
                    ServiceBase.Run(service);
                }
            }
        }

        public static void Start(string[] args)
        {
            File.AppendAllText(@"c:\temp\flashservice.txt", String.Format("{0} started{1}", DateTime.Now, Environment.NewLine));
            var thread = new Thread(Flashme);
            thread.Start();
        }

        public static void Stop()
        {
            File.AppendAllText(@"c:\temp\flashservice.txt", String.Format("{0} stopped{1}", DateTime.Now, Environment.NewLine));
            Environment.Exit(0);
        }

        static void Wait(int seconds = 30)
        {
            Logger.Verbose($"Waiting for {seconds} seconds.");
            var delayCount = 0;
            while (delayCount < seconds)
            {
                delayCount++;
                Thread.Sleep(1000);
            }
        }

        public static void Flashme()
        {
#if __MonoCS__
            var buildLight = new Linux.BuildLight();
#else
            var buildLight = new BuildLight();
#endif

            buildLight.Off();

            while (true)
            {
                buildLight.Flash();

                Wait(2);
            }
        }


    }
}
