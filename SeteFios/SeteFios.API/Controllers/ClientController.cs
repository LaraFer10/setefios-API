using Microsoft.AspNetCore.Mvc;
using SeteFios.API.Models.DTOs;
using SeteFios.API.Repositorys;

namespace SeteFios.API.Controllers
{
    [Route("api/client")]
    public class ClientController : Controller
    {
        private ResponseDto _response;
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _response = new ResponseDto();
            _clientRepository = clientRepository;
        }


        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<ClientDto> clients = await _clientRepository.GetAllAsync();
                _response.Result = clients;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErroMessages = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                ClientDto clients = await _clientRepository.GetByIdAsync(id);
                _response.Result = clients;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErroMessages = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] ClientDto clientDto)
        {
            try
            {
                ClientDto clients = await _clientRepository.CreateUpdateClientAsync(clientDto);
                _response.Result = clients;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErroMessages = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] ClientDto clientDto)
        {
            try
            {
                ClientDto clients = await _clientRepository.CreateUpdateClientAsync(clientDto);
                _response.Result = clients;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErroMessages = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                bool isSuccess = await _clientRepository.DeleteClientAsync(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErroMessages = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }
    }
}
