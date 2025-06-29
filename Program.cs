using System;
using System.Collections.Generic;

namespace Inventory
{
    public class Product
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal PricePerPiece { get; set; }
        public decimal TotalValue => Stock * PricePerPiece;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            int quantity = 5;

            Console.WriteLine("========================================");
            Console.WriteLine("==============ACTIVITY 4================");
            Console.WriteLine("========================================");

            for (int i = 1; i <= quantity; i++)
            {
                Console.Write($"Enter product name #{i}: ");
                string prodName = Console.ReadLine();

                Console.Write($"Total stock for {prodName}: ");
                int totStock = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Price(per pcs.) for {prodName}: ");
                decimal pricePcs = Convert.ToDecimal(Console.ReadLine());

                products.Add(new Product
                {
                    Name = prodName,
                    Stock = totStock,
                    PricePerPiece = pricePcs
                });

                Console.WriteLine();
            }
            
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n=========Option/Menu=========");
                Console.WriteLine("[1] Display All products");
                Console.WriteLine("[2] Search by Product Name");
                Console.WriteLine("[3] Total Inventory Value");
                Console.WriteLine("[4] Exit");
                Console.WriteLine();

                Console.Write("Choose your option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("{0,-15} {1,-10} {2,10}", "Name", "Stock", "Price");
                        Console.WriteLine(new string('-', 39));
                        foreach (var product in products)
                        {
                            Console.WriteLine("{0,-15} {1,-10} {2,10:C}",
                                product.Name, product.Stock, $"Php {product.PricePerPiece:N2}");
                        }
                        break;

                    case 2:
                        Console.Write("\nEnter product name to search: ");
                        string searchName = Console.ReadLine();
                        var found = products.Find(p => p.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
                        if (found != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("{0,-15} {1,-10} {2,10}", "Name", "Stock", "Price");
                            Console.WriteLine(new string('-', 39));
                            Console.WriteLine("{0,-15} {1,-10} {2,10:C}",
                                found.Name, found.Stock, $"Php {found.PricePerPiece:N2}");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;

                    case 3:
                        decimal totalInventoryValue = 0;
                        foreach (var product in products)
                        {
                            totalInventoryValue += product.TotalValue;
                        }
                        Console.WriteLine($"Total Inventory Value: Php {totalInventoryValue:N2}");
                        break;

                    case 4:
                        running = false;
                        Console.WriteLine("Exit the program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
