using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SeteFios.API.DbContexts;
using SeteFios.API.Models;
using SeteFios.API.Models.DTOs;

namespace SeteFios.API.Repositorys
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ScheduleRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ScheduleDto> CreateUpdateScheduleAsync(ScheduleDto scheduleDto)
        {
            Schedule schedule = _mapper.Map<Schedule>(scheduleDto);

            if(schedule.ScheduleId > 0)
            {
                _context.Schedules.Update(schedule); 
            }
            else
            {
                _context.Schedules.Add(schedule);
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<ScheduleDto>(schedule);
        }

        public async Task<bool> DeleteScheduleAsync(int id)
        {
            try
            {
                Schedule schedule = _context.Schedules.FirstOrDefault(x => x.ScheduleId == id);
                if(schedule == null)
                {
                    return false;   
                }
                _context.Schedules.Remove(schedule);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ScheduleDto>> GetAllAsync()
        {
            List<Schedule> list = await _context.Schedules.ToListAsync();
            return _mapper.Map<List<ScheduleDto>>(list);
        }

        public async Task<ScheduleDto> GetByDateAsync(DateTime initialDate, DateTime finalDate)
        {
            Schedule schedule = await _context.Schedules.Where(x => x.Date >= initialDate && x.Date <= finalDate).FirstOrDefaultAsync();
            return _mapper.Map<ScheduleDto>(schedule);
        }

        public async Task<ScheduleDto> GetByIdAsync(int id)
        {
            Schedule schedule = await _context.Schedules.FirstOrDefaultAsync(x => x.ScheduleId == id);
            return _mapper.Map<ScheduleDto>(schedule);
        }

    }
}
