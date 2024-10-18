using VMS.CORE.Abstract;
using VMS.CORE.Concrete.EFCore.Context;
using VMS.CORE.Concrete.EFCore.Repository.GenericRepository;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Repository
{
    public class QuestionBankQuestionRepository : EFGenericRepository<QuestionBankQuestion, VMSDbContext, string>, IQuestionBankQuestionRepository
    {
        private readonly VMSDbContext context;
        public QuestionBankQuestionRepository(VMSDbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }
    }
}
