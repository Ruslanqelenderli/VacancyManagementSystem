using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BUSINESS.Helpers.Models.Response.ActionAnswer
{
    public record ActionAnswerActionGetByIdResponse(string SelectedAnswer,string CorrectAnswer,string QuestionDescription);
}
