using System;
using System.Collections.Generic;

namespace KendiHataSinifimiziYazalim
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Find();
            //}
            //catch (RecordNotFoundException exception)
            //{
            //    Console.WriteLine(exception.Message);
            //}
            // Bu çirkin görüntü yerine action delegasyonunu kullanarak
            // şu şekilde de yazabiliriz
            HandleException(() =>
            {
                Find();
            });
        }

        private static void HandleException(Action action)
        {
            try
            {
                // gönderdiğim şey action'a düştü ya
                // sıkıntı yoksa çalıştır diyoruz.
                action.Invoke();
            }
            catch (RecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Find()
        {
            List<string> students = new List<string> { "Emre", "Levent", "Burak" };
            if (!students.Contains("Ahmet"))
            {
                // throw genelde hatayı, verdiğin şeye fırlatmak için kullanılıyor.
                throw new RecordNotFoundException("Record Not Found!");
            }
            else
            {
                Console.WriteLine("record found!");
            }
        }
    }
}
