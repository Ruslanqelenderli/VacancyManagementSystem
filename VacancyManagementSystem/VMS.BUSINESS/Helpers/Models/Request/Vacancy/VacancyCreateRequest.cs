using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.BUSINESS.Helpers.Models.Request.Vacancy
{
    public record VacancyCreateRequest(string Description,string Title,byte QuestionCount,DateTime StartDate, DateTime EndDate, ushort WorkTypeId);
}
