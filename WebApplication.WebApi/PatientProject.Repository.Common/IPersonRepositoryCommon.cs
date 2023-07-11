using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientProject.Model;
using Npgsql;
using System.Web.Http;

namespace PatientProject.IPersonRepository.Common
{
    public interface IPersonRepositoryCommon
    {
        Task<Patient> GetPatientByIdAsync(Guid id);
        Task<List<Patient>> GetPatientsAsync();
        Patient ReadPatient(NpgsqlDataReader reader);
        Task<int> PostAsync([FromBody] Patient patient);
        Task<int> PutAsync(Guid id, [FromBody] Patient patient);
    }
}
