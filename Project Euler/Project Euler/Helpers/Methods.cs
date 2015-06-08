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

        public static List<long> FindFactors_Derrill(long num)
        {
            List<long> factors = new List<long>();
            long y = num;
            long tempStored = 0;
            long factor = 1;
            long x = 1;

            while (true)
            {
                if (x >= num)
                {
                    x = tempStored + 1;
                    factor = 1;
                }

                if (num % x == 0)
                {
                    y = num / x;
                    tempStored = x;
                    factor = x;
                    factors.Add(x);
                    factors.Add(y);
                    //Console.WriteLine("Found a factor: " + x);
                    //Console.WriteLine("Found a factor: " + y);
                }
                x += factor;
                if (x > y)
                    break;
            }
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

        public static List<long> FindPrimeFactors_Derrill(long num)
        {
            List<long> primeFactors = new List<long>();
            var factors = FindFactors_Derrill(num);
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

        public static List<int> FindPrimesBelow(int num)
        {
            List<int> primes = new List<int>();
            for (int i = 0; i < num; i++)
            {
                if (IsPrime(i))
                    primes.Add(i);
            }
            return primes;
        }

        public static List<List<int>> FindPrimeSummations_slow(int num)
        {
            List<int> primes = FindPrimesBelow(num);
            int kCardinality = num / 2;

            List<List<int>> primeCombinations = new List<List<int>>();
            List<List<int>> primeSummations = new List<List<int>>();
            while (kCardinality >= 2)
            {
                var multiset = FindMultisetSummingTo(primes, kCardinality, num);
                primeCombinations.AddRange(multiset);
                kCardinality--;
            }

            foreach (var combination in primeCombinations)
            {
                if (combination.Sum() == num)
                {
                    primeSummations.Add(combination);
                }
            }

            return primeSummations;
        }

        public static MultisetTree FindPrimeSummations(int num)
        {
            List<int> primes = FindPrimesBelow(num);
            int kCardinality = num / 2;

            MultisetTree tree = new MultisetTree(primes, kCardinality, num);

            return tree;
        }

        public static List<List<int>> FindMultiset(List<int> set, int kCardinality)
        {
            List<List<int>> combinations = new List<List<int>>();
            int index = 0;
            int setIndex = 0;
            int combinationIndex = kCardinality - 1;
            bool done = false;
            //initialize the first combination
            var comb = new List<int>();
            for (int i = 0; i < kCardinality; i++)
            {
                comb.Add(set[0]);
            }
            combinations.Add(comb);
            index++;
            setIndex++;
            //fill in the rest
            while (true)
            {
                comb = new List<int>();
                int i = 0;
                while (i < combinationIndex)
                {
                    comb.Add(combinations[index - 1][i]);
                    i++;
                }
                i--;
                while (i < kCardinality - 1)
                {
                    comb.Add(set[setIndex]);
                    i++;
                }
                setIndex++;

                if (setIndex >= set.Count)
                {
                    for (; comb[combinationIndex] == set.Last(); combinationIndex--)
                    {
                        if (combinationIndex == 0)
                        {
                            combinations.Add(comb);
                            done = true;
                            break;
                        }
                    }
                    if (done == true)
                        break;
                    setIndex = set.IndexOf(comb[combinationIndex]) + 1;
                }
                else
                {
                    for (; comb[combinationIndex] != set.Last() && combinationIndex < kCardinality - 1; combinationIndex++) { }
                }

                combinations.Add(comb);
                index++;
            }
            return combinations;
        }

        public static List<List<int>> FindMultisetSummingTo(List<int> set, int kCardinality, int num)
        {
            List<List<int>> combinations = new List<List<int>>();
            int sum = 0;
            int index = 0;
            int setIndex = 0;
            int combinationIndex = kCardinality - 1;
            System.IO.StreamWriter writer = new System.IO.StreamWriter("../../Text Files/Multisetoutput.txt");
            bool done = false;
            //initialize the first combination
            var comb = new List<int>();
            for (int i = 0; i < kCardinality; i++)
            {
                comb.Add(set[0]);
            }
            combinations.Add(comb);
            index++;
            setIndex++;
            //fill in the rest
            while (true)
            {
                comb = new List<int>();
                int i = 0;
                while (i < combinationIndex)
                {
                    comb.Add(combinations[index - 1][i]);
                    i++;
                }
                i--;
                while (i < kCardinality - 1)
                {
                    comb.Add(set[setIndex]);
                    i++;
                }
                setIndex++;

                if (setIndex >= set.Count)
                {
                    for (; comb[combinationIndex] == set.Last(); combinationIndex--)
                    {
                        if (combinationIndex == 0)
                        {
                            combinations.Add(comb);
                            done = true;
                            break;
                        }
                    }
                    if (done == true)
                        break;
                    setIndex = set.IndexOf(comb[combinationIndex]) + 1;
                }
                else
                {
                    for (; comb[combinationIndex] != set.Last() && combinationIndex < kCardinality - 1; combinationIndex++) { }
                }
                sum = comb.Sum();
                writer.WriteLine(string.Join("\t", comb.ToArray()) + "\t" + sum);
                combinations.Add(comb);
                index++;
            }
            writer.Close();
            return combinations;
        }

        public static BigNum BinomialCoef(int n, int k)
        {
            BigNum N = n, K = k, coef = 0;
            coef = N.factorial() / (K.factorial() * (N - K).factorial());
            return coef;
        }

        public static BigNum MultisetCoef(int n, int k)
        {
            return BinomialCoef(n + k - 1, k);
        }

        public static long Factorial(long num)
        {
            long prod = 1;
            while (num > 0)
            {
                prod *= num;
                num--;
            }
            return prod;
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
