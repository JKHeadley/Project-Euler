using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    /// <summary>
    /// Special Pythagorean triplet
    /// 
    /// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
    /// 
    /// a^2 + b^2 = c^2
    /// 
    /// For example, 3^2 + 4^2 = 9 + 16 = 25 = 52.
    /// 
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
    /// </summary>
    class Problem9
    {
        public void Solve()
        {
            int a = 0, b = 0, c = 0;
            for (a = 0; a <= 1000; a++)
            {
                for (b = 0; b <= 1000; b++)
                {
                    for (c = 0; c <= 1000; c++)
                    {
                        if (a + b + c == 1000)
                        {
                            if (a < b && b < c && (a * a) + (b * b) == (c * c))
                            {
                                Console.WriteLine("The product of " + a + " * " + b + " * " + c + " = " + (a * b * c));
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
