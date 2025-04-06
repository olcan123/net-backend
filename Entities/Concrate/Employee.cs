using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrate
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NationalIdentity { get; set; }
        public int? IsoftId { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? EducationLevel { get; set; }
        public EmploymentType? EmployementType { get; set; } = EmploymentType.FullTime;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool IsActive { get; set; } = true;


        public Company? Company { get; set; }

        public enum EmploymentType
        {
            FullTime,
            PartTime,
            Contractor
        }
    }


}