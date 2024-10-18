using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Concrete;
using VMS.BUSINESS.Helpers.Models.Request.QuestionBank;
using VMS.BUSINESS.Helpers.Models.Request.Vacancy;

namespace VMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionBankController : ControllerBase
    {
        private readonly IQuestionBankService questionBankService;
        public QuestionBankController(IQuestionBankService questionBankService)
        {
            this.questionBankService = questionBankService;
        }
        [HttpPost("Assign")]
        public async Task<IActionResult> Assign([FromBody] QuestionBankAssignRequest request)
        {
            return Ok(await questionBankService.Assign(request));
        }

        [HttpDelete("DeleteAssignment")]
        public async Task<IActionResult> DeleteAssignment([FromQuery] string id)
        {
            return Ok(await questionBankService.DeleteAssignment(id));
        }
    }
}
