using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();

            Console.ReadKey();
        }
    }

    abstract class Logging
    {
        public abstract void Log(string message);
    }

    class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }

    class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with nLogger");
        }
    }

    abstract class Caching
    {
        public abstract void Cache(string data);
    }

    class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }

    class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }

    abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogging();
        public abstract Caching CreateCaching();
    }

    class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogging()
        {
            return new Log4NetLogger();
        }
    }

    class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogging()
        {
            return new NLogger();
        }
    }

    class ProductManager
    {
        private CrossCuttingConcernsFactory crossCuttingConcernsFactory;

        private Logging logging;
        private Caching caching;
        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            this.crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            this.logging = crossCuttingConcernsFactory.CreateLogging();
            this.caching = crossCuttingConcernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            logging.Log("Log");
            caching.Cache("Cache");
            Console.WriteLine("Products Listed!");
        }
    }
}
