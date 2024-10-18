using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BUSINESS.Helpers.Models.Request.ApplicationInfo
{
    public record ApplicationInfoCreateRequest(string Name,string Surname,string Email ,string PhoneNumber,string VacancyId);
}
