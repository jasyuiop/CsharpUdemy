using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc2.Introduction.Models;
using AspNetCoreMvc2.Introduction.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
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
            //db için connectionstring.
            var connection = @"Server=(localdb)\mssqllocaldb;Database=SchoolDb;Trusted_Connection=true";
            // yapılandırmayı gerçekleştirip SchoolContext'in yapıcısına connectionstringimi verdim.
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(connection));

            // Dependency injection için burada şöyle birşey yazıyorum =>
            // Birisi ICalculator türünden bişi isterse ona Calculator18'i ver.
            /*AddScoped => Singleton'dan farklı olarak; bir istekte bulunduğumuzda
             instance oluşturlur, ikinci kullanıcı da istekte bulunduğunda onun içinde
             yeni bir instance oluşturulur, kullanıcının işi bittikten sonra bellekten
             kaldırılır.*/
            services.AddScoped<ICalculator, Calculator18>();

            /* AddSingleton => örneğin kullanıcı employee sayfasına girdiği anda
             Calculator18 'i injecte eder, yani ICalculator'a ihtiyaç duyulduğu anda
             injection işlemi gerçekleşir. aslında bunu yaparken Calculator18'dan new bir nesne
             üretiyor referans oluşturuyor, Daha sonra başka bir kullanıcıda employee'i çağırında
             ilk kullanıcının oluşturduğu Singleton bellekte durur(IIS'Ten çıkartmadığımız sürece)
             ve o Instance(programının çalışması sırasında var olan herhangi bir nesnenin somut bir oluşumudur.)
             kullanıcıya verilir. Singletion'u sadece işlem yapan veri tutmayan metotlar vb. kullanırız
             (crud işlemlerini gerçekleştiren nesneler için kullanabiliriz)
             Tek sıkıntısı uygulama çalıştığı sürece bellekte durur bunu sadece çok sıklıkla çağırlan 
             sınıflar vb. tarzı yerlerde kullanırız.*/
            //services.AddSingleton<ICalculator, Calculator18>();

            /*
             AddTransient => Yapılan her istekte Scoped'te olduğu gibi yeni bir nesne örneği oluşur
             fark şudur;

                     private ICalculator _calculator;
                     private ICalculator _calculator2;
                     public EmployeeController(ICalculator calculator, ICalculator calculator2)
                     {
                         _calculator = calculator;
                         _calculator2 = calculator2;
                     }
             diye kodumuz olsun, Transient'ta => calculator, calculator2 için ayrı ayrı instance'ler
             üretilir, AddScoped'ta ise => tek bir çağırım olduğunda iki tane nesne örneğine ihtiyacımız
             olsa da ikiside ICalculator olduğundan aynı nesne olarak kabul edilir ve tek bir instance 
             üretilir.

              Bu istekte;
              public string Calculate()
              {
                    _calculator2.Calculate(500).ToString();
                    return _calculator.Calculate(100).ToString();
              }
              Transient'te bu ikisi, 2 ayrı nesnedir. Scoped'te ise ikiside aynı nesnedir,(çünkü aynı tip)
              aynı referansı kullanırlar.
             */
            services.AddTransient<ICalculator, Calculator18>();
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
