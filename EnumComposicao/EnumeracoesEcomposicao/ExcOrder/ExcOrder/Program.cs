using System;
using System.Globalization;
using ExcOrder.Entities;
using ExcOrder.Entities.Enums;

namespace ExcOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client Data: ");
            Console.Write("Name: ");
            string nameClient = Console.ReadLine();
            Console.Write("Email: ");
            string emailClient = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDayClient = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine().ToUpper());
            Console.Write("How many products to this order? ");
            int numberProducts = int.Parse(Console.ReadLine());

            Client client = new Client(nameClient, emailClient, birthDayClient);
            Order order = new Order(DateTime.Now, orderStatus, client);

            for (int i = 0; i < numberProducts; i++)
            {
                Console.WriteLine($"Enter #{i + 1} item data: ");
                Console.Write("Product Name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantityProduct = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(quantityProduct, productPrice, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine(order);

        }
    }
}
