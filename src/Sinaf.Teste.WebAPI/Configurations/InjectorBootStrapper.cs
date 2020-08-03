using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Sinaf.Teste.Data.Context;
using Sinaf.Teste.Data.Repositories;
using Sinaf.Teste.Data.UnitOfWork;
using Sinaf.Teste.Domain.Interfaces.Repositories;
using Sinaf.Teste.Domain.Interfaces.Services;
using Sinaf.Teste.Domain.Notification;
using Sinaf.Teste.Domain.Services;
using Sinaf.Teste.WebAPI.AutoMapper;
using System;

namespace Sinaf.Teste.WebAPI.Configurations
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region [ Infra ]

            services.AddDbContext<SinafContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("SinafConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IApoliceRepository, ApoliceRepository>();
            services.AddScoped<ICorretorRepository, CorretorRepository>();

            #endregion

            #region [ Services ]

            services.AddScoped<NotificationContext>();
            services.AddScoped<IApoliceService, ApoliceService>();

            #endregion

            #region [ AutoMapper ]

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region [ Swagger ]

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Apólices de Seguros",
                        Version = "v1",
                        Description = "API REST criada para cadastro e consulta de apólices",
                        Contact = new OpenApiContact
                        {
                            Name = "Thiago Garcia",
                            Url = new Uri("https://www.linkedin.com/in/thiago-garcia-developer/")
                        }
                    });
            });

            #endregion
        }

        public static void RegisterApps(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Apólices de Seguros V1");
            });
        }
    }
}
