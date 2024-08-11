namespace EAD_PredictionTool.Models
{
    public class User
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string password { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    }
}
