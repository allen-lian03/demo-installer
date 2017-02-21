using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Demo.Initialization
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string InstallationRootDir { get; private set; }

        public bool ClientInstalled { get; private set; }

        public bool ServerInstalled { get; private set; }
        

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        
            if (e.Args.Length > 0)
            {
                InstallationRootDir = e.Args[0];
            }
            else
            {
                InstallationRootDir = Registry.CurrentUser
                    .OpenSubKey(@"Software\Microsoft\DemoInstaller")
                    .GetValue("InstallRootPath", string.Empty).ToString();
            }

            if (string.IsNullOrWhiteSpace(InstallationRootDir))
            {
                MessageBox.Show("No found installation root path. The program will close.");
                Shutdown();
                return;
            }

            var client = new FileInfo(Path.Combine(InstallationRootDir,
                    "DemoClient", "Demo.ApplicationClient.exe"));
            ClientInstalled = client.Exists;

            var server = new FileInfo(Path.Combine(InstallationRootDir,
                "DemoClient", "Demo.ApplicationClient.exe"));
            ServerInstalled = server.Exists;
        }
    }
}
