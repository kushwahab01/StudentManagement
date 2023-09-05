namespace StudentManagement.Models
{
    public class StudentLog
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
