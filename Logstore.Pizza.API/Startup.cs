using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logstore.Pizza.Aplicacao.Cliente;
using Logstore.Pizza.Aplicacao.Pedido;
using Logstore.Pizza.Dominio.Cliente;
using Logstore.Pizza.Dominio.Endereco;
using Logstore.Pizza.Dominio.Pedido;
using Logstore.Pizza.Dominio.Shared;
using Logstore.Pizza.Infraestrutura.Database;
using Logstore.Pizza.Infraestrutura.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Logstore.Pizza.API
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
            services.AddSwaggerGen();


            var connectionBdPMG = Configuration.GetConnectionString("PGM_Connection");
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionBdPMG));

            services.AddScoped<IClienteServices, ClienteService>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            services.AddScoped<IPedidoServices, PedidoService>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

        }
    }
}
