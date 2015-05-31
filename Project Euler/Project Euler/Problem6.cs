using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    /// <summary>
    /// Sum square difference
    /// 
    /// The sum of the squares of the first ten natural numbers is,
    /// 
    ///             1^2 + 2^2 + ... + 10^2 = 385
    /// 
    /// The square of the sum of the first ten natural numbers is,
    /// 
    ///             (1 + 2 + ... + 10)^2 = 55^2 = 3025
    /// 
    /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
    class Problem6
    {
        public void Solve()
        {
            int size = 100;
            int sumOfSquare = SumOfSquaresForRange(1, size);
            int squareOfSum = SquareOfSumForRange(1, size);
            Console.WriteLine("The difference between the sum of the squares of the first " + size + " natural numbers and the square of the sum is " +
                squareOfSum + " - " + sumOfSquare + " = " + (squareOfSum - sumOfSquare));
        }

        int SumOfSquaresForRange(int range_start, int range_end)
        {
            int sum = 0;
            for (int i = range_start; i <= range_end; i++)
            {
                sum += i * i;
            }
            return sum;
        }

        int SquareOfSumForRange(int range_start, int range_end)
        {
            int sum = 0;
            for(int i = range_start; i <= range_end; i++)
            {
                sum += i;
            }
            return sum * sum;
        }
    }
}
