using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             Hata yakalarken, catch bloğunda hatanın tipine göre yakalamalar yapabiliriz
             örneğin 5 farklı şekilde hata verebilirse bir try bloğu
             bunu 5 farklı şekilde yakalayıp 5 farklı işlem yaptırabilirim.
             */
            try
            {
                string[] students = new string[2] { "Emre", "Levent" };
                students[2] = "emre";
            }
            // dizi sınırları aşıldı diye bir hata gelecek, ve hemen burada yakaladım
            catch(IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            // eğer yukarıdaki hata değilde başka bir hata gelirse direkt buraya düşecek
            // Exception tipiyle tüm hata tiplerini yakalayabilirim.
            // hatların hepsi SystemException sınıfını base alır, SystemException ise
            // Exception'u base alır.
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
