namespace CRM.WEB.Models
{
    public class AddEventViewModel
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Weekday { get; set; }
        public int CourseId { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public int СlassroomId { get; set; }
    }
}
