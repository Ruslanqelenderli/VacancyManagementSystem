using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Helpers.Models.Request.Answer;
using VMS.BUSINESS.Helpers.Models.Request.Question;

namespace VMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;
        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] QuestionCreateRequest request)
        {
            return Ok(await questionService.CreateAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            return Ok(await questionService.DeleteAsync(id));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] QuestionUpdateRequest request)
        {
            return Ok(await questionService.UpdateAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            return Ok(await questionService.GetByIdAsync(id));
        }

        [HttpGet("GetByWorkTypeId")]
        public async Task<IActionResult> GetByWorkTypeId([FromQuery] ushort workTypeId)
        {
            return Ok(await questionService.GetByWorkTypeIdAsync(workTypeId));
        }

        [HttpGet("GetByActionId")]
        public async Task<IActionResult> GetByActionId([FromQuery] string actionId)
        {
            return Ok(await questionService.GetByActionIdAsync(actionId));
        }

        [HttpGet("GetByQuestionBankId")]
        public async Task<IActionResult> GetByQuestionBankId([FromQuery] string questionBankId)
        {
            return Ok(await questionService.GetByQuestionBankIdAsync(questionBankId));
        }
    }
}
