using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.Action;
using VMS.BUSINESS.Helpers.Models.Response.Action;
using VMS.BUSINESS.Helpers.Models.Response.Answer;
using VMS.BUSINESS.Helpers.Models.Response.Question;
using VMS.CORE.Helpers;

namespace VMS.BUSINESS.Abstract
{
    public interface IActionService
    {
        Task<BaseValueResponse<bool>> Complete(ActionCompleteRequest request);
        Task<BaseListResponse<ActionPagingResponse>> GetByPagingAsync(PageRequest<object> request);
        Task<BaseValueResponse<ActionGetByIdResponse>> GetByIdAsync(string id);


    }
}
