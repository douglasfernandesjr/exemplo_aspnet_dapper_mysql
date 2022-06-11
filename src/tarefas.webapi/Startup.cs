using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using tarefas.webapi.Database;
using tarefas.webapi.Domain.Services;
using tarefas.webapi.Repository;

namespace tarefas.webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "tarefas.webapi", Version = "v1" });
            });

            string variavelDeSistema = Configuration["ConnectionString"];
            string connectionString = Environment.GetEnvironmentVariable(variavelDeSistema);

            if (String.IsNullOrWhiteSpace(connectionString)) {
                Console.WriteLine("A v�riavel de ambiente com o nome " + variavelDeSistema + "n�o foi encontrada");
                Console.WriteLine("Este exemplo est� configurado para pegar a connection string de um vari�vel de ambiente");
            }

            services.AddSingleton(new DatabaseConfig(connectionString));

            services.AddSingleton<IDatabaseSetup, SqliteDatabaseSetup>();

            services.AddTransient<TarefaRepository>();

            services.AddTransient<TarefaService>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "tarefas.webapi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            serviceProvider.GetService<IDatabaseSetup>().RunSetup();
        }
    }
}
