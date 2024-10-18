using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Action = VMS.ENTITY.Entities.Application.Action;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Context.ApplicationConfigurations
{
    public class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("ACTIONS");
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasKey(w => w.Id);

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

            builder.Property(e => e.Point)
                   .HasColumnName("POINT")
                   .HasColumnType("smallint")        
                   .IsRequired();

            builder.Property(e => e.Percent)
                   .HasColumnName("PERCENT")
                   .HasColumnType("tinyint")         
                   .IsRequired();


            builder.Property(e => e.QuestionBankId)
                   .HasColumnName("QUESTION_BANK_ID")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();

            builder.Property(e => e.CVPath)
                   .HasColumnName("CV_PATH")
                   .HasColumnType("nvarchar(250)")
                   .IsRequired(false);

            builder.HasOne(x => x.ApplicationInfo)
                  .WithOne(z => z.Action)
                  .HasForeignKey<Action>(x => x.Id)
                  .HasPrincipalKey<ApplicationInfo>(x => x.Id)
                  .IsRequired();

            builder.HasOne(e => e.QuestionBank)
                   .WithMany(x=>x.Actions)
                   .HasForeignKey(e => e.QuestionBankId)
                   .IsRequired();
        }
    }
}
