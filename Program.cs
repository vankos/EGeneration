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
            Console.WriteLine("What numbers after the decimal point you want?(max:23):");
            int NumberOfNumbers =Convert.ToInt32( Console.ReadLine())+3;//max 26 (23 from input)
            
            Console.WriteLine("{0}", FindEiler(NumberOfNumbers).ToString().Substring(0,NumberOfNumbers-1), NumberOfNumbers);
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
            Math.Round(e, n);
            return e;
        }
    }
}
