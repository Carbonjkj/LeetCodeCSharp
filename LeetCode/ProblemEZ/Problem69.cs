using System;

namespace LeetCode.ProblemEZ
{
    public class Problem69 : IProblem
    {
        /*
         * Implement int sqrt(int x).
         *
         * Compute and return the square root of x, where x is guaranteed to be a non-negative integer.
         *
         * Since the return type is an integer, the decimal digits are truncated and only the integer part of the result is returned.
         *
         * */
        public void run()
        {
            int x = 2110439694;
            Console.WriteLine(MySqrt(x));
        }
        /*
         * Runtime: 48 ms, faster than 100.00% of C# online submissions for Sqrt(x).
         * Memory Usage: 13.1 MB, less than 36.07% of C# online submissions for Sqrt(x).
         */
        public int MySqrt(int x)
        {
            long tempx = x;
            int cnt = 0;
            for (long i = 0; i <= x; i++)
            {
                cnt++;
                long tempi = i;
                if (i * i > tempx)
                {
                    return (int)i - 1;
                }

                for (int j = 2; j < i; j++)
                {
                    cnt++;
                    if (j * j * i * i < x)
                    {
                        tempi = j * i;
                    }
                    else
                    {
                        break;
                    }
                }
                i = tempi;
            }

            return x;
        }
    }
}
