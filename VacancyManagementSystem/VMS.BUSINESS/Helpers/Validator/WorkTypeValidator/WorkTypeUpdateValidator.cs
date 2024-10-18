using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.BUSINESS.Helpers.Models.Request.WorkType;

namespace VMS.BUSINESS.Helpers.Validator.WorkTypeValidator
{
    public class WorkTypeUpdateValidator : AbstractValidator<WorkTypeUpdateRequest>
    {
        public WorkTypeUpdateValidator()
        {
            RuleFor(x => x.Name)
               .MaximumLength(100).WithMessage("Work type name max length is 100 charachters")
               .NotEmpty().WithMessage("Work type name is required.");
        }
       
    }
}
