using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.ProblemEZ
{
    /*
     *
     * Say you have an array for which the ith element is the price of a given stock on day i.
     *
     * Design an algorithm to find the maximum profit. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).
     *
     * Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).
     */
    class Problem122 : IProblem
    {
        public void run()
        {
            var prices = new[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfit(prices));
        }
        /*
         * Runtime: 96 ms, faster than 100.00% of C# online submissions for Best Time to Buy and Sell Stock II.
         * Memory Usage: 23.1 MB, less than 60.78% of C# online submissions for Best Time to Buy and Sell Stock II.
         */
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }

            int min = prices[0];
            int profit = 0;
            // bottom and peak
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i - 1] > prices[i])
                {
                    profit += (prices[i - 1] - min);
                    min = prices[i];
                    continue;
                }

                if (i < prices.Length - 2 && prices[i] < prices[i + 1])
                {
                    min = Math.Min(min, prices[i]);
                    //min = prices[i];
                }

            }

            if (prices[prices.Length - 1] > min)
            {
                profit += prices[prices.Length - 1] - min;
            }
            return profit;
        }
    }
}
