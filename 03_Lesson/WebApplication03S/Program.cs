
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebApplication03S.Abstraction;
using WebApplication03S.Models;
using WebApplication03S.Mutatin;
using WebApplication03S.Query;
using WebApplication03S.Repo;
using WebApplication03S.Services;

namespace WebApplication03S
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
            builder.Services.AddAutoMapper(typeof(MappingProFile));
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Configuration.GetConnectionString("Connection");

            builder.Services.AddMemoryCache();
            //builder.Services.AddMemoryCache(o => o.TrackStatistics = true);
            //03s------------------
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<MySimpleQuery>()
                .AddMutationType<MySimpleMutation>();

            builder.Services.AddSingleton<DBContext>();

            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.AddSingleton<IGroupService, GroupService>();
            builder.Services.AddSingleton<IStoreService, StoreService>();
            //03S--------------

            builder.Services.AddSingleton<IProductRepository,ProductRepository>();

            var confBuilder = new ConfigurationBuilder();
            confBuilder.SetBasePath(Directory.GetCurrentDirectory());
            confBuilder.AddJsonFile("appsettings.json");
            var cfg = confBuilder.Build();

            builder.Host.ConfigureContainer<ContainerBuilder>(contaierBuilder =>
            {
                contaierBuilder.RegisterType<ProductRepository>().As<IProductRepository>();
            });

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //var staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles");
            //if (!Directory.Exists(staticFilesPath))
            //{
            //    Directory.CreateDirectory(staticFilesPath);
            //}

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(staticFilesPath),
            //    RequestPath = "/static"
            //});

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGraphQL();
            app.MapControllers();

            app.Run();
        }
    }
}