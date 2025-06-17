using FastTech.LojaCardapio.Application.Services;
using FastTech.LojaCardapio.Infra.Persistense;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FastTech.LojaCardapio.Infra.Persistense.Repositories;
using FastTech.LojaCardapio.Web.Middlewares;
using FastTech.LojaCardapio.Application.Interfaces.Repository;
using FastTech.LojaCardapio.Application.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LojaCardapioDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IMenuItensService, MenuItensService>();
builder.Services.AddScoped<IStoresService, StoresService>();

builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IMenuItensRepository, MenuItensRepository>();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    options.IncludeXmlComments(xmlPath);
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080); // Porta que será exposta no Docker
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
