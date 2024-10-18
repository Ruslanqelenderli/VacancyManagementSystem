using VMS.ENTITY.Entities.Common;

namespace VMS.ENTITY.Entities.Application
{
    public class Question : BaseEntity<string>
    {
        public string Description { get; set; }
        public WorkType WorkType { get; set; }
        public ushort WorkTypeId { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<ActionAnswer> ActionAnswers { get; set; }
        public ICollection<QuestionBankQuestion> QuestionBankQuestions { get; set; }

    }
}
