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
        List<Patient> GetAll();


        Patient GetPatientById(Guid id);


        int Post(Patient patient);

        int Delete(Guid id);
        
    }
}
