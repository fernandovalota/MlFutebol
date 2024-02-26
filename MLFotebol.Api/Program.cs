using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MlFutebol.Data.Context;
using MLFutebol.Api.Configurations;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//buscar a string de conexão.
builder.Services.AddDbContext<MlDbContext>(options =>
              options.UseSqlServer(
                  builder.Configuration.GetConnectionString("DefaultConnectionString")));
///buscar quando sobe a aplicação todos os profiles do automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
///extensão da injeção de dependencia.
builder.Services.ResolverDependecias();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");

    // Define o caminho para os arquivos XML de comentários
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    // Inclui os comentários XML na documentação do Swagger
    c.InjectStylesheet("/swagger-ui/custom.css"); // Opcional: permite personalizar o estilo
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
});
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
