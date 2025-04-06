using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrate
{
    public class IsoftAccount : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeAccount { get; set; }
        public string TaxAccount { get; set; }
        public string ContributeAccount { get; set; }
        public string GrossAccount { get; set; }
        public string EmployerContributeAccount { get; set; }

        public Company? Company { get; set; }
    }
}