using System;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // örneğin 2 tane class 1 tane de kalıtım alacağımız class olsun, classlardan birisi mysql, diğeri sqlserver
            // kalıtım class'ı da Database işlemlerini yapacağımız class.
            // database class'ındaki add metotu mysql'de değişime uğramak zorunda çünkü o şekilde çalışamaz
            // bunu için kalıtım aldığımız classtaki metotu virtual tanımlayıp, değiştireceğimiz yerde override ile ezip o class için nasıl çalışacağını
            // tekrar yazabiliriz.

            MySql mysql = new MySql();
            mysql.Add(); // override ile ezip o metotun yeni çalışma biçimini verdik.

            SqlServer sqlserver = new SqlServer();
            sqlserver.Add(); // sqlserver için aynı şekilde çalışmaya devam etti.

            // kalıtım olacak sınıftaki, daha sonradan başka yerde değişecebilecek metotları virtual olarak tanımlamak mantıklı bi seçenek.
            // interface'de böyle bi işlem yapamayız, interface ile inheritance arasındaki farklardan biri.

        }
        class Database
        {
            public virtual void Add()
            {
                Console.WriteLine("added by default");
            }
            public virtual void Delete()
            {
                Console.WriteLine("deleted by default");
            }
        }
        class MySql:Database
        {
            public override void Add()
            {
                //base.Add(); kalıtımdan aldığımız sınıfın içindeki methodu aynı şekilde çalıştırır.

                Console.WriteLine("added by Mysql");
            }
        }
        class SqlServer : Database
        {
            // burada kalıtım sınıfından aldığımız metotları ezmediğimiz için aynısı çalışacak.
        }
    }
}
