using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientProject.Model.Common
{
    internal interface IPatientViewModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime? DateOfBirth { get; set; }
        string Address { get; set; }
        string MobileNumber { get; set; }
    }
}
