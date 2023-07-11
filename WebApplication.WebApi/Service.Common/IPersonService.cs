using PatientProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IPersonService
    {
        Task<List<Patient>> GetAllAsync();

        Task <Patient> GetPatientByIdAsync(Guid id);

        Task<int> PostAsync(Patient patient);

        Task<int> DeleteAsync(Guid id);
        
    }
}
