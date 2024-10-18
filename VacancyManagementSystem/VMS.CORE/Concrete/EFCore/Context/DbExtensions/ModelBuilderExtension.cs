using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.CORE.Concrete.EFCore.Context.ApplicationConfigurations;

namespace VMS.CORE.Concrete.EFCore.Context.DbExtensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActionConfiguration());
            modelBuilder.ApplyConfiguration(new ActionAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationInfoConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionBankConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionBankQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new VacancyConfiguration());
        }
    }
}
