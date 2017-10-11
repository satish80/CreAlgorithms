using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class Integers
    {
        public void IsPalindrome()
        {
            Console.WriteLine(IsPalindrome(101));
        }
        public bool IsPalindrome(int x)
        {
            int digit = 1;
            int num = x;
            int res = 0;
            int rev = 0;

            while (num >= 1)
            {
                rev = num % 10;
                res = digit * res + rev;
                digit = 10;
                num = num / 10;
            }

            if (res == x)
            {
                return true;
            }
            return false;
        }
    }
}
