using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.Answer;
using VMS.BUSINESS.Helpers.Models.Request.Question;
using VMS.BUSINESS.Helpers.Models.Response.Answer;
using VMS.BUSINESS.Helpers.Models.Response.Question;
using VMS.CORE.Helpers;

namespace VMS.BUSINESS.Abstract
{
    public interface IAnswerService
    {
        Task<BaseValueResponse<AnswerCommonResponse>> CreateAsync(AnswerCreateRequest request);
        Task<BaseValueResponse<AnswerCommonResponse>> UpdateAsync(AnswerUpdateRequest request);
        Task<BaseValueResponse<AnswerCommonResponse>> DeleteAsync(string id);
        Task<BaseValueResponse<AnswerCommonResponse>> GetByIdAsync(string id);
        Task<BaseListResponse<AnswerCommonResponse>> GetByQuestionIdAsync(string questionId);
    }
}
