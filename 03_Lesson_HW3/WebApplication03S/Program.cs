
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebApplication03HW3.Abstraction;
using WebApplication03HW3.Mapper;
using WebApplication03HW3.Models;

using WebApplication03HW3.Repo;


namespace WebApplication03HW3
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
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Configuration.GetConnectionString("Connection");

            builder.Services.AddMemoryCache();
            //builder.Services.AddMemoryCache(o => o.TrackStatistics = true);

            builder.Services.AddSingleton<DBContext>();

            builder.Services.AddSingleton<IProdInStoreRepository, ProdInStoreRepository>();
   

            var confBuilder = new ConfigurationBuilder();
            confBuilder.SetBasePath(Directory.GetCurrentDirectory());
            confBuilder.AddJsonFile("appsettings.json");
            var cfg = confBuilder.Build();

            builder.Host.ConfigureContainer<ContainerBuilder>(contaierBuilder =>
            {
                contaierBuilder.RegisterType<ProdInStoreRepository>().As<IProdInStoreRepository>();
            });

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.MapGraphQL();
            app.MapControllers();

            app.Run();
        }
    }
}