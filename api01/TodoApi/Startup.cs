using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using TodoApi.Repositorio;

namespace TodoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ReceitaDespesaContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
           
            services.AddTransient<IPessoaRepositorio,PessoaRepositorio>();
            services.AddTransient<ICategoriaRepositorio,CategoriaRepositorio>();
            services.AddTransient<IRecDesRepositorio,ReceitaDespesaRepositorio>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(o => o.AddPolicy("CORSdev", builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            }));        
        }

        public void Configure(IApplicationBuilder app)
        {
            // Shows UseCors with named policy.
            app.UseCors("CORSdev");
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}