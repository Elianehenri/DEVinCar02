using DEVinCar.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DEVinCar.Infra.DataBase.Mapping
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(a => a.Id);
            builder
                .Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder
                .Property(a => a.StateId)
                .HasColumnType("int")
                .IsRequired();
            builder
                .HasOne<State>(city => city.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(city => city.StateId)
                .IsRequired();
        }

        
    }
}
