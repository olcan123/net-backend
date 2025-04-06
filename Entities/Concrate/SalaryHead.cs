using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrate
{
    public class SalaryHead : IEntity
    {
        public SalaryHead()
        {
            SalaryLines = new HashSet<SalaryLine>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Period { get; set; }
        public string Note { get; set; }


        public Company? Company { get; set; }
        public ICollection<SalaryLine>? SalaryLines { get; set; }

    }
}