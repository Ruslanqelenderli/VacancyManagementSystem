using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.CORE.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkTypeRepository WorkTypes { get; }
        IVacancyRepository Vacancies { get; }
        IQuestionRepository Questions { get; }
        IQuestionBankRepository QuestionBanks { get; }
        IQuestionBankQuestionRepository QuestionBankQuestions { get; }
        IApplicationInfoRepository ApplicationInfos { get; }
        IAnswerRepository Answers { get; }
        IActionRepository Actions { get; }
        IActionAnswerRepository ActionAnswers { get; }
        void Save();
        Task SaveAsync();
    }
}
