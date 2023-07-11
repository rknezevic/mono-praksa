using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PatientProject.Model;
using Npgsql;
using System.Web.Http;
using PatientProject.IPersonRepository.Common;

namespace PersonRepository
{
    public class PatientRepository : IPatientRepositoryCommon
    {
        private static string connection = "Server=localhost; Port=5432; User Id=postgres; Password=knezevic10; Database=postgres";

        public async Task<List<Patient>> GetPatientsAsync()
        {
            List<Patient> patients = new List<Patient>();

            using (NpgsqlConnection conn = new NpgsqlConnection(connection))
            {
                await conn.OpenAsync();

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Patient", conn);
                NpgsqlDataReader dr = await cmd.ExecuteReaderAsync();

                if (dr.HasRows)
                {
                    while (await dr.ReadAsync())
                    {
                        Patient patient = ReadPatient(dr);
                        patients.Add(patient);
                    }
                }

                dr.Close();
                conn.Close();
            }

            return patients;
        }

        public async Task<Patient> GetPatientByIdAsync(Guid id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connection))
            {
                await conn.OpenAsync();

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Patient WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("Id", id);

                using (NpgsqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        return ReadPatient(dr);
                    }
                }

                conn.Close();
            }

            return null;
        }

        public async Task<int> PostAsync(Patient patient)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connection))
            {
                await conn.OpenAsync();
                Guid id = Guid.NewGuid();

                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO Patient(Id, FirstName, LastName, DateOfBirth, Address, MobileNumber) VALUES (@Id, @FirstName, @LastName, @DateOfBirth, @Address, @MobileNumber)", conn);
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("LastName", patient.LastName);
                cmd.Parameters.AddWithValue("DateOfBirth", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("Address", patient.Address);
                cmd.Parameters.AddWithValue("MobileNumber", patient.MobileNumber);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                conn.Close();

                return rowsAffected;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            Patient existingPatient = await GetPatientByIdAsync(id);

            if (existingPatient == null)
            {
                Console.WriteLine("There is no patient with that id");
                return -3;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(connection))
            {
                await conn.OpenAsync();

                NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM Patient WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("Id", id);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                conn.Close();

                return rowsAffected;
            }
        }

        public async Task<int> PutAsync(Guid id, Patient patient)
        {
            Patient existingPatient = await GetPatientByIdAsync(id);

            if (existingPatient == null)
            {
                return -1;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(connection))
            {
                await conn.OpenAsync();

                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE Patient SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Address = @Address, MobileNumber = @MobileNumber WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@MobileNumber", patient.MobileNumber);
                cmd.Parameters.AddWithValue("@Id", id);

                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                conn.Close();

                return rowsAffected;
            }
        }

         public Patient ReadPatient(NpgsqlDataReader reader)
        {
            Guid id = (Guid)reader["Id"];
            string firstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? null : (string)reader["FirstName"];
            string lastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? null : (string)reader["LastName"];
            DateTime dateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? DateTime.MinValue : (DateTime)reader["DateOfBirth"];
            string address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : (string)reader["Address"];
            string mobileNumber = reader.IsDBNull(reader.GetOrdinal("MobileNumber")) ? null : (string)reader["MobileNumber"];

            Patient patient = new Patient
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Address = address,
                MobileNumber = mobileNumber
            };

            return patient;
        }

    }
}
