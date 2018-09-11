using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace homework1
{
    class program1
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("a: ");

            a = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}", a);

            Console.WriteLine("b: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}", b);

            Console.WriteLine("a * b == {0} ", a * b);
           

            
        }
    }
}
