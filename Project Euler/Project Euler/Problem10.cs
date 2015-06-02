using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    /// <summary>
    /// Summation of primes
    /// 
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// Find the sum of all the primes below two million.
    /// </summary>
    class Problem10
    {
        public void Solve()
        {
            int i = 1, num_below = 2000000;

            //List<int> primes = new List<int>();

            double sum = 0;
            while (i < num_below)
            {
                if (Problem3.IsPrime(i))
                {
                    //primes.Add(i);
                    Console.WriteLine("Prime found: " + i + "\n");
                    sum += i;
                }
                i++;
            }

            Console.WriteLine("The sum of all primes below " + num_below + " is " + sum);
        }
    }
}
