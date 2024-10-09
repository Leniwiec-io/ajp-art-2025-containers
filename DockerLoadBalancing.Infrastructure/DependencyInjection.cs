using DockerLoadBalancing.Infrastructure.Data;
using DockerLoadBalancing.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerLoadBalancing.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextFactory<PeopleContext>(options => { options.UseSqlite(config.GetConnectionString("SQLite")); });
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            return services;
        }
    }
}
