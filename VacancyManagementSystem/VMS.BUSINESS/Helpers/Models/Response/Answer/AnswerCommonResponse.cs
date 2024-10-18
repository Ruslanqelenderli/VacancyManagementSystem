using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BUSINESS.Helpers.Models.Response.Answer
{
    public record AnswerCommonResponse(string Id, string Description, bool IsCorrect);
}
