using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BUSINESS.Helpers.Models.Request.WorkType
{
    public record WorkTypeUpdateRequest(ushort Id,string Name);
}
