using DotNet8.VerticalSlice_CqrsExample.Api.Repositories.Blog;
using DotNet8.VerticalSlice_CqrsExample.DbService.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.VerticalSlice_CqrsExample.Api
{
    public static class ModularService
    {
        #region Add Services

        public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddRepositoryServices();
            services.AddDbContextService(builder);
            services.AddMediatRService();
            services.AddJsonServices();
            return services;
        }

        #endregion

        #region Add Repository Services

        private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogRepository, BlogRepository>();
            return services;
        }

        #endregion

        #region Add Db Context Service

        private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            }, ServiceLifetime.Transient);

            return services;
        }

        #endregion

        #region Add MediatR Service

        private static IServiceCollection AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));
            return services;
        }

        #endregion

        #region Add Json Services

        private static IServiceCollection AddJsonServices(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            return services;
        }

        #endregion
    }
}