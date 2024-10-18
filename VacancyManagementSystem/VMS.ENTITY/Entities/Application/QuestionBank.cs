using VMS.ENTITY.Entities.Common;

namespace VMS.ENTITY.Entities.Application
{
    public class QuestionBank : BaseEntity<string>
    {
        public QuestionBank()
        {
            
        }

        public QuestionBank(string id)
        {
            Id = id;
        }
        public Vacancy Vacancy { get; set; }
        public ICollection<QuestionBankQuestion> QuestionBankQuestions { get; set; }
        public ICollection<Action> Actions { get; set; }


    }
}
