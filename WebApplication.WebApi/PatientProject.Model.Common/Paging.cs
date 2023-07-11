using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientProject.Model.Common
{
    public class Paging
    {
        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public Paging(int pageSize, int pageCount)
        {
            PageSize = pageSize;
            PageCount = pageCount;
        }
    }
}
