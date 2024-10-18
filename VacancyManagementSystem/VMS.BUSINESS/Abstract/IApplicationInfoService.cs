using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.ApplicationInfo;
using VMS.BUSINESS.Helpers.Models.Request.Question;
using VMS.BUSINESS.Helpers.Models.Response.Action;
using VMS.BUSINESS.Helpers.Models.Response.Question;
using VMS.CORE.Helpers;

namespace VMS.BUSINESS.Abstract
{
    public interface IApplicationInfoService
    {
        Task<BaseValueResponse<ActionApplyResponse>> ApplyCreateAsync(ApplicationInfoCreateRequest request);
    }
}
