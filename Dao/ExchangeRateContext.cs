using ExchangeRatesApp.Entites;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRatesApp.Dao
{
    public class ExchangeRateContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }


        public DbSet<Bank> Banks { get; set; }
    }
}
