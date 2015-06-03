using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;

namespace Project_Euler
{
    /// <summary>
    /// Largest prime factor
    /// 
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    class Problem3
    {
        public void Solve()
        {
            var primeFactors = Methods.FindPrimeFactors(600851475143);
            Console.WriteLine("Prime factors for 600851475143:\n");
            Console.WriteLine(string.Join(", ", primeFactors.ToArray()) + "\n");
            Console.WriteLine("Largest prime factor: " + primeFactors.Last() + "\n");
            Console.WriteLine("The correct solution is: " + 6857);

        }

        
    }
}
