using Microsoft.EntityFrameworkCore;
using SeteFios.API.Models;

namespace SeteFios.API.DbContexts
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Schedule> Schedules {  get; set; }
    }
}
