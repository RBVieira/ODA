using Microsoft.EntityFrameworkCore;
using Tmf632.PartyManagement.Api.Data;
using Tmf632.PartyManagement.Api.Mappings;



//TESTE

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Meus serviços
// Serviço de conexão ao banco de dados Microsoft SQL.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PartyManagementDbContext>(options => options.UseSqlServer(connectionString));

// Aqui registra o AutoMapper, indicando a classe MappingProfile
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

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
