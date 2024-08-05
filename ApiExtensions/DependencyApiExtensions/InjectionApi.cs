using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Generic;
using Academia.infrastructure.Context;
using Academia.infrastructure.Repositories;
using Academia.infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiExtensions.DependencyApiExtensions
{
    public static class InjectionApi
    {
        public static IServiceCollection AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            //Configurando Controllers
            services.AddControllers()
                .AddJsonOptions(op =>
                {
                    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());// mostra no Schemas do swagger os valores do enum
                    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                .AddNewtonsoftJson(op => op.SerializerSettings.Converters.Add(new StringEnumConverter()));


            //Configurando Banco
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(
                opt => opt.UseSqlServer(connectionString));

            //Injeções de dependencia
            services.AddScoped(typeof(IGeneric<>), typeof(RepositoryBase<>));
            services.AddScoped<IAlunoService, AlunoRepository>();
            services.AddScoped<IUnitofWork, UnitOfWork>();

            return services;
        }
    }
}
