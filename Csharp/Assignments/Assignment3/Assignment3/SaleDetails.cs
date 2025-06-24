using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    //second question (Sales Data)
    class SaleDetails
    {
        int SalesNo;
        int ProductNo;
        double Price;
        string DateOfSale;
        int Quantity;
        double TotalAmount;

        public SaleDetails(int salesNo, int productNo, double price, int qty, string dateOfsale)
        {
            SalesNo = salesNo;
            ProductNo = productNo;
            Price = price;
            Quantity = qty;
            DateOfSale = dateOfsale;
        }

        public void Sales()
        {
            TotalAmount = Quantity * Price;
        }
        public void ShowData()
        {
            Console.WriteLine("----- Sale Details -----");
            Console.WriteLine($"Sales No : {SalesNo}");
            Console.WriteLine($"Product No : {ProductNo}");
            Console.WriteLine($"Price : {Price}");
            Console.WriteLine($"Quantity : {Quantity}");
            Console.WriteLine($"Date of Sale : {DateOfSale}");
            Console.WriteLine($"Total Amount : {TotalAmount}");
        }
        public static void DisplayData()
        {
            SaleDetails s = new SaleDetails(98, 149, 1000, 3, "23-06-2025");
            s.Sales();
            s.ShowData();
        }
        public static void Main(string[] args) 
        { 
            DisplayData();
            Console.Read();
        }
    }
}
