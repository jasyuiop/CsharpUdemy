using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    [Route("admin")] // admin/ gelirse burası çalışsın diyoruz
    public class AdminController : Controller
    {
        // Indeximiz olmadığı için hangi sayfa çalışacak bilinmiyor, 404 hatası dönüyor
        // bu yüzden mesela save'ı çalıştırmak istiyoruz.

        [Route("")] // "" yaparsak sen default route'sın demiş oluruz. (diğerlerini belirtmemiz lazım)
        [Route("save")] // admin/save şeklinde manuel olarakta çağırabiliriz
        [Route("~/save")] // ~/ diyorsak önündeki herşeyi iptal et, save diye çağırınca da sen çalış anlamına geliyor.
        public string Save()
        {
            return "Saved";
        }

        [Route("delete/{id?}")] // olarak parametre de geçebiliriz.(opsiyonel tabi ? var)
        public string Delete(int id = 0)
        {
            return string.Format("Deleted {0}",id);
        }

        [Route("update")]
        public string Update()
        {
            return "Updated";
        }
    }
}