using SeteFios.API.Models.DTOs;

namespace SeteFios.API.Repositorys
{
    public interface IClientRepository
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<ClientDto> GetByIdAsync(int id);
        Task<ClientDto> CreateUpdateClientAsync(ClientDto clientDto);
        Task<bool> DeleteClientAsync(int id);
    }
}
