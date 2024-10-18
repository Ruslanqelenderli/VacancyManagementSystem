using VMS.CORE.Abstract;
using VMS.CORE.Concrete.EFCore.Context;
using VMS.CORE.Concrete.EFCore.Repository.GenericRepository;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Repository
{
    public class ApplicationInfoRepository : EFGenericRepository<ApplicationInfo, VMSDbContext, string>, IApplicationInfoRepository
    {
        private readonly VMSDbContext context;
        public ApplicationInfoRepository(VMSDbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }
    }
}
