using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc2.Introduction.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreMvc2.Introduction
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Dependency injection için burada şöyle birşey yazıyorum =>
            // Birisi ICalculator türünden bişi isterse ona Calculator18'i ver.
            services.AddScoped<ICalculator, Calculator18>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles(); // jquery, boostrap gibi paketleri kullanmak için statik fileları kullan dedim.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvcWithDefaultRoute(); // diyerek'te alttaki yapıyı tek satırla kullanabiliriz

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=home}/{action=index}/{id?}"
            //        //controller olacak defaultu home, action olacak defaultu index
            //        // id geçilebilir ama opsiyonel.
            //        );
            //});

            // Conventional Routing => (standart, geleneksel routing)   
            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index2}/{id?}");

            // Emre/ ile başlıyosa, burada Emre/ sabit, Emre/ ile girince direkt Index3'yi açacak
            routeBuilder.MapRoute("MyRoute", "Emre/{controller=Home}/{action=Index3}/{id?}");
        }

        /*Örneğin sadece bir controllere özel route üretmemiz gerekiyor, bu durumlarda
         kullanacağımız 
         Attribute Routering =>
         */
    }
}
