using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.CORE.Abstract.GenericRepository;
using System.Threading.Tasks;
using VMS.CORE.Helpers;
using VMS.ENTITY.Entities.Application;

namespace VMS.CORE.Abstract
{
    public interface IQuestionRepository : IRepository<Question,  string>
    {

    }
}
