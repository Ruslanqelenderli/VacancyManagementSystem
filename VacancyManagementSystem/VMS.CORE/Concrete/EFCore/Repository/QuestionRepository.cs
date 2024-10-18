using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.CORE.Abstract;
using VMS.CORE.Concrete.EFCore.Context;
using VMS.CORE.Concrete.EFCore.Repository.GenericRepository;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Concrete.EFCore.Repository
{
    public class QuestionRepository : EFGenericRepository<Question, VMSDbContext, string>, IQuestionRepository
    {
        private readonly VMSDbContext context;
        public QuestionRepository(VMSDbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }
    }
}
