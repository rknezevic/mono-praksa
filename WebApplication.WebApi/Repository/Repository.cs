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
using ClassLibrary1;

namespace PersonRepository
{

    public class PatientRepository : IPersonRepositoryCommon
    {
        public static string connection = "Server=localhost; Port=5432; User Id=postgres; Password=knezevic10; Database=postgres";


        public List<Patient> GetPatients()
        {

            List<Patient> Patients = new List<Patient>();
            using (NpgsqlConnection conn = new NpgsqlConnection(connection))
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Patient", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Patient patient = new Patient
                        {
                            Id = (Guid)dr["Id"],
                            FirstName = dr.IsDBNull(dr.GetOrdinal("FirstName")) ? null : (string)dr["FirstName"],
                            LastName = dr.IsDBNull(dr.GetOrdinal("LastName")) ? null : (string)dr["LastName"],
                            DateOfBirth = dr.IsDBNull(dr.GetOrdinal("DateOfBirth")) ? DateTime.MinValue : (DateTime)dr["DateOfBirth"],
                            Address = dr.IsDBNull(dr.GetOrdinal("Address")) ? null : (string)dr["Address"],
                            MobileNumber = dr.IsDBNull(dr.GetOrdinal("MobileNumber")) ? null : (string)dr["MobileNumber"]
                        };

                        Patients.Add(patient);
                    }
                    return Patients;
                }
                else
                {
                    dr.Close();
                    conn.Close();
                    return null;
                }

            }

        }
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
                        return ReadPatient(dr);

                    }
                    else
                    {
                        dr.Close();
                        conn.Close();
                        return null;
                    }
                }

            }

        }

        public Patient ReadPatient(NpgsqlDataReader reader)
        {
            if (reader.HasRows && reader.Read())
            {
                Guid id = (Guid)reader["Id"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];
                string address = (string)reader["Address"];
                string mobileNumber = (string)reader["MobileNumber"];

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
            else
            {
                Console.WriteLine("Kurac dragi gledaoci");
                throw new Exception("No patient data available.");
            }
        }
        public int Post([FromBody] Patient patient)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=knezevic10; Database=postgres"))
            {
                conn.Open();
                Guid id = Guid.NewGuid();

                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO Patient(id, FirstName, LastName, DateOfBirth, Address, MobileNumber)" + "VALUES (@id, @FirstName, @LastName, @DateOfBirth, @Address, @MobileNumber)", conn);


                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("LastName", patient.LastName);
                cmd.Parameters.AddWithValue("DateOfBirth", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("Address", patient.Address);
                cmd.Parameters.AddWithValue("MobileNumber", patient.MobileNumber);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Patient record updated successfully
                    return rowsAffected;
                }
                else
                {
                    // Failed to update patient record
                    conn.Close();
                    return rowsAffected;
                }

            }

        }
        // DELETE api/<controller>/5
        public int Delete(Guid id)
        {
            Patient existingPatient = GetPatientById(id);


            if (existingPatient == null)
            {
                Console.WriteLine("There is no patient with that id");
                return -3;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(connection))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM Patient WHERE Id = (@id)", conn);


                cmd.Parameters.AddWithValue("Id", id);

                int rawsAffected = cmd.ExecuteNonQuery();
                if (rawsAffected > 0)
                {
                    return rawsAffected;
                }
                else
                {
                    Console.WriteLine("Error");
                    return rawsAffected;
                }

            }

        }

        public int Put(Guid id, [FromBody] Patient patient)
        {
            Patient mappedPatient = GetPatientById(id);

            if (mappedPatient == null)
            {
                return -1;
            }

            using (NpgsqlConnection conn = new NpgsqlConnection(connection))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE Patient SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Address = @Address, MobileNumber = @MobileNumber WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
                cmd.Parameters.AddWithValue("@LastName", patient.LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@MobileNumber", patient.MobileNumber);
                cmd.Parameters.AddWithValue("@Id", id);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected;
            }

        }


        
    }
}



