using System;

namespace DegerVeReferansTip
{
    class Program
    {
        static void Main(string[] args)
        {
            // class, string, interface, abstract classlar, arrays ... bunlar referans tip
            // int, bool, enum, double, decimal değer tiptir.

            // değer tipler değerler üzerinden işlem yapar, referans göstermez yani ;
            // bellekte referans numarası yoktur değeri vardır ve bunlar üzerinden hareket eder.
            int number1 = 10;
            int number2 = 20;
            number2 = number1;
            number1 = 30; // number1'i 30 yapmam number2'nin değerini değiştirmeyecek
            Console.WriteLine(number2);

            // referanslara gelince;

            string[] cities1 = new string[] { "Ankara", "Adana", "Yozgat" };
            string[] cities2 = new string[] { "Antalya", "Mersin", "Tosya" };
            // cities2 ye cities1'i atarsam bu şu anlama geliyor;
            /*
             arrayler referans tip olduğu için cities2'nin değerleri cities1 olmuyor, olan şey şu 
             cities2'nin referansı cities1'in referansı oluyor.
             bu da şu demek;
             cities1 'i bellekte new ile oluşturdukya, bellekte değişkenin kendisini ve referans değerini tutan bir yer var,
             birde değerini tutan yer var. referans değere işaret ediyor.
             örneğin cities1'in bellekteki referans adresi 101, cities2'nin referans adresi 102
             biz cities2 = cities1; diyerek aslında cities2'nin üzerindeki referans adresini çizerek yerine cities1'in referans
             adresini yazıyoruz. böyle olunca da 102'nin hiçbir anlamı kalmıyor, 102'yi tutan kimse olmadığından
             garbage collector onu bellekten atacak, yani 102 numaralı referans adresi ve değeri new string[] { "Antalya", "Mersin", "Tosya" };
             bellekten uçacak.
             */
            cities2 = cities1;

            /*
             * artık cities2' de referans adresi 101 olana bakıyo ve new string[] { "Antalya", "Mersin", "Tosya" } değerin bir anlamı yok artık.
             biz cities1'in 0'ncı elemanını değiştirirsek artık cities2'nin referans numarası 101 olduğundan
             cities2[0] dediğimizde İstanbul değerini görüyoruz
             cities2'nin bellekte baktığı yerde artık şu değerler var { "İstanbul", "Adana", "Yozgat" };
             */
            cities1[0] = "İstanbul";
            Console.WriteLine(cities2[0]);

            /*
             İşin özüne gelirsek örneğin şöyle bir şey yapsam;
             diyelimki database'den veri çektim doldurdum datatable'ımı daha sonra bu veriyi değiştirmek istiyorum gelirde şöyle yaparsam;
             
             DataTable dataTable = new DataTable();
             DataTable dataTable2 = new DataTable();
             dataTable2 = dataTable;
                
             burada performans kaybı yaşarım çünkü iki tane nesne new'lenmiş yani 2 tane farklı referans var, daha sonra
             dataTable2 = dataTable; diyerek dataTable2 değişkeninde yaptığım new işlemini tamamen uçurdum çünkü garage collector
             bu referansın kullanılmadığını anlayacak ve içindeki değerler ile birlikte ramdan atacak.
             new'lemek bellekteki en pahalı işlemlerden biri onun yerine şöyle yapsaydım;

             DataTable dataTable = new DataTable();
             DataTable dataTable2;
             dataTable2 = dataTable;

             çok daha performanslı bir kod yazmış, gereksiz yere bellek tahsis etmemiş olacaktım.
             */


        }
    }
}
