using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz12
{
    internal class cs1
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public static void task_1()
        {
            Console.OutputEncoding = Encoding.Unicode;
            int a = 10, b = 20;
            Console.WriteLine($"До обміну: a = {a}, b = {b}");

            Swap(ref a, ref b);

            Console.WriteLine($"Після обміну: a = {a}, b = {b}\n"); //a = 20 , b = 10
            

        }
    }
}
