using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrate
{
    public class Company : IEntity
    {

        public Company()
        {
            Employees = new HashSet<Employee>();
            IsoftAccounts = new HashSet<IsoftAccount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TradeName { get; set; }
        public string UidNumber { get; set; }
        public string? VatNumber { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string RepresentativeName { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<IsoftAccount> IsoftAccounts { get; set; }

    }
}