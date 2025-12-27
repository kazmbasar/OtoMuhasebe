using DataAccess.Contexts;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Add DbContext
builder.Services.AddDbContext<OtoMuhasebeContext>();

// Add Repositories
builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
builder.Services.AddScoped<IVehicleDal, EfVehicleDal>();
builder.Services.AddScoped<ITServiceDal, EfTServiceDal>();
builder.Services.AddScoped<InvoiceDal, EfInvoiceDal>();
builder.Services.AddScoped<InvoiceDetailDal, EfInvoiceDetailDal>();

// Add Business Services
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IVehicleService, VehicleManager>();
builder.Services.AddScoped<ITreatmentService, ITServiceManager>();
builder.Services.AddScoped<InvoiceService, InvoiceManager>();
builder.Services.AddScoped<InvoiceDetailService, InvoiceDetailManager>();
builder.Services.AddScoped<IPaymentDal, EfPaymentDal>();
builder.Services.AddScoped<IPaymentService, PaymentManager>();

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

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
