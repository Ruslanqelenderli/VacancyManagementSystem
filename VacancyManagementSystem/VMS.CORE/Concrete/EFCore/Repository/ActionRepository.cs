using VMS.CORE.Abstract;
using VMS.CORE.Concrete.EFCore.Context;
using VMS.CORE.Concrete.EFCore.Repository.GenericRepository;
using Action = VMS.ENTITY.Entities.Application.Action;

namespace VMS.CORE.Concrete.EFCore.Repository
{
    public class ActionRepository : EFGenericRepository<Action, VMSDbContext, string>, IActionRepository
    {
        private readonly VMSDbContext context;
        public ActionRepository(VMSDbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }
    }
}
