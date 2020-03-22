using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreMvc2.Introduction.Entities;
using Microsoft.AspNetCore.Razor.TagHelpers; //ekledim
namespace AspNetCoreMvc2.Introduction.TagHelpers
{
    // ayrıca bunun bir taghelper olabilmesi için htmltargetelement attribute'sini belirtmemiz lazım
    [HtmlTargetElement("employee-list")] // olarak isimlendirdik.
    public class EmployeeListTagHelper : TagHelper // inherite ettik
    {
        private List<Employee> _employees; // metotların dışında tanımladığımız için _ standartına uyduk
        public EmployeeListTagHelper() //dbye işlemleri yapıyoruz varsayalım
        {
            _employees = new List<Employee>
             {
                new Employee{Id=1, FirstName="emre", LastName="nefesli", CityId=1},
                new Employee{Id=2, FirstName="levent", LastName="aydemir", CityId=2}
             };
        }
        // dışardan parametre alabilmek için..
        private const string ListCountAttributeName = "count"; // gönderilen count'u buna bağlayacaz.

        [HtmlAttributeName(ListCountAttributeName)] // git bak Attribute'lerde ListCountAttributeName de olan değer varmı
        public int ListCount { get; set;} // üstüne yazdığım için bunun att'ı oluyor ve buna eşleniyor.

        // tag helper olabilmesi için inherite ettiğimiz classın process'ini ezmemiz lazım
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Output dışarıya çıkartacağımız, oluşturacağımız html'e karşılık gelir
            output.TagName = "div"; // bu listeyi div'in içerisine yaz.
            var query = _employees.Take(ListCount); // sorgu yapacaz
            //Take ile kaç tanesini alacağımızı belirtiyoruz.

            //html oluşturacağımız için StringBuilder sınıfını kullandık.
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var employee in query)
            {
                stringBuilder.AppendFormat("<h2><a href='/employee/detail/{0}'>{1}</a></h2>",employee.Id,employee.FirstName);
            }
            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }
    }
}
