using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.WorkType;
using VMS.CORE.Helpers;

namespace VMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTypeController : ControllerBase
    {
        private readonly IWorkTypeService workTypeService;
        public WorkTypeController(IWorkTypeService workTypeService)
        {
            this.workTypeService = workTypeService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]WorkTypeCreateRequest request) 
        {
            return Ok(await workTypeService.CreateAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Create([FromQuery]ushort id)
        {
            return Ok(await workTypeService.DeleteAsync(id));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] WorkTypeUpdateRequest request)
        {
            return Ok(await workTypeService.UpdateAsync(request));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await workTypeService.GetAllAsync());
        }

        [HttpPost("GetByPaging")]
        public async Task<IActionResult> GetByPaging(PageRequest<object> request)
        {
            return Ok(await workTypeService.GetByPagingAsync(request));
        }
    }
}
