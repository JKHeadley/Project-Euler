using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;

namespace Project_Euler
{
    /// <summary>
    /// Powerful digit sum
    /// 
    /// A googol (10^100) is a massive number: one followed by one-hundred zeros; 100^100 is almost unimaginably large: one followed by two-hundred zeros. 
    /// Despite their size, the sum of the digits in each number is only 1.
    /// 
    /// Considering natural numbers of the form, a^b, where a, b < 100, what is the maximum digital sum?
    /// </summary>
    class Problem56
    {
        public void Solve()
        {
            BigNum a = 99, b = 99, num = 0;
            int sum = 0, max_sum = 0;
            for (; a > 2; a--)
            {
                b = 99;
                for (; b > 2; b--)
                {
                    num = a ^ b;
                    sum = Methods.SumDigits(num);
                    if (sum > max_sum)
                    {
                        max_sum = sum;
                        Console.WriteLine("New max sum: " + max_sum);
                    }
                }
            }

            Console.WriteLine("The maximum digital sum is: " + max_sum);
        }
    }
}
