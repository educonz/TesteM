using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Configuration;
using Core.Data.Repository;
using Core.Injector;
using Data;
using Domain.Autenticacoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TesteMeta.Filters;

namespace TesteMeta
{
    public class Startup
    {
        private IInjector _injectorService;

        public Startup(IHostingEnvironment environment)
        {
            Configuration = AppConfiguration.Configure(environment.EnvironmentName, environment.ContentRootPath);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _injectorService = new DefaultServiceInjector(services);
            new TesteMetaBootstrapper().Load(_injectorService);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services
                .AddMvc(options =>
                {
                    options.Filters.Add(new AuthFilter(_injectorService.Resolve<IAutenticacao>(), _injectorService.Resolve<IAppConfiguration>()));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                });

            DbInitializer.Seed(_injectorService.Resolve<IRepositoryGeneric>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
