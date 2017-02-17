using Demo.ApplicationServer.Hosts;
using Serilog;
using Topshelf;

namespace Demo.ApplicationServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .WriteTo.RollingFile("logs\\demo-{Date}.log")
                .CreateLogger();

            HostFactory.Run(x =>
            {
                x.Service<WCFHost>(s =>
                {
                    s.ConstructUsing(f => new WCFHost(logger));
                    s.WhenStarted((h, c) => h.Start(c));
                    s.WhenStopped((h, c) => h.Stop(c));
                });

                x.SetServiceName("DemoWCFHost");
                x.SetDescription("Demo WCF Host");
                x.SetDisplayName("Demo WCF Host");
                x.UseSerilog(logger);
                x.RunAsLocalSystem();
            });
        }
    }
}
