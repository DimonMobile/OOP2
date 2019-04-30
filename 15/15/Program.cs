using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            for (; ;)
            {
                hero.HandleInput(Console.ReadKey(true).KeyChar);
            }
        }
    }
}
