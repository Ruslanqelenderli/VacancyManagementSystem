using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.Answer;
using VMS.BUSINESS.Helpers.Models.Request.Vacancy;
using VMS.BUSINESS.Helpers.Models.Response.Answer;
using VMS.BUSINESS.Helpers.Models.Response.Vacancy;
using VMS.BUSINESS.Helpers.Models.Response.WorkType;
using VMS.CORE.Helpers;

namespace VMS.BUSINESS.Abstract
{
    public interface IVacancyService
    {
        Task<BaseValueResponse<VacancyCommonResponse>> CreateAsync(VacancyCreateRequest request);
        Task<BaseValueResponse<VacancyCommonResponse>> UpdateAsync(VacancyUpdateRequest request);
        Task<BaseValueResponse<VacancyCommonResponse>> DeleteAsync(string id);
        Task<BaseListResponse<VacancyCommonResponse>> GetByPagingAsync(PageRequest<object> request);
        Task<BaseListResponse<VacancyCommonResponse>> GetByPagingOutAsync(PageRequest<object> request);
        Task<BaseValueResponse<VacancyCommonResponse>> GetByIdAsync(string id);
        //Task<BaseListResponse<AnswerCommonResponse>> GetByQuestionIdAsync(string questionId);
    }
}
