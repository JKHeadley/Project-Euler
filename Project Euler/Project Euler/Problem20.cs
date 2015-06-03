using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;


namespace Project_Euler
{
    /// <summary>
    /// Factorial digit sum
    /// 
    /// n! means n × (n − 1) × ... × 3 × 2 × 1
    /// 
    /// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    /// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
    /// 
    /// Find the sum of the digits in the number 100!
    /// </summary>
    class Problem20
    {
        public void Solve()
        {
            int size = 100;
            BigNum x = new BigNum(size,1);
            x = x.factorial();
            Console.WriteLine((string)x);

            int sum = Methods.SumDigits(x);
            Console.WriteLine("The sum of the digits in the number " + size + " is " + sum);
        }
    }
}
