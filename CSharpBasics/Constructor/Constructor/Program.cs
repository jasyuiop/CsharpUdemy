using System;

namespace Constructor
{
    class Program
    {
        // Yapıcı Metot
        static void Main(string[] args)
        {
            // yapıcı metotlar bir classdan nesne yaratırken '()' kullandığımızda çağrılır.
            // classın ismi ile aynı isme sahip bir metottur.
            CustomManager customManager1 = new CustomManager(10);

            CustomManager customManager2 = new CustomManager();

            Product product = new Product(1, "emre");
        }
    }
    class CustomManager
    {
        // ctor yaz tabla otomatik olarak class'ın constructor'unu oluşturuyor.
        // Constructor; bir sınıfın ihtiyaç duyduğu farklı parametreler varsa ve kullanıma göre değişkenlik gösteriyorsa bundan yararlanabiliriz.

        private int _count; // private bir field alt cizgi ile başlatılır, isimlendirme standartıdır.
        public CustomManager(int count)
        {
            _count = count;
        }

        // consturctorlar overload'da edilebilir.
        public CustomManager()
        {
        }

        public void List()
        {
            Console.WriteLine("Listed {0} items", _count);
        }
        public void Add()
        {
            Console.WriteLine("Added");
        }
    }

    class Product
    {
        // Constructları sınıf içerisindeki property, field vb.. gibi şeylere hızlıca değer atamak içinde kullanırız
        public int Id { get; set; }
        public string Name { get; set; }
        public Product()
        {

        }
        private int _id;
        private string _name;
        public Product(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
