using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.Answer;
using VMS.BUSINESS.Helpers.Models.Request.Vacancy;
using VMS.BUSINESS.Helpers.Models.Response.Answer;
using VMS.BUSINESS.Helpers.Models.Response.Vacancy;
using VMS.BUSINESS.Helpers.Models.Response.WorkType;
using VMS.CORE.Abstract;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Application;

namespace VMS.BUSINESS.Concrete
{
    public class VacancyService : IVacancyService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public VacancyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseValueResponse<VacancyCommonResponse>> CreateAsync(VacancyCreateRequest request)
        {
            var vacancy = mapper.Map<Vacancy>(request);
            vacancy.Id = Guid.NewGuid().ToString();
            vacancy.IsActive = true;
            var result = unitOfWork.Vacancies.Add(vacancy);
            unitOfWork.QuestionBanks.Add(new QuestionBank(vacancy.Id));
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<VacancyCommonResponse>>(result);
        }

        public async Task<BaseValueResponse<VacancyCommonResponse>> DeleteAsync(string id)
        {
            var result = unitOfWork.Vacancies.DeleteSoft(id);
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<VacancyCommonResponse>>(result);
        }

        public async Task<BaseValueResponse<VacancyCommonResponse>> UpdateAsync(VacancyUpdateRequest request)
        {
            var result = unitOfWork.Vacancies.Update(mapper.Map<Vacancy>(request));
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<VacancyCommonResponse>>(result);
        }

        public async Task<BaseListResponse<VacancyCommonResponse>> GetByPagingAsync(PageRequest<object> request)
        {
            var result = await unitOfWork.Vacancies.GetAsync(null, true, x=>x.Include(z=>z.WorkType), new PageRequest<Vacancy>()
            {
                PageSize = request.PageSize,
                CurrentPage = request.CurrentPage
            },
            null,
            x => x.CreatedDate
            );
            return mapper.Map<BaseListResponse<VacancyCommonResponse>>(result);
        }

        public async Task<BaseListResponse<VacancyCommonResponse>> GetByPagingOutAsync(PageRequest<object> request)
        {
            var result = await unitOfWork.Vacancies.GetAsync(new List<System.Linq.Expressions.Expression<Func<Vacancy, bool>>>()
            {
                x=>x.IsActive && x.StartDate.Date < DateTime.Now.Date && x.EndDate.Date >= DateTime.Now.Date
            }, true, x => x.Include(z => z.WorkType), new PageRequest<Vacancy>()
            {
                PageSize = request.PageSize,
                CurrentPage = request.CurrentPage
            },
            null,
            x => x.CreatedDate
            );
            return mapper.Map<BaseListResponse<VacancyCommonResponse>>(result);
        }

        public async Task<BaseValueResponse<VacancyCommonResponse>> GetByIdAsync(string id)
        {
            var result = await unitOfWork.Vacancies.GetByIdAsync(new List<System.Linq.Expressions.Expression<Func<Vacancy, bool>>>()
            {
                x=>x.Id == id
            });

            return mapper.Map<BaseValueResponse<VacancyCommonResponse>>(result);
        }
    }
}
