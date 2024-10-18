using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.Question;
using VMS.BUSINESS.Helpers.Models.Request.WorkType;
using VMS.BUSINESS.Helpers.Models.Response.Answer;
using VMS.BUSINESS.Helpers.Models.Response.Question;
using VMS.BUSINESS.Helpers.Models.Response.WorkType;
using VMS.CORE.Helpers;

namespace VMS.BUSINESS.Abstract
{
    public interface IQuestionService
    {
        Task<BaseValueResponse<QuestionCommonResponse>> CreateAsync(QuestionCreateRequest request);
        Task<BaseValueResponse<QuestionCommonResponse>> UpdateAsync(QuestionUpdateRequest request);
        Task<BaseListResponse<QuestionCommonResponse>> GetByWorkTypeIdAsync(ushort workTypeId);
        Task<BaseListResponse<QuestionCommonResponse>> GetByQuestionBankIdAsync(string questionBankId);
        Task<BaseListResponse<QuestionGetByActionIdResponse>> GetByActionIdAsync(string actionId);
        Task<BaseValueResponse<QuestionCommonResponse>> DeleteAsync(string id);
        Task<BaseValueResponse<QuestionGetByIdResponse>> GetByIdAsync(string id);
        Task<BaseListResponse<QuestionCommonResponse>> GetByPagingAsync(PageRequest<object> request);
    }
}
