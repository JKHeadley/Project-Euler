using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    /// <summary>
    /// Smallest multiple
    /// 
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
    class Problem5
    {
        public void Solve()
        {
            int range_start = 1;
            int range_end = 20;
            int i = 1;
            while (true)
            {
                if (IsDivisibleForRange(i, range_start, range_end))
                {
                    Console.WriteLine("Smallest number evenly divisible by all numbers from " + range_start + " to " + range_end + " is " + i + "\n");
                    return;
                }
                else
                    i++;
            }
        }

        bool IsDivisible(int dividend, int divisor)
        {
            if (dividend % divisor == 0)
                return true;
            else
                return false;
        }

        bool IsDivisibleForRange(int dividend, int divisor_start, int divisor_end)
        {
            for (int i = divisor_start; i <= divisor_end; i++)
            {
                if (!IsDivisible(dividend, i))
                    return false;
            }
            return true;
        }
    }
}
