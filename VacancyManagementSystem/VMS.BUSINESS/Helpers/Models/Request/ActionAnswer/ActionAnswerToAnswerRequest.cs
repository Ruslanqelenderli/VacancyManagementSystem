﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BUSINESS.Helpers.Models.Request.ActionAnswer
{
    public record ActionAnswerToAnswerRequest(string ActionId,string QuestionId,string AnswerId);
}
