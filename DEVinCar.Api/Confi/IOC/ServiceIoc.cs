using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Services;
using DEVinCar.Infra.DataBase.Repositories;

namespace DEVinCar.Api.Confi.IOC
{
    public class ServiceIoc
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<ICarService, CarService>();
            builder.AddScoped<IUserService, UserService>();
            builder.AddScoped<IAddressService, AddressService>();
            builder.AddScoped<ISaleService, SaleService>();
            builder.AddScoped<ISaleCarService, SaleCarService>();
            builder.AddScoped<ICityService, CityService>();
            builder.AddScoped<IStateService, StateService>();
            builder.AddScoped<IDeliveryService, DeliveryService>();
            builder.AddScoped<IAddressPatchService, AddressPatchService>();



        }
    }
}
