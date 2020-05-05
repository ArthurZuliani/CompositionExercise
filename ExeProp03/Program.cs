using System;
using ExeProp03.Entities.Enums;
using ExeProp03.Entities;
using System.Globalization;

namespace ExeProp03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            Client c1 = new Client(name, email, birthDate);
            Order o1 = new Order(DateTime.Now, status, c1);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int productQtd = int.Parse(Console.ReadLine());

                Product p = new Product(productName, productPrice);
                OrderItem orderitem = new OrderItem(productQtd, productPrice, p);
                o1.AddItem(orderitem);
            }

            Console.WriteLine();
            Console.WriteLine(o1);
        }
    }
}
