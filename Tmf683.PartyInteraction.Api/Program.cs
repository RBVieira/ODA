using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Tmf683.PartyInteraction.Infrastructure.Data;
using Tmf683.PartyInteraction.Application.Mappings;
using Tmf683.PartyInteraction.Application.Models.APIs;
using Tmf683.PartyInteraction.Application.Services.Interfaces;
using Tmf683.PartyInteraction.Application.Services;
using Tmf683.PartyInteraction.Application.Repositories;
using Tmf683.PartyInteraction.Application.Repositories.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Meus serviços
builder.Services.AddDbContext<PartyInteractionDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        // INFORMA AO EF ONDE ENCONTRAR AS MIGRAÇÕES
        b => b.MigrationsAssembly("Tmf683.PartyInteraction.Infrastructure")
    )
);



// Serviço de conexão ao banco de dados Microsoft SQL.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PartyInteractionDbContext>(options => options.UseSqlServer(connectionString));


// Mapeia a configuração do appsettings.json para a classe que configura os dados da API TMF632
builder.Services.Configure<Tmf632ApiConfiguration>(builder.Configuration.GetSection("ApiClients:Tmf632"));

// Adicionar o HttpClient para fazer chamadas HTTP para a API TMF632 por exemplo
builder.Services.AddHttpClient("PartyManagementClient", client =>
{
    // A URL base será injetada mais tarde no Controller
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

// Injetar o serviço de PartyInteraction
builder.Services.AddScoped<IPartyInteractionService, PartyInteractionService>();

//Repository
builder.Services.AddScoped<IPartyInteractionRepository, PartyInteractionRepository>();

// Adicionar o AutoMapper
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
