using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;

namespace Project_Euler
{
    class Pi
    {
        public void Solve()
        {
            //BigNum e = new BigNum(0, 100), n = new BigNum(0, 100), stop = 0;//finding e
            //for (; true; ++n)
            //{
            //    e = e + (1 / n.factorial());
            //    if (stop == e)
            //        break;
            //    stop = e;
            //    Console.WriteLine((string)e);
            //}
            //Console.WriteLine((string)e);

            //BigNum pi = new BigNum(0, 60), n = new BigNum(0, 60), a = new BigNum(0, 60),
            //    b = new BigNum(0, 60);//Ramanujan Formula
            //for (; n < 3; ++n)
            //{
            //    a = ((new BigNum(-1, 60) ^ n) * (1123 + (21460 * n)) * ((((2 * n) - 1).factorial()).factorial()) * ((((4 * n) - 1).factorial()).factorial()));
            //    b = (((new BigNum(882, 60)) ^ ((2 * n) + 1)) * ((new BigNum(32, 60)) ^ n) * ((n.factorial()) ^ 3));
            //    //cout << a << endl;
            //    Console.WriteLine((string)a);
            //    //cout << b << endl;
            //    Console.WriteLine((string)b);
            //    pi = pi + (a / b);
            //    //cout << pi << endl << endl;
            //    Console.WriteLine((string)pi + "\n");
            //}
            //pi = pi / 4;
            //pi = 1 / pi;
            ////cout << pi << endl;
            //Console.WriteLine((string)pi + "\n\nDone");


            BigNum pi = new BigNum(0, 100), n = new BigNum(0, 100), eight = new BigNum(8, 100), stop = new BigNum();//good
            for (; true; ++n)
            {
                pi = pi + ((((4 * n).factorial()) * (1103 + (26390 * n))) / (((n.factorial()) ^ 4) * (new BigNum(396, 600) ^ (4 * n))));
                //cout << n << " " << pi << endl;
                Console.WriteLine((string)n + " " + (string)pi);
                if (stop == pi)
                    break;
                stop = pi;
            }
            pi = pi * ((eight.sqrt()) / 9801);
            //cout << pi << endl;
            Console.WriteLine((string)pi);
            pi = 1 / pi;
            //cout << pi << endl;
            Console.WriteLine((string)pi);
        }
    }
}
