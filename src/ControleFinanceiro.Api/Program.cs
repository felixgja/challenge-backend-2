using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Application.MappingProfile;
using ControleFinanceiro.Application.Services;
using ControleFinanceiro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conexao = builder.Configuration.GetConnectionString("DefaultConnection");
var versao = ServerVersion.AutoDetect(conexao);
builder.Services.AddDbContext<AppDataContext>(options =>
{
    options.UseMySql(conexao, versao);
});

builder.Services.AddAutoMapper(typeof(DespesaProfile));
builder.Services.AddAutoMapper(typeof(ReceitaProfile));

builder.Services.AddScoped<IReceitaService, ReceitaService>();
builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddScoped<IResumoService, ResumoService>();

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
