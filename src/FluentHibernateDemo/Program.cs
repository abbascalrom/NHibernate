using FluentHibernateDemo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernateDemo
{
    class Program
    {
       static void Main(string[] args)
        {
            Insert(new Customer() { FirstName = "User", LastName = "One" });
            Insert(new Customer() { FirstName = "User", LastName = "Two" });

            var customer = Get(1);

            Console.WriteLine("Customer Fetched: " + customer.FirstName + "\t" +
                      customer.LastName);

            Update(new Customer() { Id = 1, FirstName = "Updated FName", LastName = "Updated LName" });

            Delete(1);

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Fluent NHibernate Demo Completed.");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ReadKey();
        }

        static void Insert(Customer customer)
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    session.Save(customer);
                    transaction.Commit();
                }

                Console.WriteLine("Customer Created: " + customer.FirstName + "\t" +
                       customer.LastName);
            }
        }

        static Customer Get(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var customer = session.Get<Customer>(id);
                return customer;
            } 
        }
        static void Update(Customer customer)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var customerToUpdate = session.Get<Customer>(customer.Id);

                customerToUpdate.FirstName = customer.FirstName;
                customerToUpdate.LastName = customer.LastName;

                using (var transaction = session.BeginTransaction())
                {
                    session.Save(customerToUpdate);
                    transaction.Commit();
                }

                Console.WriteLine("Customer Update: " + customer.FirstName + "\t" +
                       customer.LastName);
            }
        }

        static void Delete(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var customerToDelete = session.Get<Customer>(id);

                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(customerToDelete);
                    transaction.Commit();                   
                }

                Console.WriteLine("Customer Deleted: " + customerToDelete.FirstName + "\t" +
                      customerToDelete.LastName);
            }
        }
    }
}
