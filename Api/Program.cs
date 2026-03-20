using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Leer la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar el DbContext de la capa Data
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Inyeccion de dependencias con la inteface y la capa de servicio
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<SpecialtyService>();

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<DoctorService>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<PatientService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<AppointmentService>();

builder.Services.AddScoped<IAppointmentStatus, AppointmentStatusRepository>();
builder.Services.AddScoped<AppointmentService>();

builder.Services.AddScoped<ILogRepository, LogRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
