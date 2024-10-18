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
    public class ActionAnswerConfiguration : IEntityTypeConfiguration<ActionAnswer>
    {
        public void Configure(EntityTypeBuilder<ActionAnswer> builder)
        {
            builder.ToTable("ACTION_ANSWERS");
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

            builder.Property(e => e.ActionId)
                   .HasColumnName("ACTION_ID")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();

            builder.Property(e => e.AnswerId)
                   .HasColumnName("ANSWER_ID")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired(false);

            builder.Property(e => e.QuestionId)
                   .HasColumnName("QUESTION_ID")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();

            builder.HasOne(e => e.Answer)
                   .WithMany(x=>x.ActionAnswers)
                   .HasForeignKey(e => e.AnswerId)
                   .IsRequired(false);

            builder.HasOne(e => e.Question)
                   .WithMany(x=>x.ActionAnswers)
                   .HasForeignKey(e => e.QuestionId)
                   .IsRequired(false);

            builder.HasOne(e => e.Action)
                   .WithMany(x=>x.ActionAnswers)
                   .HasForeignKey(e => e.ActionId)
                   .IsRequired(false);
        }
    }
}
