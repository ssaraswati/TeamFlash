﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;


namespace TeamFlash
{
    class Service : ServiceBase
    {
        public Service()
        {
            ServiceName = Program.ServiceName;
        }

        protected override void OnStart(string[] args)
        {
            Program.Start(args);
        }

        protected override void OnStop()
        {
            Program.Stop();
        }
    }
}
