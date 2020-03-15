using System;

namespace RecapDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Logger = new DatabaseLogger();
            customerManager.Add();
        }
        class FileLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("logged to file");
            }
        }
        class DatabaseLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("logged to database");
            }
        }
        class SmsLogger : ILogger
        {
            public void Log()
            {
                Console.WriteLine("logged to sms");
            }
        }
        class CustomerManager 
        {
            // customerManager tarafında ILogger türünden bir property oluşturduk ve örneğin müşteri log'u sms'mi istiyor db mi istiyor
            // onu direkt olarak main'de "customerManager.Logger ="'de kodu karmaşıklaştırmada ihtiyacı karşılayabildik.
            // bu örnek için; sadece bir tanesi farklı olsaydı örneğin database, virtual methot tanımlayıpta yapabilirdik
            // veya bir tane method her yerde değişecek, bir tanesi her yerde aynı olacak bunu da abstract ile çözebilirdik.
             
            public ILogger Logger { get; set; } // bu yaptığımız property injection, constructer ile de yapabilirdik.
            public void Add()
            {
                Logger.Log();
                Console.WriteLine("customer added");
            }
        }
        interface ILogger
        {
            void Log();
        }
    }
}
