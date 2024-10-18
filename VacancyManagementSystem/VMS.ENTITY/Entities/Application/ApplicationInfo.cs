using VMS.ENTITY.Entities.Common;

namespace VMS.ENTITY.Entities.Application
{
    public class ApplicationInfo : BaseEntity<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        

        public Action Action { get; set; }
    }
}
