using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientProject.Model.Common
{
    public class Sorting
    {
        public Sorting() { }
        public string OrderBy { get; set; }

        public string SortOrder { get; set; }

        public Sorting (string orderBy, string sortOrder)
        {
            OrderBy = orderBy;
            SortOrder = sortOrder;
        }
    }
}
