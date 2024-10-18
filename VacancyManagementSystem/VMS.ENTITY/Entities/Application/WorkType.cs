using VMS.ENTITY.Entities.Common;

namespace VMS.ENTITY.Entities.Application
{
    public class WorkType : BaseEntity<ushort>
    {
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
