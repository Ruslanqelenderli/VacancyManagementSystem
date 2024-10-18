using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.Answer;
using VMS.BUSINESS.Helpers.Models.Request.QuestionBank;
using VMS.BUSINESS.Helpers.Models.Response.Answer;
using VMS.CORE.Helpers;

namespace VMS.BUSINESS.Abstract
{
    public interface IQuestionBankService
    {
        Task<BaseValueResponse<bool>> Assign(QuestionBankAssignRequest request);
        Task<BaseValueResponse<bool>> DeleteAssignment(string id);
    }
}
