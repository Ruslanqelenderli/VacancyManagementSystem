using VMS.BUSINESS.Abstract;
using VMS.BUSINESS.Concrete;
using VMS.BUSINESS.Helpers.AutoMapper;
using VMS.BUSINESS.Helpers.Registration;
using VMS.CORE.Abstract;
using VMS.CORE.Concrete.EFCore.Context;
using VMS.CORE.Concrete.EFCore.Repository;

namespace VMS.API.Helper.DI
{
    public static class DependencyResolver
    {
        public static void Resolve(this IServiceCollection services)
        {

            ServiceRegistration.Register(services);
        }
    }
}
