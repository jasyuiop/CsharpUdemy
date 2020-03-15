using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Customer customers = new Customer();

            Person[] persons = new Person[3] // person'un kendisi de ayrıca kullanılabilir tabiki..
            {
                new Customer{FirstName = "emre"},
                new Student{FirstName = "levent"},
                new Person{FirstName = "burak"}
            };
        }
    }
    // ! Önemli: bir class'ın sadece bir tane parent'i olabilir(kalıtımını verdiği) intarface'deki gibi çoklu olamaz!..
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    class Customer : Person // bu sayede parent olan persondan gelen property'ler customer için de kullanılabiliyor.
    {
        public string City { get; set; }

    }
    class Student : Person
    {
        public string Department { get; set; }

    }
}
