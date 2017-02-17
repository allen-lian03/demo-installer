using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using Demo.ApplicationServer.Impls;
using Serilog;
using Topshelf;

namespace Demo.ApplicationServer.Hosts
{
    public class WCFHost : ServiceControl
    {
        private readonly ServiceHost _host;
        private readonly ILogger _logger;

        public WCFHost(ILogger logger)
        {
            _logger = logger;
            _host = new WebServiceHost(typeof(PatientService));
        }

        public bool Start(HostControl hostControl)
        {
            try
            {
                _host.Open();

                _logger.Information("WCFHost has started.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Start Error:{0}.", ex.Message);
                return false;
            }

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            try
            {
                _host.Close();

                _logger.Information("WCFHost has stopped.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Stop Error:{0}.", ex.Message);
                return false;
            }

            return true;
        }

        
    }
}