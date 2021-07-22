using System;
using System.Globalization;
using System.Collections.Generic;
using Exercicio2.Entities;

namespace Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> listProducts = new List<Product>();

            Console.Write("Enter the number of products: ");
            int numberProducts = int.Parse(Console.ReadLine());

            for(int i = 1; i<= numberProducts; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char tagProduct = char.Parse(Console.ReadLine().ToLower());
                Console.Write("Name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Price: ");
                double priceProduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if(tagProduct == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    listProducts.Add(new ImportedProduct(nameProduct, priceProduct, customsFee));
                } 
                else if (tagProduct == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY) :");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    listProducts.Add(new UsedProduct(nameProduct, priceProduct, manufactureDate));
                }
                else
                {
                    listProducts.Add(new Product(nameProduct, priceProduct));
                }
            }
            Console.WriteLine("PRICE TAGS: ");
            
            foreach (Product p in listProducts)
            {
                Console.WriteLine(p.PriceTag()); ;
            }


        }
    }
}
