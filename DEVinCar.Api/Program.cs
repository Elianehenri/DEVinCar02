using System.Text.Json.Serialization;
using DEVinCar.Api.Confi.IOC;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Services;
using DEVinCar.Infra;
using DEVinCar.Infra.Database;
using DEVinCar.Infra.DataBase.Repositories;

var builder = WebApplication.CreateBuilder(args);

//dbcontext
builder.Services.AddDbContext<DevInCarDbContext>();
//repositorio
RepositoryIoC.RegisterServices(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Services
//builder.Services.AddScoped<ICarRepositorio, CarRepositorio>();
builder.Services.AddScoped<ICarService, CarService>();
//builder.Services.AddScoped<IUserRepositorio, UserRepositorio>();
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IAddressRepositorio, AddressRepositorio>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleCarService, SaleCarService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IAddressPatchService, AddressPatchService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// comentando para conseguir trabalhar com Insomnia/Postman via http comum
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
