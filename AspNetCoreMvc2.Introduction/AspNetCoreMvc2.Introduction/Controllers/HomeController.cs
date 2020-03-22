using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc2.Introduction.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    /*
     * Controller action'ları kullanıcıya birşeyler döndürmek için kullanılır.
     */
    public class HomeController : Controller
    {
        // Index sayfasında ekrana bir string dönderdik
        public string Index()
        {
            // /home/index
            return "helloooğğ";
        }
        // Index2 ismine sahip bir view'i arar, bulur ve çalıştırır
        public ViewResult Index2()
        {
            // /home/index2
            return View();
        }
        public ViewResult Index3()
        {
            // data gönderiyoruz
            // datayı bu şekilde gönderirsek, ileride Index3 view'imize birden çok data gönderirken
            // çok sıkıntılar çekeriz :D , bunun için kapsülleme işlemi yapmalıyız.
            // view'i eklerken template'i ve model class'ı seç!!
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, FirstName="emre", LastName="nefesli", CityId=1},
                new Employee{Id=1, FirstName="levent", LastName="aydemir", CityId=2}
            };

            // bu tarz data göndermeler viewback, viewdata ile yapılmaz!! yapılır da yapma!
            List<string> cities = new List<string> { "İstanbul", "Ankara" };

            // generate new type => model'in altına oluştur bu class'ı
            var model = new EmployeeListViewModel
            {
                Employees = employees,
                Cities = cities
            };
            return View(model);
        }
        public IActionResult Index4()
        {
            // IActionResult ile ActionResult türünde nesneler döndürebiliriz
            // bunlardan birisi StatusCodeResult
            /*
             * StatusCodeResult =>
             * Durum kodu sonucu, bir http isteği yaptığımızda sonuç döner içerisinde de
             * işlemin başarılı olup olmadığı 404 vb.., database'e ekleme yaptın 201
             * navigate oldu 300lü hatalar, 400lü hatalar bad request falan..
             */
            return Ok();
            //StatusCode(200)'de yazabiliriz 200'e karşılık gelen Ok() da yazabiliriz.
        }
        public IActionResult Index5()
        {
            // chrome'dan f12'e bas index5'te hata mesajını yapıştıracak altta.
            return StatusCode(400); // BadRequest()'de yazabiliriz.
            // bulunamadı için NotFound()..
        }

        /*
         RedirectResult() : bir aksiyon sonucunda başka bir aksiyonu tetikleyip yönlendirmek için
         kullanılır. örneğin dbye veri ekleyince anasayfaya geri dönmek vb...

         StatusCode'da RedirectResult'da da IActionResult tipini veya direkt bu kendi tiplerini
         yazabiliriz. burada direkt RedirectResult tipini verdim mesela..
         */
         public RedirectResult Index6()
        {
            return Redirect("/Home/Index4");
        }
        public IActionResult Index7()
        {
            // diye de kullanabiliriz.
            // genellikle de bunu kullanılırız.
            return RedirectToAction("Index5");
        }
        public IActionResult Index8()
        {
            return RedirectToRoute("default");
        }

        public JsonResult Index9()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, FirstName="emre", LastName="nefesli", CityId=1},
                new Employee{Id=1, FirstName="levent", LastName="aydemir", CityId=2}
            };
            return Json(employees);
            // listeyi json formatında index9'a dönderdik.
        }

        public IActionResult RazorDemo()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, FirstName="emre", LastName="nefesli", CityId=1},
                new Employee{Id=1, FirstName="levent", LastName="aydemir", CityId=2}
            };

            // bu tarz data göndermeler viewback, viewdata ile yapılmaz!! yapılır da yapma!
            List<string> cities = new List<string> { "İstanbul", "Ankara" };

            // generate new type => model'in altına oluştur bu class'ı
            var model = new EmployeeListViewModel
            {
                Employees = employees,
                Cities = cities
            };
            return View(model);
        }

        /*
         Query string ile model binding =>
         model binding şudur; bir aksiyondur, controller aksiyonu çalıştığında ona 
         parametre göndermektir.

            örneğin kullanıcının isminde geçen harfe göre filtreliycez.
         */
        public JsonResult Index10(string key)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, FirstName="emre", LastName="nefesli", CityId=1},
                new Employee{Id=1, FirstName="levent", LastName="aydemir", CityId=2}
            };

            // eğer key değeri null ise
            if (String.IsNullOrEmpty(key))
            {
                return Json(employees);
            }

            var result = employees.Where(e => e.FirstName.ToLower().Contains(key));
            return Json(result);
            // değerimizi şöyle gönderiyoruz https://localhost:44396/home/index10?key=n
        }

        // Form datası ile model binding
        public ViewResult EmployeeForm()
        {
            return View();
        }

        // route datası ile model binding
        public string RouteData(int id)
        {
            return id.ToString();
            //https://localhost:44396/home/routedata/10
        }

        /*Tag helpers ile html taglerimizi yönetebiliyoruz*/
    }
}