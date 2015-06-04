using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;

namespace Project_Euler
{
    /// <summary>
    /// Prime summations
    /// 
    /// It is possible to write ten as the sum of primes in exactly five different ways:
    /// 
    /// 7 + 3
    /// 5 + 5
    /// 5 + 3 + 2
    /// 3 + 3 + 2 + 2
    /// 2 + 2 + 2 + 2 + 2
    /// 
    /// What is the first value which can be written as the sum of primes in over five thousand different ways?
    /// </summary>
    class Problem77
    {
        public void Solve()
        {
            Methods.FindPrimeSummations(10);
            var primes = Methods.FindPrimesBelow(10);
            Console.WriteLine(string.Join(",", primes.ToArray()));
        }
    }
}
