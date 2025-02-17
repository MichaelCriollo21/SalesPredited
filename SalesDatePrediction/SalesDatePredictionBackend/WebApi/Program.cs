using BusinessLogic.Class;
using BusinessLogic.Interface;
using Context.Class;
using Context.Context;
using Context.Interface;
using Microsoft.EntityFrameworkCore;

var RutasPermitidas = "_RutasPermitidas";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmployee, EmployeeBL>();
builder.Services.AddScoped<IOrder, OrderBL>();
builder.Services.AddScoped<IPredictedOrder, PredictedOrderBL>();
builder.Services.AddScoped<IProduct, ProductBL>();
builder.Services.AddScoped<IShipper, ShipperBL>();

var connectionString = builder.Configuration.GetConnectionString("SalesPredictionContext");
builder.Services.AddDbContext<SalesPredictionContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: RutasPermitidas,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader();
                      });
});
builder.Services.AddControllers();
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

app.UseCors(RutasPermitidas);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
