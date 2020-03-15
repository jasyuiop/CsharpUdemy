using System;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            // private sadece tanımlandığı blok içerisinde kullanılabilir.
            // private ile protected'in farkı ise protected inherit edildiği sınıflarda kullanabilir. ör;

            // class'ların önüne erişim belirteci yazmazsak aldığı default değer internal'dir.
            // internal bir class bağlı olduğu projede bu örnek için AccesModifiers, referansa gerek kalmadan kullanabiliriz.
            // claslar sadece internal ve public olur. (iç içe classlar hariç tabi)

            // public yaptığımız classlar farklı bir projeden de kullanılabilir.
            // (referance managerden referans almamız ve using ile dahil etmemiz lazım ama)
        }
        class Customer
        {
            protected int Id { get; set; }
            private string Name { get; set; }

            public void Save() { }
            public void Delete() { }
        }
        class Student : Customer
        {
            public void Save2()
            {
                Id = 1;
                // Name private olduğu için kullanamıyoruz mesela..
            }
        }
        internal class Course
        {
            public string Name { get; set; }
        }
    }
}
