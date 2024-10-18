using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BUSINESS.Helpers.Models.Response.Action
{
    public record ActionApplyResponse(string Id,string QuestionBankId,ushort Point, byte Percent,string CVPath);
}
