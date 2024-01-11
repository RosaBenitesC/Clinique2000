using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class PatientService : ServiceBaseAsync<Patient>, IPatientService
    {

        public PatientService(Clinique2000DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IReadOnlyList<Patient>> GetAllIndexAsync()
        {
            return await _db.Set<Patient>().OrderBy(p => p.Nom).ToListAsync();
        }

        bool IPatientService.PatientExist(string numeroAssurance)
        {
            var PatientMemeAssurance = _db.Patients.Where(m => m.NumeroAssuranceMaladie == numeroAssurance).Any();
            return PatientMemeAssurance;
        }

    }
}
