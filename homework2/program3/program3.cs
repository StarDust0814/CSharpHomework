using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program3
{
    class program3
    {
        static void Main(string[] args)
        {
            //计数，便于排列质数
            int n = 0;
            //给定范围
            for (int i = 2; i <= 100; i++)
            {
                //判断是否拥有除了1和其本身以外的其他因数
                bool havePrime = false;
                //每个数除以从2到其本身一半的数
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                        havePrime = true;
                }
                //判断条件
                if (havePrime == true)
                {
                    havePrime = false;
                    continue;
                }
                else
                    Console.Write(" " + i);
                //调整排列顺序，每10个一行
                n++;
                if (n < 10)
                    continue;
                Console.WriteLine();
                //重置n
                n = 0;
            }
            Console.WriteLine();
            Console.WriteLine("Done!!!");
        }
           
    }
}
