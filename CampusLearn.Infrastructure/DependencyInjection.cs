using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CampusLearn.Infrastructure.Data;

namespace CampusLearn.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("SupabaseConnection");
            services.AddDbContext<CampusLearnDbContext>(
                options => options.UseNpgsql(connection));

            return services;
        }
    }
}
