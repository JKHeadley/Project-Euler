using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    class Problem3
    {
        public void Solve()
        {
            var primeFactors = FindPrimeFactors(600851475143);
            Console.WriteLine("Prime factors for 600851475143:\n");
            Console.WriteLine(string.Join(", ", primeFactors.ToArray()) + "\n");
            Console.WriteLine("Largest prime factor: " + primeFactors.Last() + "\n");

        }

        bool IsPrime(long num)
        {
            var factors = FindFactors(num);
            if (factors.Count == 2)
                return true;
            else
                return false;
        }

        List<long> FindFactors_slow(long num)
        {
            List<long> factors = new List<long>();

            for (long i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    factors.Add(i);
                    Console.WriteLine("Found a factor: " + i);
                }
            }
            factors = new HashSet<long>(factors).ToList();
            factors.Sort();
            return factors;
        }

        List<long> FindFactors(long num)
        {
            List<long> factors = new List<long>();
            var square = (long)Math.Sqrt(num);
            long i = square, j = square;
            while (true)
            {
                var prod = i * j;
                if (prod == num)
                {
                    factors.Add(i);
                    factors.Add(j);
                    Console.WriteLine("Found a factor: " + i);
                    Console.WriteLine("Found a factor: " + j);
                }
                if (i == 1)
                    break;
                if (prod >= num)
                {
                    i--;
                    j = num / i;
                }
                else
                {
                    j++;
                }

            }
            factors = new HashSet<long>(factors).ToList();
            factors.Sort();
            return factors;
        }

        List<long> FindPrimeFactors(long num)
        {
            List<long> primeFactors = new List<long>();
            var factors = FindFactors(num);
            foreach (var factor in factors)
            {
                if (IsPrime(factor))
                {
                    primeFactors.Add(factor);
                    Console.WriteLine("Found a prime factor: " + factor);
                }
            }
            return primeFactors;
        }

        bool IsEven (long num)
        {
            if (num % 2 == 0)
                return true;
            else
                return false;
        }
    }
}
