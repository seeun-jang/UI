using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI04.test
{
    class Product
    {
        public string name;
        public int price;

        public void Print()
        {
            Console.WriteLine(name + " : " + price + "원");
        }
    }

internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Product Potato = new Product();
            Potato.name = "감자";
            Potato.price = 2000;

            Product Tomato = new Product();
            Tomato.name = "토마토";
            Tomato.price = 3000;

            list.Add(Potato);
            list.Add(Tomato);

            foreach (var item in list)
            {
                item.Print();
                //Console.WriteLine(item.name + " : " + item.price + "원");
            }
        }
    }
}
