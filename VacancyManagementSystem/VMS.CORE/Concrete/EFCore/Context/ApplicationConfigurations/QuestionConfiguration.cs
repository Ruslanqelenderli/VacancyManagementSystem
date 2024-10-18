using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Context.ApplicationConfigurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("QUESTIONS");

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

            builder.Property(e => e.Description)
                   .HasColumnName("DESCRIPTION")
                   .HasColumnType("nvarchar(max)")
                   .IsRequired();

            builder.Property(e => e.WorkTypeId)
                   .HasColumnName("WORK_TYPE_ID")
                   .HasColumnType("smallint")
                   .IsRequired();


            builder.HasOne(e => e.WorkType)
                  .WithMany(x=>x.Questions)
                  .HasForeignKey(e => e.WorkTypeId)
                  .IsRequired();
        }
    }
}
