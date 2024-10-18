using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.ActionAnswer;
using VMS.CORE.Helpers;

namespace VMS.BUSINESS.Abstract
{
    public interface IActionAnswerService
    {
        Task<BaseValueResponse<bool>> ToAnswer(ActionAnswerToAnswerRequest request);
    }
}
