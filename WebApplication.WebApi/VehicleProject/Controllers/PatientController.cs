using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Formatting;
using Npgsql;
using Service;
using PatientProject.Model;
using PatientProject.PatientView;
using System.Threading.Tasks;
using PatientProject.Model.Common;
using Microsoft.Ajax.Utilities;

namespace VehicleProject.Controllers
{
    public class PatientController : ApiController
    {
        private PersonService personService = new PersonService();

        // GET api/<controller>
        public async Task<HttpResponseMessage> Get(string orderBy = "FirstName", string sortOrder = "asc", int pageSize = 3, int pageCount = 3, DateTime? minDateTime = null, DateTime? maxDateTime = null, string address = "")
        {
            Sorting sorting = new Sorting(orderBy, sortOrder);

            Paging paging = new Paging(pageSize, pageCount);

            Filter filter = new Filter(minDateTime, maxDateTime, address);
   
            List<PatientView> patients = new List<PatientView>();

            List<Patient> mappedPatients = await personService.GetAllAsync(sorting, paging, filter);

            foreach (Patient mappedPatient in mappedPatients)
            {
                PatientView patientView = new PatientView(mappedPatient.Id, mappedPatient.FirstName, mappedPatient.LastName, mappedPatient.DateOfBirth, mappedPatient.Address, mappedPatient.MobileNumber);
                patients.Add(patientView);
            }

            return Request.CreateResponse(HttpStatusCode.OK, patients);
        }

        // GET api/<controller>/5
        public async Task<HttpResponseMessage> GetById(Guid id)
        {
            Patient mappedPatient = await personService.GetPatientByIdAsync(id);

            if (mappedPatient == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There is no person with that id");
            }

            PatientView patient = new PatientView(mappedPatient.Id, mappedPatient.FirstName, mappedPatient.LastName, mappedPatient.DateOfBirth, mappedPatient.Address, mappedPatient.MobileNumber);

            return Request.CreateResponse(HttpStatusCode.OK, patient);
        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody] PatientView patient)
        {
            Guid id = Guid.NewGuid();
            Patient mappedPatient = new Patient
            {
                Id = id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Address = patient.Address,
                DateOfBirth = patient.DateOfBirth,
                MobileNumber = patient.MobileNumber
            };

            int rowsAffected = await personService.PostAsync(mappedPatient);

            if (rowsAffected > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mappedPatient);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> DeleteById(Guid id)
        {
            int rowsAffected = await personService.DeleteAsync(id);

            if (rowsAffected > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient not found");
            }
        }

        public async Task<HttpResponseMessage> Put(Guid id, PatientView patient)
        {
            Patient mappedPatient = await personService.GetPatientByIdAsync(id);

            if (mappedPatient == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient not found");
            }

            if (patient.FirstName != null)
                mappedPatient.FirstName = patient.FirstName;
            if (patient.LastName != null)
                mappedPatient.LastName = patient.LastName;
            if (patient.Address != null)
                mappedPatient.Address = patient.Address;
            if (patient.DateOfBirth != null)
                mappedPatient.DateOfBirth = patient.DateOfBirth;
            if (patient.MobileNumber != null)
                mappedPatient.MobileNumber = patient.MobileNumber;

            int rowsAffected = await personService.PutAsync(mappedPatient.Id, mappedPatient);

            if (rowsAffected > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mappedPatient);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Unable to update patient");
            }
        }
    }
}
