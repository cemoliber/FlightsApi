using FlightsApi.Models;
using FlightsApi.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlightsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<FlightStoreDatabaseSettings>(//program.cs addings starts here
                builder.Configuration.GetSection(nameof(FlightStoreDatabaseSettings)));

            builder.Services.AddSingleton<IFlightStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<FlightStoreDatabaseSettings>>().Value);

            builder.Services.AddSingleton<IMongoClient>(s =>
                new MongoClient(builder.Configuration.GetValue<string>("FlightStoreDatabaseSettings:ConnectionString")));

            builder.Services.AddScoped<IFlightService,FlightService>();//program.cs addings finish here

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
        }
    }
}