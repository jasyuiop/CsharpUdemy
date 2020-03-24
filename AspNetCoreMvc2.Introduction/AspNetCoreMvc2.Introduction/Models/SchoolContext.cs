using AspNetCoreMvc2.Introduction.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc2.Introduction.Models
{
    public class SchoolContext:DbContext
    {
        // Opsiyonları Dependency injection ile alıyoruz
        public SchoolContext(DbContextOptions<SchoolContext> options):base(options) // base'e parametreyi gönderdik.
        {
            //Connection string vb olayları options'dan almamızı sağlayabiliriz artık.
        }
        // Veri tabanındaki Students ile Entity klasörü içerisindeki Student'i eşleştirdik(mapledik)
        public DbSet<Student> Students { get; set; }
    }
}
