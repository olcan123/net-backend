using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrate.TypeConfiguration
{
    public class EfSalaryHeadTypeConfiguration : IEntityTypeConfiguration<SalaryHead>
    {
        public void Configure(EntityTypeBuilder<SalaryHead> builder)
        {
            builder.Property(x=>x.Period).HasColumnType("char(7)");
        }
    }
}