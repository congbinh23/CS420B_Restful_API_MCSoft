using CS420B_RestfulApi.Models;
using Microsoft.EntityFrameworkCore;
using CS420B_RestfulApi.Data;
using CS420B_RestfulApi.Repository.IRepository;
using CS420B_RestfulApi.Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>
    (opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BookingDb")));

// Add services of dependency injection
builder.Services.AddScoped<IHotel, HotelRepository>();
builder.Services.AddScoped<IGuest, GuestRepository>();
builder.Services.AddScoped<IStaff, StaffRepository>();
builder.Services.AddScoped<IRoom, RoomRepository>();
builder.Services.AddScoped<IRoomType, RoomTypeRepository>();
builder.Services.AddScoped<IBooking, BookingRepository>();
builder.Services.AddScoped<IPayment, PaymentRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
