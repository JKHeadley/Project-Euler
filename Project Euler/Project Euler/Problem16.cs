using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;


namespace Project_Euler
{
    /// <summary>
    /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    /// What is the sum of the digits of the number 2^1000?
    /// </summary>
    class Problem16
    {
        public void Solve()
        {
            int exp = 1000;
            BigNum x = new BigNum(2, 1);
            x = x ^ exp;
            Console.WriteLine((string)x);
            int sum = Methods.SumDigits(x);
            Console.WriteLine("The sum of the digits in the number 2^" + exp + " is " + sum);
        }
    }
}
