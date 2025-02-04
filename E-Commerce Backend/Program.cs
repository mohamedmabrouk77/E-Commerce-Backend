using E_Commerce_Backend.AppDbContext;
using E_Commerce_Backend.Services.OrderRepositorys;
using E_Commerce_Backend.Services.PaymentRepositorys;
using E_Commerce_Backend.Services.ProductRepositorys;
using E_Commerce_Backend.Services.UserRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connect = builder.Configuration.GetConnectionString("myconnection");
builder.Services.AddDbContext<dbcontext>(options => options.UseSqlServer(connect));

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
