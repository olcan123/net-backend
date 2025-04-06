using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrate;

namespace WebAPI.Models
{
    public class SalaryModel
    {
        public SalaryHead SalaryHead { get; set; }
        public List<SalaryLine> SalaryLines { get; set; }
    }

    public class CreateSalary
    {
    }
}