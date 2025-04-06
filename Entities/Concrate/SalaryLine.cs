using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrate
{
    public class SalaryLine : IEntity
    {
        public int Id { get; set; }
        public int SalaryHeadId { get; set; }
        public int EmployeeId { get; set; }
        public decimal NetSalary { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal Tax { get; set; }
        public decimal EmployeeContribute { get; set; }
        public decimal EmployerContribute { get; set; }
        public decimal SuppEmpContrib { get; set; }
        public decimal SuppEmprContrib { get; set; }

        // Flags
        public bool IsPrimary { get; set; } = true;
        public bool ContribIncluded { get; set; } = true;
        public bool TaxApplied { get; set; } = true;

        public SalaryHead? SalaryHead { get; set; }
        public Employee? Employee { get; set; }
    }
}