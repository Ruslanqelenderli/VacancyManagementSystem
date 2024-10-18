using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Context.ApplicationConfigurations
{
    public class WorkTypeConfiguration : IEntityTypeConfiguration<WorkType>
    {
        public void Configure(EntityTypeBuilder<WorkType> builder)
        {
            builder.ToTable("WORK_TYPES");

            builder.HasKey(w => w.Id);

            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(w => w.Id)
                   .HasColumnName("ID")
                   .HasColumnType("smallint")
                   .UseIdentityColumn(1, 1)
                   .IsRequired();

            builder.Property(w => w.CreatedDate)
                   .HasColumnName("CREATED_DATE")
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(w => w.UpdatedDate)
                   .HasColumnName("UPDATED_DATE")
                   .IsRequired(false);

            builder.Property(w => w.IsDeleted)
                   .HasColumnName("IS_DELETED")
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(w => w.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
