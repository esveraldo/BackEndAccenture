using Log.Accenture.Application.Interfaces;
using Log.Accenture.Application.Services;
using Log.Accenture.Domain.Interfaces.Persistence;
using Log.Accenture.Domain.Interfaces.Repositories;
using Log.Accenture.Domain.Interfaces.Services;
using Log.Accenture.Domain.Services;
using Log.Accenture.Infra.Data.Context;
using Log.Accenture.Infra.Data.Repositories;
using Log.Accenture.Infra.Logs.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Log.Accenture.Api
{
    public static class Setup
    {
        public static void AddRegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ILogSystemAppService, LogSystemAppService>();
            builder.Services.AddTransient<ILogSystemDomainService, LogSystemDomainService>();
            builder.Services.AddTransient<ILogSystemRepository, LogSystemRepository>();
            builder.Services.AddTransient<ILogSystemPersistence, LogSystemPersistence>();
        }

        public static void AddEntityFrameworkService(this WebApplicationBuilder builder)
        {
            //var connectionString = builder.Configuration.GetConnectionString("Logs");
            //builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
            //builder.Services.AddDbContext<SqlServerContext>(options => options.UseInMemoryDatabase("TestAccenture"));

            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=true;Trusted_Connection=false;";
            builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddAutoMapperServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
