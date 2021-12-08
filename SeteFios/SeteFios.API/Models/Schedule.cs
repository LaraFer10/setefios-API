using System.ComponentModel.DataAnnotations;

namespace SeteFios.API.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int ClientId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string ServiceType { get; set; }
    }
}
