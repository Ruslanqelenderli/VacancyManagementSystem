using VMS.ENTITY.Entities.Common;

namespace VMS.ENTITY.Entities.Application
{
    public class ActionAnswer : BaseEntity<string>
    {
        public string ActionId { get; set; }
        public string QuestionId { get; set; }
        public string AnswerId { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
        public Action Action { get; set; }
    }
}
