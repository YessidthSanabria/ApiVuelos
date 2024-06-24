using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FlightsHumano.Infrastructure.DataSource
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"D:\\FlightHumanoSeguros\\FlightsHumano.Api\\appsettings.json")
                .Build();

            
            // Construye DbContextOptions
            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = configuration.GetConnectionString("db");
            builder.UseNpgsql(connectionString);

            return new DataContext(builder.Options, configuration);
        }
    }
}
