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
using ClassLibrary1;

namespace VehicleProject.Controllers

{
    public class PatientController : ApiController
    {
        public PersonService personService = new PersonService();

        // GET api/<controller>
        public HttpResponseMessage Get()
        {

            List<Patient> patients = personService.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, patients);

        }



        // GET api/<controller>/5
        public HttpResponseMessage GetById(Guid id)
        {
            Patient patient = personService.GetPatientById(id);

            if (patient == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "There is no person with that id");
            }

            return Request.CreateResponse(HttpStatusCode.OK, patient);


        }


        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] PatientView patient)
        {
            Guid Id = Guid.NewGuid();
            Patient mappedPatient = new Patient();
            mappedPatient.Id = Id;
            mappedPatient.FirstName = patient.FirstName;
            mappedPatient.LastName = patient.LastName;
            mappedPatient.Address = patient.Address;
            mappedPatient.DateOfBirth = patient.DateOfBirth;
            mappedPatient.MobileNumber = patient.MobileNumber;

            int rowsAffected = personService.Post(mappedPatient);

            if (rowsAffected > 0)
                return Request.CreateResponse(HttpStatusCode.OK, mappedPatient);

            else return Request.CreateResponse(HttpStatusCode.BadRequest);


        }

        public HttpResponseMessage DeleteById(Guid id)
        {            
            PersonService personService = new PersonService();  

            int rowsAffected = personService.Delete(id);

            if (rowsAffected > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted! ");
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "Patient not found");
            
        }

        public HttpResponseMessage Put(Guid id, PatientView patient)
        {
            PersonService personService = new PersonService();
            Patient mappedPatient = personService.GetPatientById(id);

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
            if(patient.DateOfBirth != null)
                mappedPatient.DateOfBirth = patient.DateOfBirth;
            if(patient.MobileNumber != null)
                mappedPatient.MobileNumber = patient.MobileNumber;

            int rowsAffected = personService.Put(mappedPatient.Id, mappedPatient);

            if (rowsAffected > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mappedPatient);
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Unable to update patient");
            
        }
    }
}

       

/*

        // PUT api/<controller>/5
        public HttpResponseMessage Put(Guid id, [FromBody] PatientView patient)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=knezevic10; Database=postgres"))
            {
                conn.Open();

                // Fetch existing patient record from the database
                Patient existingPatient = GetPatientById(id);

                if (existingPatient == null)
                {
                    conn.Close();
                  
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Patient record updated successfully
                    return Request.CreateResponse(HttpStatusCode.OK, existingPatient);
                }
                else
                {
                    // Failed to update patient record
                    conn.Close();
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to update patient record.");
                }
            }  return Request.CreateResponse(HttpStatusCode.NotFound, "No patient found with the specified ID.");
                }

                // Update the patient record in the database
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE Patient SET FirstName = COALESCE(@FirstName, FirstName), LastName = COALESCE(@LastName, LastName), DateOfBirth = COALESCE(@DateOfBirth, DateOfBirth), Address = COALESCE(@Address, Address), MobileNumber = COALESCE(@MobileNumber, MobileNumber) WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("FirstName", patient.FirstName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("LastName", patient.LastName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("DateOfBirth", patient.DateOfBirth != DateTime.MinValue ? patient.DateOfBirth : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("Address", patient.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("MobileNumber", patient.MobileNumber ?? (object)DBNull.Value);

       
        }
       
        [HttpGet]
        [Route("api/patients/{id}")]
        public Patient GetPatientById(Guid id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=knezevic10; Database=postgres"))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Patient WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("Id", id);

                using (NpgsqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        Patient patient = ReadPatient(dr);

                        return patient;
                    }
                   
                }

            }
            return null;
        }
       
        

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(Guid id)
        {
            Patient existingPatient = GetPatientById(id);
            if(existingPatient == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error not found");
            }

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=knezevic10; Database=postgres"))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM Patient WHERE Id = (@id)", conn);


                cmd.Parameters.AddWithValue("Id", id);

                int check = cmd.ExecuteNonQuery();
                if(check > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
        }
    }
}*/