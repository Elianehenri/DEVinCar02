using System.Text;
using System.Text.Json.Serialization;
using DEVinCar.Api.Confi;
using DEVinCar.Api.Confi.IOC;
using DEVinCar.Api.Security;
using DEVinCar.Infra.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//dbcontext
builder.Services.AddDbContext<DevInCarDbContext>();
//repositorio
RepositoryIoC.RegisterServices(builder.Services);
//Service
ServiceIoc.RegisterServices(builder.Services);

//cache
builder.Services.AddMemoryCache();
builder.Services.AddScoped(typeof(CacheService<>));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();




builder.Services.AddSwaggerGen(c =>
{

    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                Escreva 'Bearer' [espaço] e o token gerado no login na caixa abaixo.
               Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
           new OpenApiSecurityScheme
           {
               Reference = new OpenApiReference
               {
                Type = ReferenceType.SecurityScheme,
                 Id = JwtBearerDefaults.AuthenticationScheme
               },
           },
               new List<string>()
        }
    });
c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Escola API",
        Version = "v1.0",
        Contact = new OpenApiContact
        {
            Name = "Eliane",
            Email = "eliane@eliane.com.br"
        }
    });
});

builder.Services.AddMvc(config =>
{
    config.ReturnHttpNotAcceptable = true;
    config.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
    config.InputFormatters.Add(new XmlDataContractSerializerInputFormatter(config));
});

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



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}


// comentando para conseguir trabalhar com Insomnia/Postman via http comum
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ErrorMiddleware>();

app.Run();
