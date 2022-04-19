using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
            Console.ReadKey();
        }
    }

    class CustomerManager
    {
        private static CustomerManager customerManager;
        static object lockObject = new object();
       

        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            //if (customerManager == null)
            //{
            //    customerManager = new CustomerManager();
            //}

            //return customerManager;
            //return customerManager ?? (lock (lockObject) {customerManager = new CustomerManager()});

            lock (lockObject)
            {
                if (customerManager==null)
                {
                    customerManager = new CustomerManager();
                }
            }

            return customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved!!");
        }
    }
}
