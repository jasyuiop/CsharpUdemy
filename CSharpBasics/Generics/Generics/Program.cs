using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    /*
     Örneğin aşağıdaki gibi bir yapım olsun, IProductdal ile ICostumerdal
     işlemleri çok benzer, ikisinin arasındaki tek fark değişkenler
     Generics'lerle sıkıkla yaptığımız operasyonları nesne bazlı olarak
     değiştirebileceğimiz ben bu nesne ile çalışacağım diyebileceğimiz
     bir yapı oluşturabiliriz.
     Generic bir yapıyı oluşturmak için örneğin interface'e, class'a
     abstruct class'a farketmez, hepsinin sonuna <T> <Sdasdas> gibi bir
     parametre eklememiz yeterli ama genelde T eklenir, T type 'dan geliyor.
     */
    //class Customer { }
    //class Product { }
    //interface IProductdal
    //{
    //    List<Product> GetAll();
    //    Product Get(int id);
    //    void Add(Product product);
    //    void Delete(Product product);
    //    void Update(Product product);
    //}
    //interface ICustomerdal
    //{
    //    List<Customer> GetAll();
    //    Customer Get(int id);
    //    void Add(Customer customer);
    //    void Delete(Customer customer);
    //    void Update(Customer customer);
    //}

    //Artık böyle yapmak yerine şu şekilde yapabiliriz

    class Customer { }
    class Product { }
    interface IRepository<T>
    {
        // genel isim olarak'ta entity verdim ..
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
    // artık gelip
    interface ICustomerdal : IRepository<Customer> { }
    interface IProductdal : IRepository<Product> { }
    // senin artık IRepository'sin çalışma bu dediğim zaman işlem tamamdır.

    class ProductDal : IProductdal
    {
        // deyip implemente ettiğim zaman hepsi geliyor
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
    class CustomerDal : ICustomerdal
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
