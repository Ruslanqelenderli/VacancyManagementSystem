using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.Answer;
using VMS.BUSINESS.Helpers.Models.Request.Vacancy;
using VMS.CORE.Helpers;

namespace VMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService vacancyService;
        public VacancyController(IVacancyService vacancyService)
        {
            this.vacancyService = vacancyService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] VacancyCreateRequest request)
        {
            return Ok(await vacancyService.CreateAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            return Ok(await vacancyService.DeleteAsync(id));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] VacancyUpdateRequest request)
        {
            return Ok(await vacancyService.UpdateAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            return Ok(await vacancyService.GetByIdAsync(id));
        }

        [HttpPost("GetByPaging")]
        public async Task<IActionResult> GetByPaging([FromBody] PageRequest<object> request)
        {
            return Ok(await vacancyService.GetByPagingAsync(request));
        }
    }
}
