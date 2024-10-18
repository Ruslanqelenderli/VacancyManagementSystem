using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Response.Answer;

namespace VMS.BUSINESS.Helpers.Models.Response.Question
{
    public record QuestionGetByIdResponse(string Id, string Description, ushort WorkTypeId,ICollection<AnswerCommonResponse> Answers);
}
