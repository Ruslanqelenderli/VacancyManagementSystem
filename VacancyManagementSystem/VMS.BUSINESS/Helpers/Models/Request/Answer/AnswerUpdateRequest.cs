﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BUSINESS.Helpers.Models.Request.Answer
{
    public record AnswerUpdateRequest(string Id,string Description, string QuestionId, bool IsCorrect);
}
