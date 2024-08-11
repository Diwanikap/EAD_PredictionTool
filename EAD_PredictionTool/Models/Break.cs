namespace EAD_PredictionTool.Models
{
    public class Break
    {
        public int ID { get; set; }
        public required string start_time { get; set; }
        public required string end_time { get; set; }
        public required string date { get; set; }
        public required int duration { get; set; }
    }
}
