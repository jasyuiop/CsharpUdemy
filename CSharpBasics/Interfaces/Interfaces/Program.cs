using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo();
            //InterfacesIntro();

            // örneğin bir veriyi hem şirketin oracle db'sine hemde projede kullandığımız sqlservere kayıt etmek istiyoruz.
            // bu sayede tek bir veriyi iki database'e birden ekleyebiliyoruz.
            ICustomerDal[] customerDals = new ICustomerDal[2] { new SqlServerCustomerDal(), new OracleServerCustomerDal() };
            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }
        }
    }

    //private static void Demo()
    //{
    //    // katmanlar arası geçişte yoğun ölçüde interface kullanılıyor
    //    // crud işlemlerimizi 2 ayrı db için uyumlu hale getirdik.
    //    CustomerManager customerManager = new CustomerManager();
    //    customerManager.Add(new OracleServerCustomerDal()); // oracle destekli 
    //    customerManager.Add(new SqlServerCustomerDal());
    //}

    //private static void InterfacesIntro()
    //{
    //    PersonManager manager = new PersonManager();
    //    manager.Add(new Customer { Id = 1, FirstName = "Emre", LastName = "Nefesli", Adress = "Yozgat" });

    //    manager.Add(new Student { Id = 1, FirstName = "Levent", LastName = "Aydemir", Department = "Ybs" });
    //}

    interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

    }
    class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
    }
    class Student : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
    /*
     Interface kullanarak 2 class içinde aynı propsları tanımladım böylelikle örneğin database'e veri kaydederken
     ayrı ayrı metotlar kullanmak yerine tek bir metottan 2 benzer işlemi halletim.
     */
    class PersonManager
    {
        // örneğin database'e kişi ekleyeceğiz.
        public void Add(IPerson person)
        {
            Console.WriteLine(person.FirstName);
        }
    }
}
