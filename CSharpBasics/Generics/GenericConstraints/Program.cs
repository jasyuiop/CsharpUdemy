using System;

namespace GenericConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Generic'lere gelen tipleri kısıtlamak için
             generic constraint'leri kullanırız.*/

            /*
             class yazılırsa kısıta referans tiplerin olabileceğini belirtir yani string'i de kapsar
             ama int'i kapsamaz mesela hata verir. ayrıca class, class yazılmasını söylemez referans
             tipi söylüyor dikkat.

              class, new() dersem; referans tip olmalı ama aynı zamanda new'lene bilmeli(türetilebilmeli)
              o zaman string'i de eleriz, string new'lenebilen bir tip değil.

              mesela IEntity diye bir kısıtta belirtebilirim bu şunu sağlar;
              sadece IEntity ile implemente edilmiş tipleri kabul et.

              sadece değer tip isteseydim struct yazabilirdim, struct değer tiplere karşılık gelir.
             */
        }
    }
    // generic'e gelen parametre T bizde burada where T: şeklinde başlıyoruz kısıtlara.
    interface IRepository<T> where T:class ,new()
    {
        // genel isim olarak'ta entity verdim ..
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
