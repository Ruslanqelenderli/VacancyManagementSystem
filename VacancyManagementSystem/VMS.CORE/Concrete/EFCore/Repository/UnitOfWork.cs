using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.CORE.Abstract;
using VMS.CORE.Concrete.EFCore.Context;

namespace VMS.CORE.Concrete.EFCore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VMSDbContext _context;
        private IWorkTypeRepository _workTypes;
        private IVacancyRepository _vacancies;
        private IQuestionRepository _questions;
        private IQuestionBankRepository _questionBanks;
        private IQuestionBankQuestionRepository _questionBankQuestions;
        private IApplicationInfoRepository _applicationInfos;
        private IAnswerRepository _answers;
        private IActionRepository _actions;
        private IActionAnswerRepository _actionAnswers;

        public UnitOfWork(VMSDbContext context)
        {
            _context = context;
        }

        public IWorkTypeRepository WorkTypes => _workTypes ??= new WorkTypeRepository(_context);

        public IVacancyRepository Vacancies => _vacancies ??= new VacancyRepository(_context);

        public IQuestionRepository Questions => _questions ??= new QuestionRepository(_context);

        public IQuestionBankRepository QuestionBanks => _questionBanks ??= new QuestionBankRepository(_context);

        public IQuestionBankQuestionRepository QuestionBankQuestions => _questionBankQuestions ??= new QuestionBankQuestionRepository(_context);

        public IApplicationInfoRepository ApplicationInfos => _applicationInfos ??= new ApplicationInfoRepository(_context);

        public IAnswerRepository Answers => _answers ??= new AnswerRepository(_context);

        public IActionRepository Actions => _actions ??= new ActionRepository(_context);
        public IActionAnswerRepository ActionAnswers => _actionAnswers ??= new ActionAnswerRepository(_context);

        public async Task  SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Save()
        {
             _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
