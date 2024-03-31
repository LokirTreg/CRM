using CRM.WEB.Models.Entyties;

namespace CRM.WEB.Models
{
    public class EventDetailView
    {
        public Event eevent { get; set; }
        public Group gro { get; set; }
        public Course course { get; set; }
        public Teacher teacher { get; set; }
        public Audi audi { get; set; }
    }
}
