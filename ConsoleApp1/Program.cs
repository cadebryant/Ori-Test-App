using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Customer? customer;

            MyStackClass<Customer> stack = new MyStackClass<Customer>();

            try
            {
                customer = new Customer { CustomerId = 1, FirstName = "FirstName 1", LastName = "LastName 1", Orders = PostOrders(7) };
                stack.Push(customer);

                Console.WriteLine($"Calculated amount: {customer.CalculateTotalSpent()}");

                customer = new Customer { CustomerId = 2, FirstName = "FirstName 2", LastName = "LastName 2", Orders = PostOrders(4) };
                stack.Push(customer);

                customer = new Customer { CustomerId = 2, FirstName = "FirstName 3", LastName = "LastName 3", Orders = PostOrders(1) };
                stack.Push(customer);

                customer = null;
                stack.Push(customer);

                var popResult = stack.Pop();
                var peekResult = stack.Peek();

                Console.WriteLine($"Peeked Customer: {peekResult.FirstName} - {peekResult.LastName} - Order Count: {peekResult.Orders.Count}");
                Console.WriteLine($"Popped Customer: {popResult.FirstName} - {popResult.LastName} - Order Count: {popResult.Orders.Count}");

            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred processing customers/orders: {ex.ToString()}");
            }

        }

        public static List<Order> PostOrders(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException($"{nameof(PostOrders)}: {nameof(count)} must be greater than 0");
            }
            
            List<Order> orders = new List<Order>();

            try
            {
                for (int ii = 0; ii < count; ii++)
                {
                    orders.Add(new Order { OrderId = ii + 1, Items = PostItems(count), OrderDate = DateTime.Now });
                }

                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred in {nameof(PostOrders)} attempting to post orders: {ex.Message}");
            }

        }

        public static List<OrderItem> PostItems(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException($"{nameof(PostItems)}: {nameof(count)} must be greater than 0");
            }

            List<OrderItem> items = new List<OrderItem>();

            try
            {
                for (int ii = 0; ii < count; ii++)
                {
                    items.Add(new OrderItem { ProductName = $"Product {ii}", Quantity = ii, Price = 100 });
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred in {nameof(PostItems)} trying to post items: {ex.Message}");
            }
        }

    }
}