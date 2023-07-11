using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientProject.Model.Common
{
    public class Filter
    {
       
        public DateTime? MinDateTime { get; set; }
        public DateTime? MaxDateTime { get; set; }

        public string Address { get; set; }

        public Filter(DateTime? minDateTime, DateTime? maxDateTime, string address)
        {
            MinDateTime = minDateTime;
            MaxDateTime = maxDateTime;
            Address = address;
        }

    }
}
