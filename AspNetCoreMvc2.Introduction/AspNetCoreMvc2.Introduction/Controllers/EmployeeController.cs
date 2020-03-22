using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc2.Introduction.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Add()
        {
            var employeeAddViewModel = new EmployeeAddViewModel
            {
                Employee = new Employee(),
                Cities = new List<SelectListItem> // Mvc.Rendering; 'i kullandık SelectListItem için
                {
                    new  SelectListItem{Text="Ankara",Value="5"},
                    new  SelectListItem{Text="Ankara",Value="7"}
                }
            };
            return View(employeeAddViewModel);
        }

        /*
         Form'un içindeki submit buttonu post işlemi yapıyor
         Employee add'lerden hangisini çalıştıracak bilmediği için biz 
         bunu burada attirbute olarak belirtiyoruz.
         */
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            // submit butonuna basınca employee'nin içerisine gelen herşey düşüyor
            // artık buradan alıp db'ye insert falan yapabiliriz..
            return View();
        }
    }
}