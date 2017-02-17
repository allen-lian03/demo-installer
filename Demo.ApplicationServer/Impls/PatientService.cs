using System;
using System.Collections.Generic;
using Demo.ServerLibs.Contracts;
using Demo.ServerLibs.Models;

namespace Demo.ApplicationServer.Impls
{
    public class PatientService : IPatientService
    {
        public List<PatientDTO> GetAllPatients()
        {
            var list = new List<PatientDTO>
            {
                new PatientDTO { Id = Guid.Parse("{BE1E7ABB-E17A-4BD9-A6B6-D16CA8378B40}"), Name = "Allen", Birthday = new DateTime(1981, 1, 10), CardNo = "A00001", IC = "I9874" },
                new PatientDTO { Id = Guid.Parse("{BE1E7ABB-E17A-4BD9-A6B6-D16CA8378B41}"), Name = "Alice", Birthday = new DateTime(1992, 2, 11), CardNo = "B00002", IC = "I9875" },
                new PatientDTO { Id = Guid.Parse("{BE1E7ABB-E17A-4BD9-A6B6-D16CA8378B42}"), Name = "Bill", Birthday = new DateTime(1983, 3, 12), CardNo = "C00003", IC = "I9884" },
                new PatientDTO { Id = Guid.Parse("{BE1E7ABB-E17A-4BD9-A6B6-D16CA8378B43}"), Name = "Trump", Birthday = new DateTime(1994, 4, 13), CardNo = "D00004", IC = "I9974" },
                new PatientDTO { Id = Guid.Parse("{BE1E7ABB-E17A-4BD9-A6B6-D16CA8378B44}"), Name = "William", Birthday = new DateTime(1985, 5, 14), CardNo = "E00011", IC = "I2874" }
            };

            return list;
        }
    }
}