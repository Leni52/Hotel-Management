using AutoMapper;
using ExceptionHandling.Handler;
using HotelManagement.Application.Features.Rooms.Commands;
using HotelManagement.Domain.Data;
using HotelManagement.WebAPI.Profiles;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using static HotelManagement.Application.Features.Rooms.Queries.GetAllRooms;

namespace HotelManagement.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelManagement.WebAPI", Version = "v1" });
            });
            //automapper
            services.AddAutoMapper(typeof(Startup));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RoomProfile());
                mc.AddProfile(new ReviewProfile());
                mc.AddProfile(new BookingProfile());
            });

            //dbcontext and sqlserver


          services.AddDbContext<HotelDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Default")));
           //   services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")), ServiceLifetime.Scoped);
            services.AddScoped<HotelDbContext>();

            //register queries and handlers
            services.AddMediatR(typeof(GetAllRoomsHandler));
            services.AddMediatR(typeof(CreateRoom));
            //add CORS
            services.AddCors((setup) =>
            {
                setup.AddPolicy("default", (options) =>
                {
                    options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelManagement.WebAPI v1"));
            }
            app.UseExceptionHandler(new ExceptionHandlerConfig().CustomOptions);
            app.UseCors("default");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
