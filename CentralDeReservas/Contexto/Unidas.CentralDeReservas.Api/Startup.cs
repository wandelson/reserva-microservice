using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Reflection;
using Unidas.CentralDeReservas.Api;
using Unidas.CentralDeReservas.Aplicacao.Reservas.Commands;
using Unidas.CentralDeReservas.Dominio.Reservas.Interfaces;
using Unidas.CentralDeReservas.Infra.Contexts;
using Unidas.CentralDeReservas.Infra.Repositories;
using Unidas.CentralDeReservas.Infra.Uow;
using Unidas.CentralDeReservas.Services;

namespace Unidas.Checkout.Api
{
    public class Startup : Servicos.Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
            : base(configuration)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public override void ConfigureServices(IServiceCollection services)
        {            
            services.AddDbContext<ReservaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-br");

            // Infra - Data
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ReservaContext>();

            // Domain - Service
            services.AddMediatR(typeof(IRegister).GetTypeInfo().Assembly);

            services.AddLogging();

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<CriarReservaCommand>());

            base.ConfigureServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            base.Configure(app, env, loggerFactory);
        }
    }
}