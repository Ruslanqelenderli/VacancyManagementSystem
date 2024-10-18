using VMS.CORE.Abstract.GenericRepository;
using Action = VMS.ENTITY.Entities.Application.Action;

namespace VMS.CORE.Abstract
{
    public interface IActionRepository : IRepository<Action, string>
    {

    }
}
