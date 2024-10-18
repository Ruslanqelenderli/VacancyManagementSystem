using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.ENTITY.Entities.Common;

namespace VMS.ENTITY.Entities.Application
{
    public class Vacancy : BaseEntity<string>
    {
        public QuestionBank QuestionBank { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public byte QuestionCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public WorkType WorkType { get; set; }
        public ushort WorkTypeId { get; set; }
    }
}
