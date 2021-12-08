using SeteFios.API.Models.DTOs;

namespace SeteFios.API.Repositorys
{
    public interface IScheduleRepository
    {
        Task<ScheduleDto> CreateUpdateScheduleAsync(ScheduleDto schedule);
        Task<ScheduleDto> GetByDateAsync(DateTime initialDate, DateTime finalDate);
        Task<ScheduleDto> GetByIdAsync(int id);
        Task<List<ScheduleDto>> GetAllAsync();
        Task<bool> DeleteScheduleAsync(int id);
    }
}
