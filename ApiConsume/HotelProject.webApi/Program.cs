
using HotelProject.BusunessLayer.Abstract;
using HotelProject.BusunessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EnitityFramework;

namespace HotelProject.webApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<Context>();
            builder.Services.AddScoped<IStaffDal, EfStaff>();
            builder.Services.AddScoped<IStaffService, StaffManager>();

            builder.Services.AddScoped<IRoomDal, EfRoom>();
            builder.Services.AddScoped<IRoomService, RoomManager>();

            builder.Services.AddScoped<ISubscribeDal, EfSubscribe>();
            builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

            builder.Services.AddScoped<ITestimonialDal, EfTestimonial>();
            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

            builder.Services.AddScoped<IServicesDal, EfService>();
            builder.Services.AddScoped<IServiceService, ServiceManager>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddCors(opt=> 
            {
                opt.AddPolicy("OtelApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                }); 
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("OtelApiCors");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
