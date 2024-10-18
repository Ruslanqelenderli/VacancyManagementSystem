using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Concrete;
using VMS.BUSINESS.Helpers.Models.Request.ActionAnswer;
using VMS.BUSINESS.Helpers.Models.Request.ApplicationInfo;
using VMS.CORE.Helpers;

namespace VMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutController : ControllerBase
    {
        private readonly IVacancyService vacancyService;
        private readonly IApplicationInfoService applicationInfoService;
        private readonly IActionAnswerService actionAnswerService;
        public OutController(IVacancyService vacancyService, IApplicationInfoService applicationInfoService, IActionAnswerService actionAnswerService)
        {
            this.vacancyService = vacancyService;
            this.applicationInfoService = applicationInfoService;
            this.actionAnswerService = actionAnswerService;
        }
        [HttpPost("GetByPaging")]
        public async Task<IActionResult> GetByPaging([FromBody] PageRequest<object> request)
        {
            return Ok(await vacancyService.GetByPagingOutAsync(request));
        }

        [HttpPost("Apply")]
        public async Task<IActionResult> Apply([FromBody]ApplicationInfoCreateRequest request)
        {
            return Ok(await applicationInfoService.ApplyCreateAsync(request));
        }

        [HttpPost("ToAnswer")]
        public async Task<IActionResult> ToAnswer([FromBody] ActionAnswerToAnswerRequest request)
        {
            return Ok(await actionAnswerService.ToAnswer(request));
        }
    }
}
