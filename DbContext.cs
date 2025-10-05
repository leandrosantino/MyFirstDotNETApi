using Microsoft.EntityFrameworkCore;
using ApiTeste.Models;

namespace ApiTeste;

public class MyDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=../databse.sqlite");
    }
}

