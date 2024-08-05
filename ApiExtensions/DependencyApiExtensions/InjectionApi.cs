using Academia.Domain.Interfaces;
using Academia.Domain.Interfaces.Generic;
using Academia.infrastructure.Context;
using Academia.infrastructure.Repositories;
using Academia.infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExtensions.DependencyApiExtensions
{
    public static class InjectionApi
    {
        public static IServiceCollection AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
        {
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
