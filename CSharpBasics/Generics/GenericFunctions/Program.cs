using System;
using System.Collections.Generic;

namespace GenericFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             
             */
            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("Ankara", "Yozgat", "Sivas");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            List<Customer> result2 = utilities.BuildList<Customer>(new Customer { FirstName = "emre" }, 
                new Customer { FirstName = "levent" });
            foreach (var customer in result2)
            {
                Console.WriteLine(customer.FirstName);
            }
        }
    }
    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }
    class Customer
    {
        public string FirstName { get; set; }
    }
}
