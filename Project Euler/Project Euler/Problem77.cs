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
            long coef = Methods.MultisetCoef(3, 4);
            int num = 2;
            while (true)
            {
                var summations = Methods.FindPrimeSummations(num);
                if (summations.Count > 5000)
                    break;
                num++;
            }
            Console.WriteLine("The first number that can be written as the sum of primes in over five thousand ways is: " + num);
        }
    }
}
