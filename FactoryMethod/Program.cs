using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();

            Console.ReadKey();
        }
    }

    class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new EdLogger();
        }
    }

    class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    interface ILogger
    {
        void Log();

    }

    interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    class CustomerManager
    {

        private ILoggerFactory loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
            //ILogger logger = new LoggerFactory().CreateLogger();
            ILogger logger = loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
