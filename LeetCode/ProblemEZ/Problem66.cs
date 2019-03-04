using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    /*
     * Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
     *
     * The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.
     *
     * You may assume the integer does not contain any leading zero, except the number 0 itself.     *
     */
    public class Problem66 : IProblem
    {

        public void run()
        {
            int[] digits = new[] { 9, 9, 9 };
            Console.WriteLine(string.Join("", PlusOne(digits)));
        }
        /*
         * Runtime: 240 ms, faster than 100.00% of C# online submissions for Plus One.
         * Memory Usage: 28.1 MB, less than 71.23% of C# online submissions for Plus One.
         */
        public int[] PlusOne(int[] digits)
        {
            return PlusOneSub(digits, digits.Length - 1);
        }

        public int[] PlusOneSub(int[] digits, int pos)
        {
            if (pos < 0)
            {
                var di = new int[digits.Length + 1];
                di[0] = 1;
                digits.CopyTo(di, 1);
                return di;
            }
            if (digits[pos] != 9)
            {
                digits[pos] += 1;
                return digits;
            }
            else
            {
                digits[pos] = 0;
                return PlusOneSub(digits, pos - 1);
            }
        }
    }
}
