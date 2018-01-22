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
            string userInputString = Console.ReadLine();
            int NumberOfNumbers = ValidateInput(userInputString);
            //i have to use substring meethod for cut exactly necessary amount of digit 
            Console.WriteLine("e={0}", FindEiler(NumberOfNumbers).ToString().Substring(0,NumberOfNumbers-1));
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

        private static int ValidateInput(string userInputString)
        {
            int numberOfNumbers;
            while ((!int.TryParse(userInputString, out numberOfNumbers)) || (numberOfNumbers < 0)||(numberOfNumbers>23))
            {
                Console.Write("Write correct value:");
                userInputString = Console.ReadLine();
            }
            return numberOfNumbers+3;
        }
    }
}
