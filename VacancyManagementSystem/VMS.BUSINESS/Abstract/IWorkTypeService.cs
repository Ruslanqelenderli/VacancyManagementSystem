using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.WorkType;
using VMS.BUSINESS.Helpers.Models.Response.WorkType;
using VMS.CORE.Helpers;

namespace VMS.BUSINESS.Abstract
{
    public interface IWorkTypeService
    {
        Task<BaseValueResponse<WorkTypeCommonResponse>> CreateAsync(WorkTypeCreateRequest request);
        Task<BaseListResponse<WorkTypeCommonResponse>> GetAllAsync();
        Task<BaseListResponse<WorkTypeCommonResponse>> GetByPagingAsync(PageRequest<object> request);
        Task<BaseValueResponse<WorkTypeCommonResponse>> UpdateAsync(WorkTypeUpdateRequest request);
        Task<BaseValueResponse<WorkTypeCommonResponse>> DeleteAsync(ushort id);
    }
}
