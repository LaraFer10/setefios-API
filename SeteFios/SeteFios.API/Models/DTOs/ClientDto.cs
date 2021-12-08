namespace SeteFios.API.Models.DTOs
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Telefone { get; set; }
        public List<Schedule> Schedule { get; set; }
    }
}
