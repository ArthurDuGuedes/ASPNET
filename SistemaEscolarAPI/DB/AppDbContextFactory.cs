using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SistemaEscolarAPI.DB;
using System.IO;

namespace SistemaEscolarAPI.DB
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // pasta do projeto
                .AddJsonFile("appsettings.json") // seu arquivo de config
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("PostgresConnection");

            optionsBuilder.UseNpgsql(connectionString); // ou UseSqlite / UseNpgsql

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
