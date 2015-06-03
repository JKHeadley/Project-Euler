using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Helpers
{
    class Methods
    {
        public static bool IsPrime(long num)
        {
            if (num < 2)
                return false;
            var factors = FindFactors(num);
            if (factors.Count == 2)
                return true;
            else
                return false;
        }

        public static List<long> FindFactors_slow(long num)
        {
            List<long> factors = new List<long>();

            for (long i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    factors.Add(i);
                    //Console.WriteLine("Found a factor: " + i);
                }
            }
            factors = new HashSet<long>(factors).ToList();
            factors.Sort();
            return factors;
        }

        public static List<long> FindFactors(long num)
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
                    //Console.WriteLine("Found a factor: " + i);
                    //Console.WriteLine("Found a factor: " + j);
                }
                if (i == 0)
                    break;
                if (prod >= num)
                {
                    i--;
                    if (i != 0)
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

        public static List<long> FindPrimeFactors(long num)
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

        public static bool IsEven(long num)
        {
            if (num % 2 == 0)
                return true;
            else
                return false;
        }

        public static List<int> GetCollatzSequence(int num)
        {
            /// n → n/2 (n is even)
            /// n → 3n + 1 (n is odd)
            List<int> sequence = new List<int>();
            sequence.Add(num);
            int n = num;
            while (n != 1)
            {
                if (IsEven(n))
                    n /= 2;
                else
                    n = 3 * n + 1;
                sequence.Add(n);
            }
            return sequence;
        }

        public static int GetCollatzSize(int num)
        {
            /// n → n/2 (n is even)
            /// n → 3n + 1 (n is odd)
            int size = 1;
            long n = num;
            while (n != 1)
            {
                if (n <= 0)
                {
                    Console.WriteLine("Sequence broken! n is <= 0.");
                    break;
                }
                if (IsEven(n))
                    n /= 2;
                else
                    n = 3 * n + 1;
                size++;
            }
            return size;
        }

        public static int SumDigits(BigNum num)
        {
            List<int> digits = num.GetDigits();
            return digits.Sum();
        }
    }
}
