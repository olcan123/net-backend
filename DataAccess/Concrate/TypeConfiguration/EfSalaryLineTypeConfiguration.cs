using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrate.TypeConfiguration
{
    public class EfSalaryLineTypeConfiguration : IEntityTypeConfiguration<SalaryLine>
    {
        public void Configure(EntityTypeBuilder<SalaryLine> builder)
        {
            // decimal value change money format
            builder.Property(x=>x.NetSalary).HasColumnType("money");
            builder.Property(x=>x.GrossSalary).HasColumnType("money");
            builder.Property(x=>x.EmployerContribute).HasColumnType("money");
            builder.Property(x=>x.EmployeeContribute).HasColumnType("money");
            builder.Property(x=>x.Tax).HasColumnType("money");
            builder.Property(x=>x.SuppEmpContrib).HasColumnType("money");
            builder.Property(x=>x.SuppEmprContrib).HasColumnType("money");
        }
    }
}