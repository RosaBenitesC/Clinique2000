using Clinique2000_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services.IServices
{
    public interface IPatientService : IServiceBaseAsync<Patient>
    {
        public Task<IReadOnlyList<Patient>> GetAllIndexAsync();
        bool PatientExist(string name);
    }
}
