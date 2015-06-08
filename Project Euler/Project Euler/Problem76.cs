using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;

namespace Project_Euler
{
    /// <summary>
    /// Counting Summations
    /// 
    /// It is possible to write five as a sum in exactly six different ways:
    /// 
    /// 4 + 1
    /// 3 + 2
    /// 3 + 1 + 1
    /// 2 + 2 + 1
    /// 2 + 1 + 1 + 1
    /// 1 + 1 + 1 + 1 + 1
    /// 
    /// How many different ways can one hundred be written as a sum of at least two positive integers?
    /// </summary>
    class Problem76
    {
        public void Solve()
        {
            //var coef = Methods.MultisetCoef(num / 2, num);
            var summations = Methods.FindSummations(100);
            //Console.WriteLine("The first number that can be written as the sum of primes in over five thousand ways is: " + num);
        }
    }
}
