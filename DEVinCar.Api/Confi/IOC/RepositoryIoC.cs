using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Infra.DataBase.Repositories;

namespace DEVinCar.Api.Confi.IOC
{
    public class RepositoryIoC
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<ICarRepositorio, CarRepositorio>();
            builder.AddScoped<IUserRepositorio, UserRepositorio>();
            builder.AddScoped<IAddressRepositorio, AddressRepositorio>();
            builder.AddScoped<ISaleRepositorio, SaleRepositorio>();
            builder.AddScoped<ISaleCarRepositorio, SaleCarRepositorio>();
            builder.AddScoped<ICityRepositorio, CityRepositorio>();
            builder.AddScoped<IStateRepositorio, StateRepositorio>();
            builder.AddScoped<IDeliverRepositorio, DeliveryRepositorio>();
            builder.AddScoped<IAddressPatchRepositorio, AddressPatchRepositorio>();


           
        }
    }
}
