using HRAttendanceSystem.BL.Services.AttendanceService;
using HRAttendanceSystem.BL.Services.EmployeeService;
using HRAttendanceSystem.DAL.Data;
using HRAttendanceSystem.DAL.Repos.AttendanceRepo;
using HRAttendanceSystem.DAL.Repos.EmployeeRepo;
using Microsoft.EntityFrameworkCore;
namespace HRAttendanceSystem.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddScoped<IAttendanceRepo, AttendanceRepo>();
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();


            builder.Services.AddDbContext<AppDbContext>
                (x => x.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionString")));
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
        }
    }
}
