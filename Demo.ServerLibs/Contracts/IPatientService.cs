using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Demo.ServerLibs.Models;

namespace Demo.ServerLibs.Contracts
{
    [ServiceContract]
    public interface IPatientService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "all", 
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<PatientDTO> GetAllPatients();
    }
}
