using System.ComponentModel.DataAnnotations;

namespace SeteFios.API.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Telefone { get; set; }
        public List<Schedule> Schedule { get; set; }
    }
}
