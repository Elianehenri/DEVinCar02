using System.Text;
using System.Text.Json.Serialization;
using DEVinCar.Api.Confi.IOC;
using DEVinCar.Api.Security;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Services;
using DEVinCar.Infra;
using DEVinCar.Infra.Database;
using DEVinCar.Infra.DataBase.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

//dbcontext
builder.Services.AddDbContext<DevInCarDbContext>();
//repositorio
RepositoryIoC.RegisterServices(builder.Services);
//Service
ServiceIoc.RegisterServices(builder.Services);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//jwt/Autenticaçao
var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>//authentication 
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})


.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
//Service
//builder.Services.AddScoped<ICarService, CarService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IAddressService, AddressService>();
//builder.Services.AddScoped<ISaleService, SaleService>();
//builder.Services.AddScoped<ISaleCarService, SaleCarService>();
//builder.Services.AddScoped<ICityService, CityService>();
//builder.Services.AddScoped<IStateService, StateService>();
//builder.Services.AddScoped<IDeliveryService, DeliveryService>();
//builder.Services.AddScoped<IAddressPatchService, AddressPatchService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// comentando para conseguir trabalhar com Insomnia/Postman via http comum
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
