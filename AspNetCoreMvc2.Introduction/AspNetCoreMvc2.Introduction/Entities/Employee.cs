using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // ekledim
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc2.Introduction.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        // Data Annotations kullanarak her sayfada örneğin isim vermektense inputa direkt böyle
        // First Name değerini aldığım yer için inputa label geçebilirim.
        // Fluent Validation'a bak
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CityId { get; set; }



    }
}
