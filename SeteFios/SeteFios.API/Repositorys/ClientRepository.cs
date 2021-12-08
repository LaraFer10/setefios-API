using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SeteFios.API.DbContexts;
using SeteFios.API.Models;
using SeteFios.API.Models.DTOs;

namespace SeteFios.API.Repositorys
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientDto> CreateUpdateClientAsync(ClientDto clientDto)
        {
            Client client = _mapper.Map<ClientDto, Client>(clientDto);

            if (client.ClientId > 0)
            {
                _context.Update(client);
            }
            else
            {
                 _context.Add(client);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Client, ClientDto>(client);
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            try
            {

                Client client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
                if(client == null)
                {
                    return false;
                }

                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            List<Client> list = await _context.Clients.ToListAsync();
            return _mapper.Map<List<ClientDto>>(list);
        }

        public async Task<ClientDto> GetByIdAsync(int id)
        {
            Client client = await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
            return _mapper.Map<ClientDto>(client);
        }

    }
}
