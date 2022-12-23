using Log.Accenture.Domain.Interfaces.Repositories;
using Log.Accenture.Infra.Data.Context;
using Log.Accenture.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Log.Accenture.UnitTests
{
    public class Setup : Xunit.Di.Setup
    {
        protected override void Configure()
        {
            ConfigureAppConfiguration((hostingContext, config) =>
            {
                #region Ativando a injeção de dependência do xunit

                bool reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);

                if (hostingContext.HostingEnvironment.IsDevelopment())
                    config.AddUserSecrets<Setup>(true, reloadOnChange);

                #endregion
            });

            ConfigureServices((context, services) => {

                #region Banco em memoria para realização dos testes

                //Injetando a connection string na classe SqlServerContext
                services.AddDbContext<SqlServerContext>(options => options.UseInMemoryDatabase(databaseName: "LogSystem"));

                services.AddTransient<ILogSystemRepository, LogSystemRepository>();

                #endregion
            });


        }
    }
}
