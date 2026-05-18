using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int time = 10;
            Console.WriteLine((9 < time) && (time < 12));
            Console.WriteLine(DateTime.Now.Hour > 9 || DateTime.Now.Hour < 12);
            Console.WriteLine(DateTime.Now.Hour > 9 && DateTime.Now.Hour < 12); 
        }
    }
}
