using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BUSINESS.Helpers.Models.Request.Question
{
    public record QuestionUpdateRequest(string Id,string Description, ushort WorkTypeId);
}
