using Microsoft.EntityFrameworkCore;
using Repository.GenericRepository;
using Repository.Interfaces.IGenericRepository;
using Repository.Interfaces.IInvoceProductRepository;
using Repository.Interfaces.IInvoceRepository;
using Repository.InvoceProductRepository;
using Repository.InvoceRepository;
using server.Models;
using Services.GenericService;
using Services.Interfaces.IGenericService;
using Services.Interfaces.IInvoceProductService;
using Services.Interfaces.IInvoceService;
using Services.InvoceProductService;
using Services.InvoceService;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var settings = provider.GetRequiredService<IConfiguration>();
builder.Services.AddCors(op => {
    var clientURL = settings.GetValue<string>("ConnectionStrings:ClientAllow");

    op.AddDefaultPolicy(builder => {
        builder.WithOrigins(clientURL!).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection to DataBase SQL Azure
builder.Services.AddDbContext<InvocehubContext>(op => op.UseSqlServer("name:ConnectionStrings:DBConnection"));

builder.Services.AddScoped<IInvoceRepository , InvoceRepository>();
builder.Services.AddScoped(typeof (IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof (IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IInvoceService , InvoceService>();
builder.Services.AddScoped<IInvoceProductRepository , InvoceProductRepository>();
builder.Services.AddScoped<IInvoceProductService , InvoceProductService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
