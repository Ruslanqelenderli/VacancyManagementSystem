using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.Answer;
using VMS.BUSINESS.Helpers.Models.Request.WorkType;

namespace VMS.BUSINESS.Helpers.Validator.AnswerValidator
{
    public class AnswerCreateValidator : AbstractValidator<AnswerCreateRequest>
    {
       //description-a max size verdiyimə görə gərək duymadım.Digər propertilərdə default validation var.
    }
}
