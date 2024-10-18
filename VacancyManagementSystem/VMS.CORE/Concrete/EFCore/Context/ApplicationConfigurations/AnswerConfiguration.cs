using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Context.ApplicationConfigurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("ANSWERS");

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

            builder.Property(e => e.Description)
                   .HasColumnName("DESCRIPTION")
                   .HasColumnType("nvarchar(max)")
                   .IsRequired();

            builder.Property(e => e.IsCorrect)
                   .HasColumnName("IS_CORRECT")
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(e => e.QuestionId)
                   .HasColumnName("QUESTION_ID")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();

            builder.HasOne(e => e.Question)
                  .WithMany(x=>x.Answers)
                  .HasForeignKey(e => e.QuestionId)
                  .IsRequired();
        }
    }
}
