using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g1 = new Graph(4);
            g1.AddEgde(1, 1);
            g1.AddEgde(0, 2);
            g1.AddEgde(1, 2);
            g1.AddEgde(0, 3);
            g1.AddEgde(3, 4);
            g1.test();
            g1.PrintEulerTour();



            Console.Read();
        }


    }
}
