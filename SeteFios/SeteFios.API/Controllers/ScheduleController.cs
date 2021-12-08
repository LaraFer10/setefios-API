using Microsoft.AspNetCore.Mvc;
using SeteFios.API.Models.DTOs;
using SeteFios.API.Repositorys;

namespace SeteFios.API.Controllers
{
    [Route("api/schedule")]
    public class ScheduleController : Controller
    {
        private ResponseDto _response;
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _response = new();
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<ScheduleDto> schedules = await _scheduleRepository.GetAllAsync();
                _response.Result = schedules;
                _response.IsSuccess = true;
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
                ScheduleDto schedule = await _scheduleRepository.GetByIdAsync(id);
                _response.Result = schedule;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErroMessages = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{initialDate}&{finalDate}")]
        public async Task<ResponseDto> Get(DateTime initialDate, DateTime finalDate)
        {
            try
            {
                ScheduleDto schedule = await _scheduleRepository.GetByDateAsync(initialDate, finalDate.AddHours(23).AddMinutes(59).AddSeconds(59));
                _response.Result = schedule;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErroMessages = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] ScheduleDto scheduleDto)
        {
            try
            {
                ScheduleDto schedule = await _scheduleRepository.CreateUpdateScheduleAsync(scheduleDto);
                _response.Result = schedule;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErroMessages = new List<string> { ex.Message.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] ScheduleDto scheduleDto)
        {
            try
            {
                ScheduleDto schedule = await _scheduleRepository.CreateUpdateScheduleAsync(scheduleDto);
                _response.Result = schedule;
                _response.IsSuccess = true;
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
                bool isSuccess = await _scheduleRepository.DeleteScheduleAsync(id);
                _response.Result = isSuccess;
                _response.IsSuccess = true;
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
