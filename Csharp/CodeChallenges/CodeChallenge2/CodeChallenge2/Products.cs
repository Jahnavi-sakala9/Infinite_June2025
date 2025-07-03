using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2
{
    //Second Question
    //Sorting of products based on price
    class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public void Display()
        {
            Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Price: {Price}");
        }
        static void Main()
        {
            List<Products> products = new List<Products>();

            // Accepting 10 products
            for (int i = 0; i < 10; i++)
            {
                Products p = new Products();

                Console.Write("Enter Product ID: ");
                p.ProductId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Product Name: ");
                p.ProductName = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                p.Price = double.Parse(Console.ReadLine());

                products.Add(p);
                Console.WriteLine();
            }

            // Sorting based on price
            products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
            Console.WriteLine("Sorted Products by Price:");
            foreach (var product in products)
            {
                product.Display();
            }
            Console.Read();
        }
    }
}




