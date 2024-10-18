using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.CORE.Abstract;
using VMS.CORE.Concrete.EFCore.Context;
using VMS.CORE.Concrete.EFCore.Repository.GenericRepository;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Repository
{
    public class ActionAnswerRepository : EFGenericRepository<ActionAnswer, VMSDbContext, string>, IActionAnswerRepository
    {
        private readonly VMSDbContext context;
        public ActionAnswerRepository(VMSDbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }
    }
}
