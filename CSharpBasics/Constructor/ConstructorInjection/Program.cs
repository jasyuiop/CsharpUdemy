using System;

namespace ConstructorInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            // daha önce bu işlemi ( database'e mi log edicez, file mı ...) interface ile yapmıştık fakat consturctor ile yapmak
            // çok daha iyi bir yol

            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());
            employeeManager.Add();
        }
    }
    interface ILogger
    {
        public void Log();
    }
    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("logged to db");
        }
    }
    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged to file");
        }
    }
    class EmployeeManager
    {
        private ILogger _logger;
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            _logger.Log();
        }
    }
}
