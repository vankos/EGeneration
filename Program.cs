using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What accuracy you want?(numbers after the decimal point): ");
            int NumberOfNumbers =Convert.ToInt32( Console.ReadLine())+3;
            Console.WriteLine("{0}", FindEiler(NumberOfNumbers));
            Console.ReadLine();
        }

       static decimal FindEiler(int n)
        {
            decimal e = 1;
            for (int i = 1; i <= n; i++)
            {
                decimal Factorial = 1;
                for (int j = 1; j <= i; j++)
                {
                    Factorial *= j;
                }
                e += 1 /Factorial;
            }
            return e;
        }
    }
}
