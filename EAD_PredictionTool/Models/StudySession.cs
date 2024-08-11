namespace EAD_PredictionTool.Models
{
    public class StudySession
    {
        public int ID { get; set; }
        public required string Session { get; set; }
        public int Goalhours { get; set; }
        public required string StartTime { get; set; }
        public required string EndTime { get; set; }
        public required string Day { get; set; }
        public int TotalStudyhours { get; set; }
        public int BreakID { get; set; }
        public required string Date { get; set; }
        public int NumberofUnits { get; set; }
        public string EnrollmentDate { get; set; } = DateTime.Now.ToString();
    }
}
