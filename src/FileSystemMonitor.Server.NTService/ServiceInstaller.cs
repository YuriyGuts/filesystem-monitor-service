using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace FileSystemMonitor.Server.NTService
{
    [RunInstaller(true)]
    public partial class ServiceInstaller : Installer
    {
        public ServiceInstaller()
        {
            InitializeComponent();
        }
    }
}