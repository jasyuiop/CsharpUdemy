using System;
using System.Collections.Generic;
namespace KafadanDenemeler
{
    class Program
    {
        private static double Gpi = 3.14;
        public static double Pi {
            get
            {
                return Gpi;
            }
            set
            {
                if (value < 3.14 && value > 3)
                    Gpi = value;
                else Gpi = 3.14;
                
            }
        }
        void Selamla(string isim, string soyisim)
        {
            Console.WriteLine("hoşgeldin {0} {1}", isim, soyisim);
        }
        static void Selamla2(string isim, string soyisim)
        {
            Console.WriteLine("hoşgeldin " + isim + " " + soyisim);
        }
        static int Toplama(int x,int y)
        {
            return x + y;
        }
        static void Main(string[] args)
        {
            var tureterek = new Program();
            tureterek.Selamla("emre", "nefesli");

            Selamla2("levent", "aydemir"); // static olduğu için türetmedim.
            Console.WriteLine("-------------------------------------------");

            int x = 30;
            int y = 15;
            Console.WriteLine(Toplama(x, y));
            Console.WriteLine("-------------------------------------------");

            int[] dizi = new int[10];
            for(int i = 0; i<10; i++)
            {
                Random r = new Random();
                dizi[i] = r.Next(30);
            }
            foreach(var i in dizi)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("-------------------------------------------");

            string[] dizi2 = { "emre", "levent", "burak" };
            foreach(var s in dizi2)
            {
                Console.Write(s+" ");
            }
            Console.WriteLine("-------------------------------------------");

            List<int> list1 = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                list1.Add(i);
            }
            foreach(var l in list1)
            {
                Console.Write(l+" ");
            }
            Console.WriteLine("\n-------------------------------------------");

            // lifo last in first out
            Stack<int> stack1 = new Stack<int>();
            for (int i = 100; i > 0; i--)
            {
                stack1.Push(i);
            }

            int stackLenght = stack1.Count;
            for(int i = 0; i<stackLenght; i++)
            {
                Console.Write(stack1.Pop()+ " ");
            }
            Console.WriteLine("\n-------------------------------------------");

            // fifo first in first out
            Queue<int> queue1 = new Queue<int>();
            for (int i = 100; i > 0; i--)
            {
                queue1.Enqueue(i);
            }
            foreach(var q in queue1)
            {
                Console.Write(q+" ");
            }
            Console.WriteLine("\n-------------------------------------------");

            Dictionary<int,string> cars = new Dictionary<int, string>();
            cars.Add(1, "Honda");
            cars.Add(2, "Ferrari");
            foreach(var d in cars)
            {
                Console.WriteLine("No: {0} | Marka: {1}",d.Key,d.Value);
            }
            Console.WriteLine("\n-------------------------------------------");

            Pi = 3.12d;
            Console.WriteLine(Pi.ToString());
            Pi = 3.13d;
            double v = 13 * 2 * Pi;
            Console.WriteLine(v.ToString() + " " + Pi.ToString());
            Console.WriteLine("\n-------------------------------------------");

        }
    }
}
