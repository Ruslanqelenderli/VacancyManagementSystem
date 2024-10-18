using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.ApplicationInfo;
using VMS.BUSINESS.Helpers.Models.Response.Action;
using VMS.BUSINESS.Helpers.Validator.ApplicationInfo;
using VMS.CORE.Abstract;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Application;
using Action = VMS.ENTITY.Entities.Application.Action;

namespace VMS.BUSINESS.Concrete
{
    public class ApplicationInfoService : IApplicationInfoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ApplicationInfoService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseValueResponse<ActionApplyResponse>> ApplyCreateAsync(ApplicationInfoCreateRequest request)
        {
            ApplicationInfoCreateRequestValidator validator = new ApplicationInfoCreateRequestValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                var errors = new List<string>();
                result.Errors.ForEach(x =>
                {
                    errors.Add(x.ErrorMessage);
                });
                return new BaseValueResponse<ActionApplyResponse>(errors);
            }
            var vacancy = await unitOfWork.Vacancies.GetByIdAsync(new List<System.Linq.Expressions.Expression<Func<Vacancy, bool>>>()
            {
                x=>x.Id == request.VacancyId
            });
            var applicationInfo = mapper.Map<ApplicationInfo>(request);
            applicationInfo.Id = Guid.NewGuid().ToString();
            var applicationInfoSaveResult = unitOfWork.ApplicationInfos.Add(applicationInfo);
            var actionSaveResult = unitOfWork.Actions.Add(new Action()
            {
                Id = applicationInfoSaveResult.Value.Id,
                QuestionBankId = vacancy.Value.Id
            });
            var randomQuestions = await unitOfWork.QuestionBankQuestions
                .Query()
                .Include(x=>x.Question)
                .Where(x => x.QuestionBankId == vacancy.Value.Id)
                .OrderBy(x => Guid.NewGuid())
                .Take(vacancy.Value.QuestionCount)
                .ToListAsync();
            randomQuestions.ForEach(x =>
            {
                unitOfWork.ActionAnswers.Add(new ActionAnswer()
                {
                    Id = Guid.NewGuid().ToString(),
                    ActionId = applicationInfoSaveResult.Value.Id,
                    QuestionId = x.QuestionId
                });
            });

            await unitOfWork.SaveAsync();

            return new BaseValueResponse<ActionApplyResponse>(mapper.Map<ActionApplyResponse>(actionSaveResult.Value));
            
        }
    }
}
