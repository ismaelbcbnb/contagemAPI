using Microsoft.EntityFrameworkCore;
using ContagemPF.Data;
using ContagemPF.Models;
using ContagemPF.Data.DTO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors();

builder.Services.AddTransient<DAL<Contagem>>();
builder.Services.AddTransient<DAL<ContagemDTO>>();
builder.Services.AddTransient<DAL<Mes>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              );

app.MapControllers();

app.Run();

