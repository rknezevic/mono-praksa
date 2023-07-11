using PatientProject.Model;
using PatientProject.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IPersonService
    {
        Task<List<Patient>> GetAllAsync(Sorting sorting, Paging paging, Filter filter);

        Task <Patient> GetPatientByIdAsync(Guid id);

        Task<int> PostAsync(Patient patient);

        Task<int> DeleteAsync(Guid id);
        
    }
}
