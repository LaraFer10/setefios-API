namespace SeteFios.API.Models.DTOs
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public string ServiceType { get; set; }
    }
}
