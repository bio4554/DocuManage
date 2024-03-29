using DocuManage.Common.Interfaces;
using DocuManage.Common.Services;
using DocuManage.Data.DB;
using DocuManage.Data.Interfaces;
using DocuManage.Logic.Interfaces;
using DocuManage.Logic.Services;
using Microsoft.EntityFrameworkCore;

namespace DocuManage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();

            var config = new Config()
            {
                BlobStorageConnectionString = configuration["ConnectionStrings:BlobStorageConnectionString"],
                BlobStorageContainerName = configuration["BlobStorageContainerName"]
            };

            var connectionString = configuration["ConnectionStrings:Postgres"];

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DI
            builder.Services
                .AddLogging()
                .AddSingleton<IConfig>(config)
                .AddDbContextFactory<BackendContext>(opt => opt.UseNpgsql(connectionString))
                .AddDbContext<DbContext, BackendContext>(opt => opt.UseNpgsql(connectionString))
                .AddScoped<IDocumentRepository, DocumentRepository>()
                .AddScoped<IDocumentService, DocumentService>()
                .AddScoped<IBlobService, BlobService>()
                .AddScoped<IFileService, FileService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            );
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}