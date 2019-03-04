using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Problem70 : IProblem
    {
        /*
         * You are climbing a stair case. It takes n steps to reach to the top.
         *
         * Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
         *
         * Note: Given n will be a positive integer.
         */
        public static int count = 0;

        public static Dictionary<int, int> KnownList = new Dictionary<int, int>();
        public void run()
        {
            int n = 44; // output 3
            Console.WriteLine(ClimbStairs(n));
            Console.WriteLine("Count: " + count);
        }
        /*
         * Runtime: 40 ms, faster than 100.00% of C# online submissions for Climbing Stairs.
         * Memory Usage: 13.7 MB, less than 6.86% of C# online submissions for Climbing Stairs.
         */
        public int ClimbStairs(int n)
        {
            return ClimbOneStep(n);
        }

        public int ClimbOneStep(int n)
        {
            if (KnownList.Keys.Contains(n))
            {
                return KnownList[n];
            }
            count++;
            if (n == 1)
            {
                return 1;
            }

            if (n == 2)
            {
                return 2;
            }

            var ways = ClimbOneStep(n - 2) + ClimbOneStep(n - 1);
            KnownList.Add(n, ways);
            Console.WriteLine($"curren Step {n}, current ways {ways}");
            return ways;
        }

    }
}
