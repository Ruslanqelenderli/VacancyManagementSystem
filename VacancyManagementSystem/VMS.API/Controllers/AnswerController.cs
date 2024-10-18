using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.Answer;
using VMS.BUSINESS.Helpers.Models.Request.WorkType;
using VMS.CORE.Helpers;

namespace VMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService answerService;
        public AnswerController(IAnswerService answerService)
        {
            this.answerService = answerService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AnswerCreateRequest request)
        {
            return Ok(await answerService.CreateAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Create([FromQuery] string id)
        {
            return Ok(await answerService.DeleteAsync(id));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] AnswerUpdateRequest request)
        {
            return Ok(await answerService.UpdateAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            return Ok(await answerService.GetByIdAsync(id));
        }

        [HttpGet("GetByQuestionId")]
        public async Task<IActionResult> GetByQuestionId([FromQuery] string questionId)
        {
            return Ok(await answerService.GetByQuestionIdAsync(questionId));
        }
    }
}
