

using DEVinCar.Domain.Models;
using DEVinCar.Infra.DataBase.Mapping;
using Microsoft.EntityFrameworkCore;


namespace DEVinCar.Infra.Database;

public class DevInCarDbContext : DbContext
{
   
    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleCar> SaleCars { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Address> Addresses { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DEVinCar2;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressMap());
        modelBuilder.ApplyConfiguration(new CarMap());
        modelBuilder.ApplyConfiguration(new CityMap());
        modelBuilder.ApplyConfiguration(new DeliveryMap());
        modelBuilder.ApplyConfiguration(new SaleMap());
        modelBuilder.ApplyConfiguration(new SaleCarMap());
        modelBuilder.ApplyConfiguration(new StateMap());
        modelBuilder.ApplyConfiguration(new UserMap());

    }

  
    
}

