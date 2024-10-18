using VMS.ENTITY.Entities.Common;

namespace VMS.ENTITY.Entities.Application
{
    public class Answer : BaseEntity<string>
    {
        public string Description { get; set; }
        public string QuestionId { get; set; }
        public Question Question { get; set; }
        public bool IsCorrect { get; set; }

        public ICollection<ActionAnswer> ActionAnswers { get; set; }

    }
}
