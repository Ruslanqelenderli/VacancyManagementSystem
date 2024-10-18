using VMS.ENTITY.Entities.Common;

namespace VMS.ENTITY.Entities.Application
{
    public class Action : BaseEntity<string>
    {
        public ApplicationInfo ApplicationInfo { get; set; }
        public QuestionBank QuestionBank { get; set; }
        public string QuestionBankId { get; set; }
        public ushort Point { get; set; }
        public byte Percent { get; set; }
        public string CVPath { get; set; }

        public ICollection<ActionAnswer> ActionAnswers { get; set; }

    }
}
