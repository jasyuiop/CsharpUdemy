using System;

namespace InterfacesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorker[] workers = new IWorker[3]
            {
                new Manager(),
                new Worker(),
                new Robot()
            };
            foreach (var worker in workers)
            {
                worker.Work();
            }

            IWorkerHuman[] workerHumans = new IWorkerHuman[2]
            {
                new Manager(),
                new Worker()
            };
            foreach (var workerHuman in workerHumans)
            {
                workerHuman.Eat();
                workerHuman.GetSalary();
            }
        }
    }
    interface IWorker
    {
        void Work();
    }
    interface IWorkerHuman
    {
        void GetSalary();
        void Eat();
    }
    class Manager : IWorker, IWorkerHuman
    {
        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void GetSalary()
        {
            throw new NotImplementedException();
        }

        public void Work()
        {
            throw new NotImplementedException();
        }
    }
    class Worker : IWorker, IWorkerHuman
    {
        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void GetSalary()
        {
            throw new NotImplementedException();
        }

        public void Work()
        {
            throw new NotImplementedException();
        }
    }
    class Robot : IWorker
    {
        public void Work()
        {
            throw new NotImplementedException();
        }
    }
}
