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

        public static List<List<int>> FindPrimeSummations(int num)
        {
            List<int> primes = FindPrimesBelow(num);
            int kCardinality = num / 2;
            var primeCombinations = FindCombinations(primes, kCardinality);
            //var unique = new HashSet<List<int>>(primeCombinations);
            return primeCombinations;
        }

        public static List<List<int>> FindCombinations(List<int> set, int kCardinality)
        {
            List<List<int>> combinations = new List<List<int>>();
            //foreach (int num in set)
            //{
            //    List<int> item = new List<int>();
            //    item.Add(num);
            //    combinations.Add(item);
            //}
            return recursiveStuff(combinations, set, kCardinality);
            //List<List<int>> combinations = new List<List<int>>();
            //for (int i = 0; i < combSize; i++)
            //{

            //}
        }

        //private List<List<int>> recursiveFunc(List<int> combination, List<int> set, int combSize)
        //{
        //    List<List<int>> base_combinations = new List<List<int>>();
        //    if (combSize == 1)
        //    {
        //        foreach (int num in set)
        //        {
        //            List<int> base_comb = new List<int>();
        //            base_comb.Add(num);
        //            base_combinations.Add(base_comb);
        //        }
        //        return base_combinations;
        //    }
        //    else
        //    {
        //        foreach (int num in set)
        //        {

        //        }
        //    }
        //        return recursiveFunc(combinations, set, combSize - 1);
        //}

        //private static List<List<int>> recursiveStuff(List<List<int>> combinations, List<int> set, int multisetSize)
        //{
        //    foreach (List<int> comb in combinations)
        //    {
        //        if (comb.Count < multisetSize)
        //        {
        //            for (int i = 0; i < set.Count; i++)
        //            {
        //                if (comb.Count < multisetSize)
        //                {
        //                    comb.Add(set[i]);
        //                    if (comb.Count < multisetSize)
        //                    {
        //                        for (int j = i; j < set.Count - 1; j++)
        //                        {
        //                            combinations.Add(new List<int>(comb));
        //                        }
        //                    }
        //                }
        //            }
        //            return recursiveStuff(combinations, set, multisetSize);
        //        }
        //    }
        //    return combinations;
        //}

        private static List<List<int>> recursiveStuff(List<List<int>> combinations, List<int> set, int kCardinality)
        {
            int index = 0;
            int setIndex = 0;
            int setIndex_to_add = 0;
            int c_in_foc = kCardinality - 1;
            bool done = false;
            //initialize the first combination
            var comb = new List<int>();
            for (int i = 0; i < kCardinality; i++)
            {
                comb.Add(set[0]);
            }
            combinations.Add(comb);
            index++;
            setIndex_to_add++;
            //fill in the rest
            while (true)
            {
                comb = new List<int>();
                int i = 0;
                while (i < c_in_foc)
                {
                    comb.Add(combinations[index-1][i]);
                    i++;
                }
                i--;
                while(i < kCardinality - 1)
                {
                    comb.Add(set[setIndex_to_add]);
                    i++;
                }
                setIndex_to_add++;


                if (setIndex_to_add >= set.Count)
                {
                    for (; comb[c_in_foc] == set.Last(); c_in_foc--) 
                    {
                        if (c_in_foc == 0)
                        {
                            combinations.Add(comb);
                            done = true;
                            break;
                        }
                    }
                    if (done == true)
                        break;
                    setIndex_to_add = set.IndexOf(comb[c_in_foc]) + 1;
                }
                else
                {
                    for (; comb[c_in_foc] != set.Last() && c_in_foc < kCardinality - 1; c_in_foc++) { }
                }

                combinations.Add(comb);
                index++;
            }
            return combinations;
        }

        //private static List<List<int>> recursiveStuff(List<List<int>> combinations, List<int> set, int kCardinality)
        //{
        //    int index = 0;
        //    int setIndex = 0;
        //    int setIndex_to_add = 0;
        //    int c_in_foc = kCardinality + 1;
        //    int c_in = 0;
        //    bool addFlag = false;
        //    initialize the first combination
        //    var comb = new List<int>();
        //    var comb_next = recursiveNext(comb, set, c_in ,setIndex, setIndex_to_add, c_in_foc);
        //}

        //public static recursiveNext(List<int> comb, List<int> set, int c_in, int setIndex, int setIndex_to_add, int c_in_foc)
        //{
        //    if (c_in == c_in_foc)
        //    {
        //        comb.Insert(0, set[setIndex_to_add]);
        //    }
        //}

        public static int BinomialCoef(int n, int k)
        {
            BigNum N = n, K = k, coef = 0;
            coef = N.factorial() / (K.factorial() * (N - K).factorial());
            return (int)coef;
        }

        public static int  MultisetCoef(int n, int k)
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
