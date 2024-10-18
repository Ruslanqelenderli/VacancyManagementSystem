using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VMS.CORE.Concrete.EFCore.Context.DbExtensions;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Context
{
    public class VMSDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public VMSDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServerConnection(configuration["ConnectionString:Prod"]);
        }
        #endregion


        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurations();

        }
        #endregion


        #region DbSet
        public DbSet<ENTITY.Entities.Application.Action> Actions { get; init; }
        public DbSet<Answer> Answers { get; init; }
        public DbSet<ActionAnswer> ActionAnswers { get; init; }
        public DbSet<ApplicationInfo> ApplicationInfos { get; init; }
        public DbSet<Question> Questions { get; init; }
        public DbSet<QuestionBank> QuestionBanks { get; init; }
        public DbSet<QuestionBankQuestion> QuestionBankQuestions { get; init; }
        public DbSet<Vacancy> Vacancies { get; init; }
        public DbSet<WorkType> WorkTypes { get; init; }

        #endregion


    }
}
