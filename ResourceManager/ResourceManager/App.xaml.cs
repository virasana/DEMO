using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using LoggingLib;
using Microsoft.Owin.Hosting;
using ResourcesWebApiHost;

namespace ResourceManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static void InitialiseWebApi()
        {
            var baseUri = ConfigurationManager.AppSettings["ResourcesManagerWebApiUrl"];

            WebApp.Start<Startup>(baseUri);
            LoggingService.Instance.WriteLine(string.Format("Server running at {0} - press Enter to quit.", baseUri));
            var psi = new ProcessStartInfo("chrome.exe", (ConfigurationManager.AppSettings["AppUrl"] + " " + "--start-fullscreen"));
            Process.Start(psi);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            InitialiseWebApi();
            base.OnStartup(e);
        }
    }
}
