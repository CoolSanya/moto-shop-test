using Microsoft.EntityFrameworkCore;
using moto_shop_test.Models;

namespace moto_shop_test.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
