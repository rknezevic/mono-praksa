using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientProject.Model;
using PersonRepository;
using Service.Common;

namespace Service
{
    public class PersonService : IPersonService
    {
        PatientRepository repository = new PatientRepository();

        public PersonService(PatientRepository repository)
        {
            this.repository = repository;
        }

        public PersonService() { }

        public List<Patient> GetAll()
        {
            return repository.GetPatients();
        }

        public Patient GetPatientById(Guid id) 
        {
            return repository.GetPatientById(id);
        }

        public int Post(Patient patient)
        {
            return repository.Post(patient);
        }
        public int Delete(Guid id)
        {
            return repository.Delete(id);
        }

        public int Put(Guid id,Patient patient)
        {
            return repository.Put(id, patient);
        }
    }
}
