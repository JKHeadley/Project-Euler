﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Helpers
{
    struct BigNum
    {
        private char sign;
        private int length;
        private deque<int> digits;
        private deque<int> postdec;

        //public BigNum()
        //{
        //    digits = new deque<int>();
        //    postdec = new deque<int>();
        //    sign = 'p';
        //    length = 10000;
        //}

        public BigNum(BigNum y)
        {
            digits = new deque<int>(y.digits);
            postdec = new deque<int>(y.postdec);
            sign = y.sign;
            length = y.length;
            this.check();
        }

        public BigNum(BigNum y, int l)
            : this(y)
        {
            length = l;
        }

        private BigNum check()
        {
            while ((digits.size() > 1) && (digits[0] == 0))
            {
                digits.pop_front();
            }
            while ((postdec.size() > 1) && (postdec[(postdec.size() - 1)] == 0))
            {
                postdec.pop_back();
            }

            if (digits.size() == 0)
                digits.push_front(0);
            if (postdec.size() == 0)
                postdec.push_front(0);
            if (digits.at(0) == 0 && postdec.at((postdec.size() - 1)) == 0)
            {
                sign = 'p';
            }
            while (postdec.size() > length)
                postdec.pop_back();
            return this;
        }

        private void SetLength(int l)
        {
            length = l;
        }

        private int GetLength()
        {
            return length;
        }

        public int GetDigitsSize()
        {
            return digits.size();
        }

        public List<int> GetDigits()
        {
            return digits.GetList();
        }


        public BigNum(int num)
        {
            digits = new deque<int>(new List<int>());
            postdec = new deque<int>(new List<int>());
            length = 10000;
            int a = num, first = 0;
            if (num < 0)
            {
                sign = 'n';
                if (num == -2147483648)
                    num++;
                num = num * -1;
            }
            else sign = 'p';
            while (num > 0)
            {
                if (a == -2147483648 && first == 0)
                {
                    digits.push_front((num % 10) + 1);
                    first++;
                }
                else
                    digits.push_front(num % 10);
                num = num / 10;

            }
            this.check();
        }

        public BigNum(int num, int l)
            : this(num)
        {
            length = l;
        }

        public BigNum(string number)
        {
            int a;
            digits = new deque<int>(new List<int>());
            postdec = new deque<int>(new List<int>());
            length = 10000;
            digits.clear();
            if (number.ElementAt(0) == '-') sign = 'n';
            else sign = 'p';
            int start = 0;
            if (!Char.IsNumber(number.ElementAt(0)) && number.ElementAt(0) != '.') start = 1;
            a = start;
            while (number.ElementAt(a) != '.')
            {
                digits.push_back(number.ElementAt(a) - '0');
                a++;
                if (a >= (number.Count()))
                    break;
            }
            a++;
            for (; a < length && a < number.Count(); a++)
                postdec.push_back(number.ElementAt(a) - '0');
            this.check();
        }

        public BigNum(string number, int l)
            : this(number)
        {
            length = l;
        }

        //public static implicit operator BigNum(BigNum num)
        //{
        //    BigNum newnum = 0;
        //    newnum.digits.clear();
        //    newnum.postdec.clear();
        //    newnum.digits = num.digits;
        //    newnum.postdec = num.postdec;
        //    newnum.sign = num.sign;
        //    newnum.length = num.length;
        //    newnum.check();
        //    return newnum;
        //}

        public static implicit operator int(BigNum num)
        {
            int sum = 0;
            for (int i = 0; i < (num.digits.size()); ++i)
            { sum = sum * 10 + num.digits[i]; }
            if (num.sign == 'n')
                sum = sum * (-1);
            return sum;
        }

        public static implicit operator BigNum(int num)
        {
            return new BigNum(num);
        }

        public static implicit operator string(BigNum num)
        {
            string s = "";
            char w = ' ';
            int a = 0;
            if (num.sign == 'n')
                s = "-";
            for (a = 0; a < num.digits.size(); a++)
            {
                w = (char)(num.digits[a] + 48);
                s = s + w;
            }
            s = s + '.';
            for (a = 0; a < num.postdec.size(); a++)
            {
                w = (char)(num.postdec[a] + 48);
                s = s + w;
            }
            return s;
        }


        public static bool operator ==(BigNum x, BigNum y)
        {
            int f = 0;
            if (x.sign != y.sign)
                return false;
            if (x.digits.size() != y.digits.size())
                return false;
            if (x.postdec.size() != y.postdec.size())
                return false;
            for (int a = 0; a < x.digits.size(); a++)
                if (x.digits[a] != y.digits[a])
                    f = 1;
            if (f == 1)
                return false;
            for (int a = 0; a < x.postdec.size(); a++)
            {
                if (x.postdec[a] != y.postdec[a])
                    f = 1;
            }
            if (f == 0)
                return true;
            else
                return false;
        }

        public static bool operator !=(BigNum x, BigNum y)
        {
            if (x == y)
                return false;
            else
                return true;
        }

        public static bool operator >(BigNum x, BigNum y)
        {
            int a = 0;
            if (x == y)
                return false;

            if (x.sign == 'n' && y.sign == 'p')
                return false;
            else if (x.sign == 'p' && y.sign == 'n')
                return true;
            if (x.sign == 'p' && y.sign == 'p')
                if (x.digits.size() > y.digits.size())
                    return true;
            if (x.sign == 'n' && y.sign == 'n')
                if (x.digits.size() > y.digits.size())
                    return false;
            if (x.sign == 'p' && y.sign == 'p')
                if (x.digits.size() < y.digits.size())
                    return false;
            if (x.sign == 'n' && y.sign == 'n')
                if (x.digits.size() < y.digits.size())
                    return true;

            for (a = 0; a < x.digits.size(); a++)
            {//if same size and same sign but not equal
                if (x.digits[a] > y.digits[a])
                    if (x.sign == 'p')
                        return true;
                    else
                        return false;
                else if (x.digits[a] < y.digits[a])
                    if (x.sign == 'p')
                        return false;
                    else
                        return true;
            }
            for (a = 0; (a < x.postdec.size()) && (a < y.postdec.size()); a++)
            {
                if (x.postdec[a] > y.postdec[a])
                    if (x.sign == 'p')
                        return true;
                    else
                        return false;
                else if (x.postdec[a] < y.postdec[a])
                    if (x.sign == 'p')
                        return false;
                    else
                        return true;
            }

            if (a < x.postdec.size())//if one postdec is longer
                if (x.sign == 'p')
                    return true;
                else
                    return false;
            if (a < y.postdec.size())
                if (x.sign == 'p')
                    return false;
                else
                    return true;
            return false;//default
        }

        public static bool operator <(BigNum x, BigNum y)
        {
            if (x >= y)
                return false;
            else
                return true;
        }

        public static bool operator >=(BigNum x, BigNum y)
        {
            if ((x > y) || (x == y))
                return true;
            else
                return false;
        }

        public static bool operator <=(BigNum x, BigNum y)
        {
            if ((x < y) || (x == y))
                return true;
            else
                return false;
        }

        public static bool operator >(BigNum x, int y)
        {
            if (x.sign == 'p' && y < 0)
                return true;
            if (x.sign == 'n' && y > 0)
                return false;

            BigNum big_int = 2147483647, small_int = -2147483648;
            int x_copy = 0;
            if (x > big_int)
                return true;
            if (x < small_int)
                return false;
            x_copy = x;
            if (x_copy == y && (x.postdec[0] != 0 || x.postdec.size() != 1))
            {
                if (x.sign == 'n' && y < 0)
                    return false;
                else
                    return true;
            }
            if (x_copy > y)
                return true;
            else
                return false;
        }

        public static bool operator <(BigNum x, int y)
        {
            if (x >= y)
                return false;
            else
                return true;
        }

        public static bool operator >=(BigNum x, int y)
        {
            if ((x > y) || (x == y))
                return true;
            else
                return false;
        }

        public static bool operator <=(BigNum x, int y)
        {
            if ((x < y) || (x == y))
                return true;
            else
                return false;
        }

        public static bool operator !=(BigNum x, int y)
        {
            if (x == y)
                return false;
            else
                return true;
        }

        public static bool operator ==(BigNum x, int y)
        {
            if (x.sign == 'p' && y < 0)
                return false;
            if (x.sign == 'n' && y > 0)
                return false;
            BigNum big_int = 2147483647, small_int = -2147483648;
            int x_copy = 0;
            if (x > big_int)
                return false;
            if (x < small_int)
                return false;
            x_copy = x;
            if (x_copy == y && (x.postdec[0] != 0 || x.postdec.size() != 1))
            {
                return false;
            }
            if (x_copy == y)
                return true;
            else
                return false;
        }

        public static BigNum operator +(BigNum x, BigNum y)
        {
            int a = 0, b = 0, c = 0, carry = 0, total = 0;
            BigNum result = 0, x2, y2;
            result.digits.clear();
            if (x.length > y.length)
                result.SetLength(y.length);
            else
                result.SetLength(x.length);
            x2 = new BigNum(x);//copies of x and y that can be changed
            y2 = new BigNum(y);
            if ((x.digits.size() == 1 && x.digits[0] == 0) && (x.postdec.size() == 1 && x.postdec[0] == 0))
            {//if x is 0
                result = new BigNum(y);
                result.check();
                return result;
            }
            if ((y.digits.size() == 1 && y.digits[0] == 0) && (y.postdec.size() == 1 && y.postdec[0] == 0))
            {//if y is 0
                result = new BigNum(x);
                result.check();
                return result;
            }
            //////////////////////////////////////////////first do postdec
            if (x.sign == y.sign)
            {//same sign
                if (x.postdec.size() == y.postdec.size())
                {//same size
                    for (a = x.postdec.size() - 1; a >= 0; a--)
                    {//add the postdecs
                        total = (x.postdec[a] + y.postdec[a]) + carry;
                        if (total > 9)
                            carry = 1;
                        else
                            carry = 0;
                        result.postdec.push_front(total % 10);
                    }
                }
                else
                {									//different size
                    x2.sign = 'p';
                    y2.sign = 'p';
                    if (x2 > y2)
                    {//decide sign of result based on greater absolute value
                        while (x2.postdec.size() < y2.postdec.size())//make sure postdec sizes are equal
                            x2.postdec.push_back(0);
                        while (x2.postdec.size() > y2.postdec.size())
                        {
                            result.postdec.push_front(x2.postdec[x2.postdec.size() - 1]);
                            x2.postdec.pop_back();
                        }
                    }
                    else
                    {
                        while (y2.postdec.size() < x2.postdec.size())//make sure postdec sizes are equal
                            y2.postdec.push_back(0);
                        while (y2.postdec.size() > x2.postdec.size())
                        {
                            result.postdec.push_front(y2.postdec[y2.postdec.size() - 1]);
                            y2.postdec.pop_back();
                        }
                    }
                    for (a = x2.postdec.size() - 1; a >= 0; a--)
                    {//add the postdecs 
                        total = (x2.postdec[a] + y2.postdec[a]) + carry;
                        if (total > 9)
                            carry = 1;
                        else
                            carry = 0;
                        result.postdec.push_front(total % 10);
                    }
                }
            }
            else
            {					//different sign
                x2.sign = 'p';
                y2.sign = 'p';
                if (x2 == y2)
                {
                    result.digits.push_front(0);//negate to 0
                    result.check();
                    return result;
                }
                if (x2 > y2)
                {//decide sign of result based on greater absolute value
                    result.sign = x.sign;
                    while (x2.postdec.size() < y2.postdec.size())//make sure postdec sizes are equal
                        x2.postdec.push_back(0);
                    while (x2.postdec.size() > y2.postdec.size())
                    {
                        result.postdec.push_front(x2.postdec[x2.postdec.size() - 1]);
                        x2.postdec.pop_back();
                    }
                }
                else
                {
                    result.sign = y.sign;
                    while (y2.postdec.size() < x2.postdec.size())//make sure postdec sizes are equal
                        y2.postdec.push_back(0);
                    while (y2.postdec.size() > x2.postdec.size())
                    {
                        result.postdec.push_front(y2.postdec[y2.postdec.size() - 1]);
                        y2.postdec.pop_back();
                    }
                }
                //now do subtracting
                if (x2 > y2)
                {//x absolute value is greater
                    int borrowed = 0;//flag that tells whether borrowing has carried through
                    for (a = x2.postdec.size() - 1; a >= 0; a--)
                    {
                        if (x2.postdec[a] < y2.postdec[a])
                        {// if digit in greater # is smaller than digit in lesser #
                            borrowed = 0;
                            x2.postdec[a] += 10;
                            int dp = 1;//dp tells whether borrowing from digits(0) or postdec(1), c keeps track of borrowing
                            while (borrowed == 0)
                            {
                                if (a == 0 || dp == 0)
                                {
                                    dp = 0;
                                    c = x2.digits.size() - 1;
                                }
                                else
                                {
                                    dp = 1;
                                    c = a - 1;
                                }
                                for (b = 0; b != 1; c--)
                                {
                                    if (c < 0)
                                    {
                                        dp = 0;
                                        break;
                                    }
                                    if (dp == 1)
                                    {
                                        if (x2.postdec[c] != 0)
                                        {
                                            x2.postdec[c]--;
                                            b = 1;
                                            borrowed = 1;
                                        }
                                        else
                                            x2.postdec[c] = 9;
                                    }
                                    if (dp == 0)
                                    {
                                        if (x2.digits[c] != 0)
                                        {
                                            x2.digits[c]--;
                                            b = 1;
                                            borrowed = 1;
                                        }
                                        else
                                            x2.digits[c] = 9;
                                    }
                                }
                            }
                        }
                        result.postdec.push_front(x2.postdec[a] - y2.postdec[a]);
                    }
                }
                else
                {//y absolute value is greater
                    int borrowed = 0;//flag that tells whether borrowing has carried through
                    for (a = y2.postdec.size() - 1; a >= 0; a--)
                    {
                        if (y2.postdec[a] < x2.postdec[a])
                        {// if digit in greater # is smaller than digit in lesser #
                            borrowed = 0;
                            y2.postdec[a] += 10;
                            int dp = 1;//dp tells whether borrowing from digits(0) or postdec(1), c keeps track of borrowing
                            while (borrowed == 0)
                            {
                                if (a == 0 || dp == 0)
                                {
                                    dp = 0;
                                    c = y2.digits.size() - 1;
                                }
                                else
                                {
                                    dp = 1;
                                    c = a - 1;
                                }
                                for (b = 0; b != 1; c--)
                                {
                                    if (c < 0)
                                    {
                                        dp = 0;
                                        break;
                                    }
                                    if (dp == 1)
                                    {
                                        if (y2.postdec[c] != 0)
                                        {
                                            y2.postdec[c]--;
                                            b = 1;
                                            borrowed = 1;
                                        }
                                        else
                                            y2.postdec[c] = 9;
                                    }
                                    if (dp == 0)
                                    {
                                        if (y2.digits[c] != 0)
                                        {
                                            y2.digits[c]--;
                                            b = 1;
                                            borrowed = 1;
                                        }
                                        else
                                            y2.digits[c] = 9;
                                    }
                                }
                            }
                        }
                        result.postdec.push_front(y2.postdec[a] - x2.postdec[a]);
                    }
                }
            }
            /////////////////////////////////////////////////now take care of digits
            int x_dsize = 0, y_dsize = 0;
            if (x.sign == y.sign)
            {//if same sign
                result.sign = x.sign;
                a = 0; b = 0; total = 0;
                if (x2.digits.size() < y2.digits.size())//b = smaller digit size
                    b = (x2.digits.size() - 1);
                else
                    b = (y2.digits.size() - 1);
                x_dsize = x2.digits.size() - 1;
                y_dsize = y2.digits.size() - 1;
                for (a = b; a >= 0; a--)
                {//add up to highest digit place in smaller #
                    total = x2.digits[x_dsize] + y2.digits[y_dsize] + carry;
                    if (total > 9)
                        carry = 1;
                    else
                        carry = 0;
                    result.digits.push_front(total % 10);
                    x_dsize--;
                    y_dsize--;
                }

                if (x_dsize < 0)
                {//concatenate rest of larger #
                    while (y_dsize >= 0)
                    {
                        while (y_dsize >= 0 && (y2.digits[y_dsize] + carry) > 9)
                        {
                            result.digits.push_front(0);
                            y_dsize--;
                        }
                        if (y_dsize >= 0)
                            result.digits.push_front(y2.digits[y_dsize] + carry);
                        else
                            result.digits.push_front(1);
                        carry = 0;
                        y_dsize--;
                    }
                }
                if (y_dsize < 0)
                {
                    while (x_dsize >= 0)
                    {
                        while (x_dsize >= 0 && (x2.digits[x_dsize] + carry) > 9)
                        {
                            result.digits.push_front(0);
                            x_dsize--;
                        }
                        if (x_dsize >= 0)
                            result.digits.push_front(x2.digits[x_dsize] + carry);
                        else
                            result.digits.push_front(1);
                        carry = 0;
                        x_dsize--;
                    }
                }
                if (carry == 1)
                    result.digits.push_front(carry);
                result.check();
                return result;
            }
            else
            {//if different sign
                total = 0;
                x_dsize = x2.digits.size() - 1;
                y_dsize = y2.digits.size() - 1;
                if (x2 > y2)
                {//x absolute value is greater
                    for (a = (y2.digits.size() - 1); a >= 0; a--)
                    {
                        if (x2.digits[x_dsize] >= y2.digits[y_dsize])
                        {
                            total = x2.digits[x_dsize] - y2.digits[y_dsize];
                            result.digits.push_front(total);
                        }
                        else
                        {
                            x2.digits[x_dsize] += 10;
                            if (x2.digits[x_dsize - 1] == 0)
                            {
                                int num = x_dsize - 1;
                                while (x2.digits[num] == 0)
                                {
                                    x2.digits[num] = 9;
                                    num--;
                                }
                                x2.digits[num] -= 1;
                            }
                            else
                                x2.digits[x_dsize - 1] -= 1;
                            total = x2.digits[x_dsize] - y2.digits[y_dsize];
                            result.digits.push_front(total);
                        }
                        x_dsize--;
                        y_dsize--;
                    }
                    if (x_dsize < 0)
                    {
                        while (y_dsize >= 0)
                        {
                            if (y_dsize >= 0)
                                result.digits.push_front(y2.digits[y_dsize]);
                            y_dsize--;
                        }
                    }
                    if (y_dsize < 0)
                    {
                        while (x_dsize >= 0)
                        {
                            if (x_dsize >= 0)
                                result.digits.push_front(x2.digits[x_dsize]);
                            x_dsize--;
                        }
                    }
                    result.check();
                    return result;
                }

                else if (y2 > x2)
                {//y absolute value is greater
                    for (a = x.digits.size() - 1; a >= 0; a--)
                    {
                        if (y2.digits[y_dsize] >= x2.digits[x_dsize])
                        {
                            total = y2.digits[y_dsize] - x2.digits[x_dsize];
                            result.digits.push_front(total);
                        }
                        else
                        {
                            y2.digits[y_dsize] += 10;
                            y2.digits[y_dsize - 1] -= 1;
                            total = y2.digits[y_dsize] - x2.digits[x_dsize];
                            result.digits.push_front(total);
                        }
                        y_dsize--;
                        x_dsize--;
                    }
                    if (y_dsize < 0)
                    {
                        while (x_dsize >= 0)
                        {
                            if (x_dsize >= 0)
                                result.digits.push_front(x2.digits[x_dsize]);
                            x_dsize--;
                        }
                    }
                    if (x_dsize < 0)
                    {
                        while (y_dsize >= 0)
                        {
                            if (y_dsize >= 0)
                                result.digits.push_front(y2.digits[y_dsize]);
                            y_dsize--;
                        }
                    }
                    result.check();
                    return result;
                }
                else
                {
                    result.check();
                    return result;
                }
            }
        }

        public static BigNum operator -(BigNum x, BigNum y)
        {
            BigNum result = 0, x2, y2;
            result.digits.clear();
            if (x.length > y.length)
                result.SetLength(y.length);
            else
                result.SetLength(x.length);
            x2 = new BigNum(x);
            x2.sign = 'p';
            y2 = new BigNum(y);
            y2.sign = 'p';

            if (x.sign == y.sign)
            {
                y2.sign = 'n';
                y2.check();
                result = x2 + y2;
            }
            else
                result = x2 + y2;
            //////// This is likely either not necessary or just a bad fix ///////
            x2.sign = 'p';
            y2.sign = 'p';
            if (x2 > y2)
                result.sign = x.sign;
            else if (y.sign == 'n')
                result.sign = 'p';
            else
                result.sign = 'n';
            //////////////////////////////////////////////////////////////////////
            result.check();
            return result;
        }

        public static BigNum operator *(BigNum x, BigNum y)
        {
            BigNum result = 0, result1 = 0, x2 = 0, y2 = 0;
            result.digits.clear();
            result1.digits.clear();
            x2.digits.clear();
            y2.digits.clear();
            if (x.length > y.length)
                result.SetLength(y.length);
            else
                result.SetLength(x.length);
            result1.SetLength(result.length);
            if (!(x.postdec.size() == 1 && x.postdec[0] == 0))
            {
                for (int a = x.postdec.size() - 1, b = 0; a >= 0; a--)
                {//makes x2 and y2 whole #'s to simplify multiplication
                    b = x.postdec[a];
                    x2.digits.push_front(b);
                }
            }
            for (int a = x.digits.size() - 1, b = 0; a >= 0; a--)
            {
                b = x.digits[a];
                x2.digits.push_front(b);
            }
            if (!(y.postdec.size() == 1 && y.postdec[0] == 0))
            {
                for (int a = y.postdec.size() - 1, b = 0; a >= 0; a--)
                {
                    b = y.postdec[a];
                    y2.digits.push_front(b);
                }
            }
            for (int a = y.digits.size() - 1, b = 0; a >= 0; a--)
            {
                b = y.digits[a];
                y2.digits.push_front(b);
            }
            x2.SetLength(result.length);
            y2.SetLength(result.length);
            x2.check();
            y2.check();

            if (x.sign != y.sign)//gets the sign of the result
                result.sign = 'n';
            else
                result.sign = 'p';
            if (x2 == 0 || y2 == 0)
                return new BigNum(0, result.length);
            int total = 0, carry = 0;
            BigNum sum = new BigNum(0, result.length), temp = new BigNum(0, result.length), temp2 = new BigNum(0, result.length);
            temp.digits.clear();
            temp2.digits.clear();
            //the following code simply multilplies out each y2 digit times the x2 #, then adds all the products (normal multiplication)
            for (int b = y2.digits.size() - 1, i = 0, k = 0, s = 0, t = 0; b >= 0; b--, i++)
            {//multiplies the y digits times the x #
                k = x2.digits.size() - 1;
                carry = 0;
                for (int a = k; a >= 0; a--)
                {
                    total = x2.digits[k] * y2.digits[b] + carry;
                    temp.digits.push_front(total % 10);
                    carry = total / 10;
                    k--;
                }
                if (carry > 0)
                    temp.digits.push_front(carry);
                for (int a = i; a > 0; a--)
                    temp.digits.push_back(0);
                carry = 0;
                s = sum.digits.size() - 1;
                t = temp.digits.size() - 1;
                for (int a = 0; a < sum.digits.size() && a < temp.digits.size(); a++, s--, t--)
                {
                    total = sum.digits[s] + temp.digits[t] + carry;
                    if (total > 9)
                        carry = 1;
                    else
                        carry = 0;
                    temp2.digits.push_front(total % 10);
                }
                if (carry == 0)
                {
                    for (; t >= 0; t--)
                        temp2.digits.push_front(temp.digits[t]);
                    for (; s >= 0; s--)
                        temp2.digits.push_front(sum.digits[s]);
                }
                else
                {
                    for (; t >= 0; t--)
                    {
                        total = temp.digits[t] + carry;
                        if (total > 9)
                            carry = 1;
                        else
                            carry = 0;
                        temp2.digits.push_front(total % 10);
                    }
                    for (; s >= 0; s--)
                    {
                        total = sum.digits[s] + carry;
                        if (total > 9)
                            carry = 1;
                        else
                            carry = 0;
                        temp2.digits.push_front(total % 10);
                    }
                    if (carry > 0)
                        temp2.digits.push_front(1);
                }
                sum = new BigNum(temp2);
                temp2.digits.clear();
                temp.digits.clear();
            }
            sum.check();
            sum.sign = result.sign;
            result = new BigNum(sum);
            //the last part of the code copies result into result2 but with the right decimal point placement
            BigNum result2 = 0;
            result2.digits.clear();
            result2.sign = result.sign;
            result2.SetLength(result.length);
            int w = 0, z = 0;
            if ((x.postdec.size() == 1 && x.postdec[0] == 0) && (y.postdec.size() == 1 && y.postdec[0] == 0))
                w = 0;
            else if (x.postdec.size() == 1 && x.postdec[0] == 0)
                w = y.postdec.size();
            else if (y.postdec.size() == 1 && y.postdec[0] == 0)
                w = x.postdec.size();
            else
                w = x.postdec.size() + y.postdec.size();
            for (; w > 0 && result.digits.size() > 0; w--)
            {
                z = result.digits[result.digits.size() - 1];
                result2.postdec.push_front(z);
                result.digits.pop_back();
            }
            for (; w > 0; w--)
            {
                result2.postdec.push_front(0);
            }
            while (result.digits.size() > 0)
            {
                z = result.digits[result.digits.size() - 1];
                result2.digits.push_front(z);
                result.digits.pop_back();
            }
            result2.check();
            return result2;
        }

        public static BigNum operator /(BigNum x, BigNum y)
        {
            BigNum result = 0, z = new BigNum(0, 1), x2 = 0, y2 = 0, x3 = new BigNum(0, 1), y3 = new BigNum(0, 1),
                x4 = new BigNum(0, 1), y4 = new BigNum(0, 1), Zero = new BigNum(0, 1), point = new BigNum(0, 1);
            result.digits.clear();
            x2.digits.clear();
            y2.digits.clear();
            if (x.length > y.length)
                result.SetLength(y.length);
            else
                result.SetLength(x.length);
            if (x.sign == y.sign)
                result.sign = 'p';
            else
                result.sign = 'n';
            if (y.digits.size() == 1 && y.digits[0] == 1 && y.postdec.size() == 1 && y.postdec[0] == 0)
            {//check if divided by one
                result = new BigNum(x, result.length);
                if (x.sign == y.sign)
                    result.sign = 'p';
                else
                    result.sign = 'n';
                result.check();
                return result;
            }
            x3 = new BigNum(x, 1);
            y3 = new BigNum(y, 1);
            x3.sign = 'p';
            y3.sign = 'p';
            if (x3 == y3)
            {//check if x and y are the same #
                result.digits.push_back(1);
                result.check();
                return result;
            }
            try
            {

                int a = 0, b = 0; ;
                //makes x2 and y2 whole #'s to simplify multiplication
                if (!(x.postdec.size() == 1 && x.postdec[0] == 0))
                {//if fractional part of x exists
                    for (a = x.postdec.size() - 1, b = 0; a >= 0; a--)
                    {//add fraction to front of x2
                        b = x.postdec[a];
                        ////cout << b << endl;
                        x2.digits.push_front(b);
                        ////cout << x2 << endl;
                    }
                }
                for (a = x.digits.size() - 1, b = 0; a >= 0; a--)
                {//now add whole part of x to x2
                    b = x.digits[a];
                    x2.digits.push_front(b);
                }
                if (!(y.postdec.size() == 1 && y.postdec[0] == 0))
                {//do the same for y and y2
                    for (a = y.postdec.size() - 1, b = 0; a >= 0; a--)
                    {
                        b = y.postdec[a];
                        y2.digits.push_front(b);
                    }
                }
                for (a = y.digits.size() - 1, b = 0; a >= 0; a--)
                {
                    b = y.digits[a];
                    y2.digits.push_front(b);
                }
                ////cout << x2 << endl << y2 << endl;
                x2.check();
                y2.check();
                x2.sign = 'p';
                y2.sign = 'p';
                ////cout << x2 << endl << y2 << endl;
                if (x2 == 0)//zero division
                    return 0;
                if (y2 == 0)
                    throw new DivideByZeroException();
                while (x2.digits[x2.digits.size() - 1] == 0 && y2.digits[y2.digits.size() - 1] == 0)
                {//simplifies division
                    x2.digits.pop_back();
                    y2.digits.pop_back();
                }
                int cnt = 0;
                BigNum xdiv = 0;//remainder during division
                xdiv.digits.clear();
                BigNum result2 = 0;
                result2.digits.clear();
                result2.postdec.clear();
                //xdiv.postdec.push_back(0);
                int count = 0;//keeps zeros from adding up in front
                ////cout << x2 << endl << y2 << endl;
                if (x2 == y2)
                {// if answer is a multiple of 1
                    result.digits.push_back(1);
                    ////cout << point << endl;
                    point = point + (x.digits.size() - y.digits.size());
                    ////cout << point << endl;
                    if (x.digits.size() == 1 && x.digits[0] == 0)
                        point = point - 1;
                    ////cout << point << endl;
                    if (y.digits.size() == 1 && y.digits[0] == 0)
                        point = point + 1;
                    ////cout << point << endl;
                    result2.SetLength(result.length);
                    result2.sign = result.sign;
                    if (point == 0)
                    {
                        result2.postdec.push_back(1);
                        result2.check();
                        return result2;
                    }
                    if (point > 0)
                    {
                        result2.digits.push_back(1);
                        for (; point > 0; --point)
                        {
                            result2.digits.push_back(0);
                        }
                    }
                    else
                    {
                        point = point + 1;
                        result2.postdec.push_back(1);
                        for (; point < 0; ++point)
                        {
                            result2.postdec.push_front(0);
                        }
                    }
                    result2.check();
                    ////cout << result2 << endl << endl;
                    ////cout << result2.digits[0] << endl;
                    return result2;
                }
                if (x2 > y2)
                {
                    count = 1;
                    for (b = 0; y2 > xdiv; b++)
                    {
                        ////cout << b << endl;
                        xdiv.digits.push_back(x2.digits[b]);
                    }
                    while (true)
                    {
                        for (cnt = 0, z = Zero; z <= xdiv; cnt++)
                        {
                            z = z + y2;
                        }
                        cnt--;
                        z = z - y2;
                        result.digits.push_back(cnt);
                        ////cout << result << endl;
                        xdiv = xdiv - z;
                        if (xdiv == Zero)
                            xdiv.digits.pop_back();
                        ////cout << b << endl;
                        if (b < x2.digits.size())
                            xdiv.digits.push_back(x2.digits[b]);
                        else
                            break;
                        b++;
                    }
                }
                else
                    xdiv = new BigNum(x2);//otherwise xdiv would = 0


                b = 0;
                b = b + (x.postdec.size() - y.postdec.size());
                if (y.postdec.size() == 1 && y.postdec[0] == 0)
                    b = b + 1;
                if (x.postdec.size() == 1 && x.postdec[0] == 0)
                    b = b - 1;
                if (xdiv != Zero && xdiv.digits.size() != 0)
                {//finish division with remainder
                    xdiv.digits.push_back(0);
                    ////cout << xdiv << endl;
                    while (b < x.length)
                    {
                        ////cout << xdiv << endl;
                        for (cnt = 0, z = new BigNum(Zero); z <= xdiv; cnt++)
                        {
                            z = z + y2;
                            ////cout << z << endl;
                        }
                        cnt--;
                        z = z - y2;
                        if (count != 0 || cnt != 0)
                            result.digits.push_back(cnt);
                        if (cnt != 0)
                            count = 1;
                        xdiv = xdiv - z;
                        if (xdiv == Zero)
                            break;
                        xdiv.digits.push_back(0);
                        b++;
                    }
                }

                point = x2.digits.size() - y2.digits.size();//helps decide decimal placement
                //cout << point << endl << endl;
                x3.digits = x.digits;
                y3.digits = y.digits;
                if (x3 > y3)
                {//keeps decimal point from being one digit off
                    x3 = new BigNum(x2);
                    y3 = new BigNum(y2);
                    while (x3.digits.size() > y3.digits.size())
                        x3.digits.pop_back();
                    while (y3.digits.size() > x3.digits.size())
                        y3.digits.pop_back();
                    if (x3 >= y3)
                        point = point + 1;
                    //cout << point << endl << endl;
                }
                else
                {
                    x3 = new BigNum(x2);
                    y3 = new BigNum(y2);
                    x4 = new BigNum(x2);
                    y4 = new BigNum(y2);
                    while (x3.digits.size() > y3.digits.size())
                        x3.digits.pop_back();
                    while (y3.digits.size() > x3.digits.size())
                        y3.digits.pop_back();
                    while (y4.digits[y4.digits.size() - 1] == 0)
                        y4.digits.pop_back();
                    //cout << x4 << endl << endl << y4 << endl << endl;
                    if (x3 <= y3 && x4 != y4)
                        point = point - 1;
                    //cout << point << endl << endl;
                }
                if (!(y.postdec.size() == 1 && y.postdec[0] == 0))
                {//helps decide decimal placement
                    point = point + y.postdec.size();
                }
                //cout << point << endl << endl;
                if (!(x.postdec.size() == 1 && x.postdec[0] == 0))
                {//helps decide decimal placement
                    point = point - x.postdec.size();
                }
                //cout << point << endl << endl;
                if (point < 0)//helps decide decimal placement
                    point = point + 1;
                if (xdiv.digits.size() == 0 && point > 0)
                    point = point + 1;
                //cout << point << endl << endl;

                if (!(y.postdec.size() == 1 && y.postdec[0] == 0))
                {
                    for (int i = y.postdec.size(); i > 0 && result.digits.size() != 0 && result.digits[0] == 0; i--)
                        result.digits.pop_front();
                }
                for (int i = point; i < 0; i++)
                    result.digits.push_front(0);
                //cout << result << endl << endl;
                result2.SetLength(result.length);
                result2.sign = result.sign;
                for (; point > 0 && result.digits.size() > 0; --point)
                {
                    result2.digits.push_back(result.digits[0]);
                    result.digits.pop_front();
                }
                while (result.digits.size() > 0)
                {
                    result2.postdec.push_back(result.digits[0]);
                    result.digits.pop_front();
                }
                result2.check();
                //cout << result2 << endl << endl;
                ////cout << result2.digits[0] << endl;
                return result2;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("error, can't divide by zero");
                throw (new DivideByZeroException());
                //return 0;
            }
        }

        public static BigNum operator %(BigNum x, BigNum y)
        {
            ////cout << x << endl << y << endl;
            /*if (x.postdec.size() > 1 || y.postdec.size() > 1 || (x.postdec.size() == 1 && x.postdec[0] != 0) || (y.postdec.size() == 1 && y.postdec[0] != 0)){
                //cout << "Can only mod whole numbers." << endl;
                return x;
            }*/
            BigNum result = 0, mod = 0, x2 = 0, y2 = 0;
            y2 = new BigNum(y);
            y2.sign = 'p';
            x2 = new BigNum(x);
            x2.sign = 'p';
            if (y2 > x2)
            {
                return x;
            }
            if (y2 == x2)
            {
                return 0;
            }
            x2.SetLength(1);
            y2.SetLength(1);
            result = x2 / y2;
            result.postdec.clear();
            result = result * y2;
            mod = x2 - result;
            if (x.sign == 'n')
                mod.sign = 'n';
            else
                mod.sign = 'p';
            mod.check();
            return mod;
        }

        public static BigNum operator +(int x, BigNum y)
        {
            BigNum x2 = x, result;
            x2.SetLength(y.length);
            result = x2 + y;
            result.check();
            return result;
        }

        public static BigNum operator +(BigNum x, int y)
        {
            BigNum y2 = y, result;
            y2.SetLength(x.length);
            result = x + y2;
            result.check();
            return result;
        }

        public static BigNum operator -(int x, BigNum y)
        {
            BigNum x2 = x, result;
            x2.SetLength(y.length);
            result = x2 - y;
            result.check();
            return result;
        }

        public static BigNum operator -(BigNum x, int y)
        {
            BigNum y2 = y, result;
            y2.SetLength(x.length);
            result = x - y2;
            result.check();
            return result;
        }

        public static BigNum operator *(int x, BigNum y)
        {
            BigNum x2 = x, result;
            x2.SetLength(y.length);
            result = x2 * y;
            result.check();
            return result;
        }

        public static BigNum operator *(BigNum x, int y)
        {
            BigNum y2 = y, result;
            y2.SetLength(x.length);
            result = x * y2;
            result.check();
            return result;
        }

        public static BigNum operator /(int x, BigNum y)
        {
            BigNum x2 = x, result;
            x2.SetLength(y.length);
            result = x2 / y;
            result.check();
            return result;
        }

        public static BigNum operator /(BigNum x, int y)
        {
            BigNum y2 = y, result;
            y2.SetLength(x.length);
            result = x / y2;
            result.check();
            return result;
        }

        public static BigNum operator %(int x, BigNum y)
        {
            BigNum x2 = x, result;
            x2.SetLength(y.length);
            result = x2 % y;
            result.check();
            return result;
        }

        public static BigNum operator %(BigNum x, int y)
        {
            BigNum y2 = y, result;
            y2.SetLength(x.length);
            result = x % y2;
            result.check();
            return result;
        }

        public static BigNum operator ^(BigNum x, int y)
        {
            if (y == 0)
                return new BigNum(1, x.length);
            BigNum p = new BigNum(x);
            for (int i = y; i > 1; i--)
                p = p * x;
            return p;
        }

        public static BigNum operator ++(BigNum y)
        {
            y = y + 1;
            return y;

        }

        public static BigNum operator --(BigNum y)
        {
            y = y - 1;
            return y;
        }

        public BigNum sqrt()
        {
            BigNum x = new BigNum(1, length), xcopy = 0, xcopy2 = 0;
            int count = 0, count2 = 0;
            while (x.digits.size() < (digits.size() / 2) + 1)
            {//gets x closer to size of answer
                x = x * 10;
            }
            while (xcopy != x && count2 <= 0)
            {//runs formula until accurate at set length
                if (count % 2 == 0)
                    xcopy2 = new BigNum(x);
                xcopy = new BigNum(x);
                x = x + (1 / (2 * x)) * (this - (x * x));
                if (xcopy2 == x)
                    count2++;
                count++;

            }
            return x;
        }

        public BigNum factorial()
        {
            if (this == 0)
                return new BigNum(1, length);
            if (postdec.size() == 1 && postdec[0] == 0)
            {
                BigNum x = new BigNum(this), result = new BigNum(this);
                x.sign = 'p';
                x = x - 1;
                for (int dot = 0; x > 0; --x, dot++)
                {
                    result = result * x;
                }
                if (sign == 'n')
                    result.sign = 'n';
                return result;
            }
            else
                Console.WriteLine("factorial must be whole");
            return new BigNum(0, length);
        }

        public BigNum doublefactorial()
        {
            if (this == 0 || this == -1)
                return new BigNum(1, length);
            if (postdec.size() == 1 && postdec[0] == 0)
            {
                BigNum x = new BigNum(this), result = new BigNum(this);
                x.sign = 'p';
                x = x - 2;
                for (int dot = 0; x > 0; x = x - 2, dot++)
                {
                    result = result * x;
                }
                if (sign == 'n')
                    result.sign = 'n';
                return result;
            }
            else
                Console.WriteLine("factorial must be whole");
            return new BigNum(0, length);
        }

        public BigNum sin()
        {
            BigNum x = new BigNum(this), result = new BigNum(this), fact = new BigNum(3, length);
            for (int exp = 3, i = 0; i < 20; i++, exp += 2, fact = fact + 2)
            {
                if (i % 2 == 0)
                    result = result - ((x ^ exp) / (fact.factorial()));
                else
                    result = result + ((x ^ exp) / (fact.factorial()));
            }
            return result;
        }

        public BigNum cos()
        {
            BigNum x = new BigNum(this), result = new BigNum(1, length), fact = new BigNum(2, length);
            for (int exp = 2, i = 0; i < 20; i++, exp += 2, fact = fact + 2)
            {
                if (i % 2 == 0)
                    result = result - ((x ^ exp) / (fact.factorial()));
                else
                    result = result + ((x ^ exp) / (fact.factorial()));
            }
            return result;
        }

        public BigNum tan()
        {
            return (sin() / cos());
        }

        public BigNum arctan()
        {
            BigNum x = new BigNum(this), result = new BigNum(this), stop = 0;
            for (int n = 3, i = 0; true; i++, n += 2)
            {
                if (i % 2 == 0)
                    result = result - ((x ^ n) / n);
                else
                    result = result + ((x ^ n) / n);
                if (stop == result)
                    return result;
                stop = new BigNum(result);
                //cout << result << endl;
            }
            //return result;
        }
    }
}
