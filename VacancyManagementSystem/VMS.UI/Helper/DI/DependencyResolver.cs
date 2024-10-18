using VMS.BUSINESS.Helpers.Registration;

namespace VMS.UI.Helper.DI
{
    public static class DependencyResolver
    {
        public static void Resolve(this IServiceCollection services)
        {

            ServiceRegistration.Register(services);
        }
    }
}
