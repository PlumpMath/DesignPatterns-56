using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product()
            {
                Description = "...",
                Price = 12,
                ProductName = "Books"
            };

            Shopping shopping = new Shopping();

            if (shopping.SalesToProduct(product))
            {
                Console.WriteLine("Sussesful!");
            }
            else
            {
                Console.WriteLine("Process is failed");
            }
        }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }

    public class Stock
    {
        public bool CheckStokByProduct(Product product)
        {
            Console.WriteLine("Product is in the stock");
            return true;
        }

        public bool LookProductTemporary(Product product)
        {
            Console.WriteLine("This product is look");
            return true;
        }
    }

    public class Order
    {
        public bool AddToProduct(Product product)
        {
            Console.WriteLine("This product is join to sales order");
            return true;
        }
    }

    public class Shopping
    {
        private readonly Stock _stock;
        private readonly Order _order;

        public Shopping()
        {
            _stock = new Stock();
            _order = new Order();
        }

        public bool SalesToProduct(Product product)
        {
            if (_stock.CheckStokByProduct(product))
            {
                _stock.LookProductTemporary(product);
                _order.AddToProduct(product);

                return true;
            }

            return false;
        }
    }
}
