﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BUSINESS.Helpers.Models.Response.Action
{
    public record ActionPagingResponse(string Id,string FullName,string WorkTypeName,byte Percent);
}
