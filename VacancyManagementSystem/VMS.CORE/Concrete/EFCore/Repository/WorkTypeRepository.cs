using VMS.CORE.Abstract;
using VMS.CORE.Concrete.EFCore.Context;
using VMS.CORE.Concrete.EFCore.Repository.GenericRepository;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Repository
{
    public class WorkTypeRepository : EFGenericRepository<WorkType, VMSDbContext, ushort>, IWorkTypeRepository
    {
        private readonly VMSDbContext context;
        public WorkTypeRepository(VMSDbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }
    }
}
