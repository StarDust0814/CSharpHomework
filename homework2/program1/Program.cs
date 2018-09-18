using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();//获取用户输入的数据
            Console.WriteLine("Calculate prime factor: ");
            //错误处理机制防止用户输入错误信息
            try
            {
                int a = int.Parse(s);
                int i = 2;
                while (a >= i)//在除数小于被除数的基础上进行循环
                {
                    if (a % i == 0)//存在因子
                    {
                        Console.WriteLine(i);
                        a /= i;
                    }
                    else
                        i++;
                }
                Console.WriteLine("Done!!!");
            }
            catch
            {
                Console.WriteLine("Please input an integer!!!");
            }
        }
    }
}
