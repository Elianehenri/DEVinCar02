using System.Text.Json.Serialization;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Infra;
using DEVinCar.Infra.DataBase.Repositories;

var builder = WebApplication.CreateBuilder(args);

//dbcontext
builder.Services.AddDbContext<DevInCarDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Services
builder.Services.AddScoped<ICarRepositorio, CarRepositorio>();

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
