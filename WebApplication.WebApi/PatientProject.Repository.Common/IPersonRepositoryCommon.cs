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
        Patient GetPatientById(Guid id);
        List<Patient> GetPatients();
        Patient ReadPatient(NpgsqlDataReader reader);
        int Post([FromBody] Patient patient);
        int Put(Guid id, [FromBody] Patient patient);
    }
}
