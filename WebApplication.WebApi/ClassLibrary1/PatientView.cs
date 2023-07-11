using PatientProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientProject.PatientView
{
    public class PatientView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }

        public PatientView(Guid id, string firstName, string lastName, DateTime dateOfBirth, string address, string mobileNumber) 
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            MobileNumber = mobileNumber;
            
        }
    }
}
