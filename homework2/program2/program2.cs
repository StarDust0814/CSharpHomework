using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program2
{
    class program2
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] { 9, 65, 235, 186, 100 };//定义并初始化数组
            int max = a[0];
            //将当前最大（最小）值与数组中所有数据元素进行比较
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            int min = a[0];
            for (int j = 0; j < a.Length; j++)
            {
                if (a[j] <= min)
                    min = a[j];
            }
            //遍历，将所有数据相加
            int sum = 0;
            for (int k = 0; k < a.Length; k++)
            {
                sum += a[k];
            }
            //确保精度的准确
            double avg = sum / a.Length;

            Console.WriteLine("Max is " + max + ", " + "min is " + min + ", " + "sum is " + sum + ", " + "avg is " + avg);
            Console.WriteLine("Done!!!");
        }
    }
}
