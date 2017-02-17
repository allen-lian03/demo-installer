using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Demo.ClientLibs.Utils;
using Demo.ServerLibs.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo.ClientLibs
{
    /// <summary>
    /// Interaction logic for UcPatientList.xaml
    /// </summary>
    public partial class UcPatientList : UserControl
    {
        private readonly ObservableCollection<PatientDTO> _patients;
         
        public UcPatientList()
        {
            InitializeComponent();
            _patients = new ObservableCollection<PatientDTO>();
        }

        private void OnRefreshClick(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            var address = new Uri(WCFAddress.BaseAddress);
            client.GetStringAsync(new Uri(address, "patients/all"))
                .ContinueWith(t =>
                {
                    if (t.Exception != null)
                    {
                        throw t.Exception;
                    }

                    if (string.IsNullOrWhiteSpace(t.Result))
                    {
                        _patients.Clear();
                        return;
                    }

                    var result = JObject.Parse(t.Result);
                    var list = result["GetAllPatientsResult"];
                    var ps = JsonConvert.DeserializeObject<List<PatientDTO>>(list.ToString());
                    foreach (var dto in ps)
                    {
                        _patients.Add(dto);
                    }
                    dgPatients.ItemsSource = _patients;
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
