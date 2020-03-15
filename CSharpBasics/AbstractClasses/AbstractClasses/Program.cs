using System;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            // Abstract Classlar interface ile inheritance'ın birleşimine benzer bi yapıdır.

            // interface'ler gibi abstract class'lar da kendisinden türetilemez.
            Database db = new Oracle(); // new Database yazamazdık yani.
            db.Delete();
            db.Add();

            Database db2 = new SqlServer();
            db2.Delete();
            db2.Add();

            // inheritance class gibidir. sadece 1 abstract classtan inherite edilebilir, birden fazla abstract class veremeyiz yani bi classa.
            // classlarla ilgili aynı kuralda burda geçerli istediğimiz kadar interface ekleyebiliriz yani.
        }
        // örneğin database classındaki Add metotu her db için aynıdır, fakat delete metotu farklı o zaman;
        abstract class Database
        {
            public void Add()
            {
                Console.WriteLine("added by default");
            }
            public abstract void Delete(); // her yer için ayrı olabildiğinden zaten özellik olarak içine birşey yazılmaz sadece tanımlanır.
            // her yerde farklı olacağından, nereye ekliyorsak onu ayrı ayrı implemente etmemiz gerekiyor.
        }
        class SqlServer : Database
        {
            public override void Delete() // implemente ettik.
            {
                //throw new NotImplementedException();
                Console.WriteLine("deleted by sqlserver");
            }
        }
        class Oracle : Database
        {
            public override void Delete() // buraya da implemente ettik
            {
                Console.WriteLine("deleted by oracle");
            }
        }

    }
}
