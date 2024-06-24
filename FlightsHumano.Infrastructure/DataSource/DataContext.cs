using FlightsHumano.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlightsHumano.Infrastructure.DataSource;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            return;
        }

        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        

        modelBuilder.Entity<Origen>();
        modelBuilder.Entity<Destino>();
        modelBuilder.Entity<Vuelos>();
        modelBuilder.Entity<Reserva>();
        modelBuilder.Entity<Outbox>();


        modelBuilder.Entity<Vuelos>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Vuelos>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Reserva>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<Reserva>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Outbox>()
           .HasKey(x => x.Id);
        modelBuilder.Entity<Outbox>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

       

        base.OnModelCreating(modelBuilder);
    }

}

