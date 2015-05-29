using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    /// <summary>
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    class Problem4
    {
        public void Solve()
        {
            int largestPalindrome = 0;
            for (int i = 100; i <= 999; i++)
            {
                for (int j = i; j <=999; j++)
                {
                    var prod = i * j;
                    if (IsPalindrome(prod))
                    {
                        Console.WriteLine("Found palindrome: " + i + " x " + j + " = " + prod + "\n");
                        if (prod > largestPalindrome)
                        {
                            largestPalindrome = prod;
                            Console.WriteLine("Found larger palindrome: " + largestPalindrome + "\n");
                            break;
                        }
                    }

                }
            }
            Console.WriteLine("Largest palindrome: " + largestPalindrome + "\n");

        }

        bool IsPalindrome(int num)
        {
            List<int> digits = new List<int>();
            var temp = num;
            while (temp != 0)
            {
                digits.Add(temp % 10);
                temp /= 10;
            }
            for (int i = 0, j = digits.Count - 1; j >= 1; i++, j-- )
            {
                if (digits[i] != digits[j])
                    return false;
            }
            return true;
        }
    }
}
