using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace EGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What numbers after the decimal point you want?:");
            string userInputString = Console.ReadLine();
            int NumberOfNumbers = ValidateInput(userInputString);
            //i use substring meethod for cut exactly necessary amount of digit 
            Console.WriteLine("e={0}", FindEiler(NumberOfNumbers + 1).ToString().Substring(0,NumberOfNumbers-2).Insert(1,","));
            Console.ReadLine();
        }

       static BigInteger FindEiler(int n)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // BigInteger works only with non-float values , so i had to multiply divended value on number of requered digits after comma
            BigInteger e = BigInteger.Pow(10, n);
            int progressPercent = 1;
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                progressPercent = CountPercentage(n, progressPercent, i, watch);
                factorial = BigInteger.Multiply(factorial,i);
                BigInteger  division = BigInteger.Divide(BigInteger.Pow(10, n), factorial);
                e = BigInteger.Add(e,division);
            }
            watch.Stop();
            Console.WriteLine("Calculation time is:{0}ms ({1}s)", watch.ElapsedMilliseconds, watch.ElapsedMilliseconds / 1000);
            return e;
        }

        private static int ValidateInput(string userInputString)
        {
            int numberOfNumbers;
            while ((!int.TryParse(userInputString, out numberOfNumbers)) || (numberOfNumbers < 0))
            {
                Console.Write("Write correct value:");
                userInputString = Console.ReadLine();
            }
            return numberOfNumbers+3;
        }

        private static int CountPercentage(int n, int progressPercent, int j, System.Diagnostics.Stopwatch watch)
        {
            if ((Convert.ToDouble(j) / n * 100) > progressPercent)
            {
                Console.WriteLine("Progress:{0}% (Time:{1}ms ({2}s))", progressPercent, watch.ElapsedMilliseconds, watch.ElapsedMilliseconds / 1000);
                while ((Convert.ToDouble(j)) / n * 100 > progressPercent)
                {
                    progressPercent++;
                }
            }
            return progressPercent;
        }
    }
}
