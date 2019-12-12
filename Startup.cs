using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce
{
    public class Startup
    {
        // Adicionar serviços
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
        }
        public int teste { get; set; }

        // Usar serviços
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           app.UseSession();

            

           app.UseMvc(options => {
             options.MapRoute("default","{controller=Product}/{action=Index}/{id?}");
           });
        }
    }
}
