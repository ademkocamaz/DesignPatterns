using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer
            {
                Id = 1,
                FirstName = "Adem",
                LastName = "Kocamaz",
                City = "Kayseri"
            };

            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Salih";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);
            Console.ReadKey();
        }
    }

    abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
