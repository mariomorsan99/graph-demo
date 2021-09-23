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
using WebApi.Graph;
using WebApi.Persistencia;
using Microsoft.EntityFrameworkCore;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Server.Kestrel.Core;
namespace WebApi
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
             var cadena= "Data Source=HDFLAPMORALESMA; Initial Catalog=Tienda; Integrated Security=True;";

              services.AddDbContext<TiendaContext>(opcions=>{
                opcions.UseSqlServer(cadena);
                });

                services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver (s.GetRequiredService));

                services.AddScoped<ProductoSchema>();
                services.AddGraphQL().AddGraphTypes(ServiceLifetime.Scoped);
                services.Configure<KestrelServerOptions>(options =>
                {
                    options.AllowSynchronousIO = true;
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           app.UseGraphQL<ProductoSchema>();
           app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

        }
    }
}
