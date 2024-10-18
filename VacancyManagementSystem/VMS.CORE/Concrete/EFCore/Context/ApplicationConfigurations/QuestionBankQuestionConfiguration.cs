using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Context.ApplicationConfigurations
{
    public class QuestionBankQuestionConfiguration : IEntityTypeConfiguration<QuestionBankQuestion>
    {
        public void Configure(EntityTypeBuilder<QuestionBankQuestion> builder)
        {
            builder.ToTable("QUESTION_BANK_QUESTIONS");

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


            builder.Property(e => e.QuestionBankId)
                   .HasColumnName("QUESTION_BANK_ID")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();

            builder.Property(e => e.QuestionId)
                   .HasColumnName("QUESTION_ID")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();

            builder.HasOne(e => e.Question)
                  .WithMany(x=>x.QuestionBankQuestions)
                  .HasForeignKey(e => e.QuestionId)
                  .IsRequired();

            builder.HasOne(e => e.QuestionBank)
                 .WithMany(x => x.QuestionBankQuestions)
                 .HasForeignKey(e => e.QuestionBankId)
                 .IsRequired();
        }
    }
}
