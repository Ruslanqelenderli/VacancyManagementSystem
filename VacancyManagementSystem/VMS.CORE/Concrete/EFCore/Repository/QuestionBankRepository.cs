using VMS.CORE.Abstract;
using VMS.CORE.Concrete.EFCore.Context;
using VMS.CORE.Concrete.EFCore.Repository.GenericRepository;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Repository
{
    public class QuestionBankRepository : EFGenericRepository<QuestionBank, VMSDbContext, string>, IQuestionBankRepository
    {
        private readonly VMSDbContext context;
        public QuestionBankRepository(VMSDbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }
    }
}
