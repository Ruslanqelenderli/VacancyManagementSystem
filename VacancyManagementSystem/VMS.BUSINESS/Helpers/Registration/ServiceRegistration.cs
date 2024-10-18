using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Concrete;
using VMS.BUSINESS.Helpers.AutoMapper;
using VMS.CORE.Abstract;
using VMS.CORE.Concrete.EFCore.Context;
using VMS.CORE.Concrete.EFCore.Repository;

namespace VMS.BUSINESS.Helpers.Registration
{
    public static class ServiceRegistration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IWorkTypeRepository, WorkTypeRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionBankRepository, QuestionBankRepository>();
            services.AddScoped<IQuestionBankQuestionRepository, QuestionBankQuestionRepository>();
            services.AddScoped<IApplicationInfoRepository, ApplicationInfoRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IActionRepository, ActionRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IWorkTypeService, WorkTypeService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IApplicationInfoService, ApplicationInfoService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IActionService, ActionService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IActionAnswerService, ActionAnswerService>();
            services.AddScoped<IQuestionBankService, QuestionBankService>();


            services.AddAutoMapper(typeof(ApplicationProfile));
            services.AddDbContext<VMSDbContext>();
        }
    }
}
