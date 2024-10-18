using VMS.ENTITY.Entities.Common;

namespace VMS.ENTITY.Entities.Application
{
    public class QuestionBankQuestion : BaseEntity<string>
    {
        public QuestionBankQuestion()
        {
            
        }

        public QuestionBankQuestion(string questionId,string questionBankId)
        {
            Id= Guid.NewGuid().ToString();
            QuestionBankId = questionBankId;
            QuestionId = questionId;
        }
        public string QuestionBankId { get; set; }
        public QuestionBank QuestionBank { get; set; }
        public string QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
