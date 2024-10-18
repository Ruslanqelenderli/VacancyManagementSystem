using AutoMapper;
using Azure.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.WorkType;
using VMS.BUSINESS.Helpers.Models.Response.WorkType;
using VMS.CORE.Abstract;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Application;

namespace VMS.BUSINESS.Concrete
{
    public class WorkTypeService : IWorkTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public WorkTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<BaseValueResponse<WorkTypeCommonResponse>> CreateAsync(WorkTypeCreateRequest request)
        {
            var result = unitOfWork.WorkTypes.Add(mapper.Map<WorkType>(request));
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<WorkTypeCommonResponse>>(result);
        }

        public async Task<BaseValueResponse<WorkTypeCommonResponse>> DeleteAsync(ushort id)
        {
            var result = unitOfWork.WorkTypes.DeleteSoft(id);
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<WorkTypeCommonResponse>>(result);
        }

        public async Task<BaseListResponse<WorkTypeCommonResponse>> GetAllAsync()
        {
            var result = await unitOfWork.WorkTypes.GetAsync(null,true,null,null,x=>x.Name);
            return mapper.Map<BaseListResponse<WorkTypeCommonResponse>>(result);
        }

        public async Task<BaseListResponse<WorkTypeCommonResponse>> GetByPagingAsync(PageRequest<object> request)
        {
            var result = await unitOfWork.WorkTypes.GetAsync(null,true,null,new PageRequest<WorkType>()
            {
                PageSize = request.PageSize,
                CurrentPage = request.CurrentPage
            },null,x=>x.CreatedDate);
            return mapper.Map<BaseListResponse<WorkTypeCommonResponse>>(result);
        }

        public async Task<BaseValueResponse<WorkTypeCommonResponse>> UpdateAsync(WorkTypeUpdateRequest request)
        {
            var result = unitOfWork.WorkTypes.Update(mapper.Map<WorkType>(request));
            await unitOfWork.SaveAsync();
            return mapper.Map<BaseValueResponse<WorkTypeCommonResponse>>(result);
        }
    }
}
