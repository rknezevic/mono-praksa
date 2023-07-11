using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientProject.Model;
using PersonRepository;
using Service.Common;
using Autofac;

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

        public async Task<List<Patient>> GetAllAsync()
        {
            return await repository.GetPatientsAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(Guid id) 
        {
            return await repository.GetPatientByIdAsync(id);
        }

        public async Task<int> PostAsync(Patient patient)
        {
            return await repository.PostAsync(patient);
        }
        public async Task<int> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<int> PutAsync(Guid id,Patient patient)
        {
            return await repository.PutAsync(id, patient);
        }
    }
}
