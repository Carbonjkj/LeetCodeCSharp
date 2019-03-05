using System;

namespace LeetCode.ProblemEZ
{
    /**
     * The count-and-say sequence is the sequence of integers with the first five terms as following:
     * 1.     1
     * 2.     11
     * 3.     21
     * 4.     1211
     * 5.     111221
     * 1 is read off as "one 1" or 11.
     * 11 is read off as "two 1s" or 21.
     * 21 is read off as "one 2, then one 1" or 1211.
     *
     * Given an integer n where 1 ≤ n ≤ 30, generate the nth term of the count-and-say sequence.
     *
     * Note: Each term of the sequence of integers will be represented as a string.
     */
    public class Problem38 : IProblem
    {
        public void run()
        {
            int n = 7;
            Console.WriteLine(CountAndSay(n));
        }

        /*
         * Runtime: 92 ms, faster than 100.00% of C# online submissions for Count and Say.
         * Memory Usage: 26.7 MB, less than 9.30% of C# online submissions for Count and Say.
         */
        public string CountAndSay(int n)
        {
            string begin = "1";
            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine(begin);
                begin = Next(begin);
            }
            return begin;
        }

        public string Next(string n)
        {
            int size = n.Length;
            char pre = n[0];
            int count = 1;
            string output = "";
            bool append = true;
            for (int i = 1; i < size; i++)
            {
                if (pre == n[i])
                {
                    count++;
                }

                if (pre != n[i])
                {
                    output += count + "" + pre;
                    count = 1;
                    pre = n[i];
                }
            }

            output += count + "" + pre;
            return output;


        }
    }
}
