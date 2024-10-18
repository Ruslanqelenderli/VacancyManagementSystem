using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Context.ApplicationConfigurations
{
    public class ApplicationInfoConfiguration : IEntityTypeConfiguration<ApplicationInfo>
    {
        public void Configure(EntityTypeBuilder<ApplicationInfo> builder)
        {
            builder.ToTable("APPLICATION_INFOS");

            builder.HasKey(w => w.Id);

            builder.HasQueryFilter(x => !x.IsDeleted);


            builder.Property(w => w.Id)
                   .HasColumnName("ID")
                   .HasColumnType("nvarchar(50)")
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

            builder.Property(e => e.Email)
                   .HasColumnName("Email")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();

            builder.Property(e => e.Name)
                   .HasColumnName("NAME")
                   .HasColumnType("nvarchar(20)")
                   .IsRequired();

            builder.Property(e => e.Surname)
                   .HasColumnName("SURNAME")
                   .HasColumnType("nvarchar(25)")
                   .IsRequired();

            builder.Property(e => e.PhoneNumber)
                   .HasColumnName("PHONE_NUMBER")
                   .HasColumnType("nvarchar(15)")
                   .IsRequired();


        }
    }
}
