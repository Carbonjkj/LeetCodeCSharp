using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4.ProblemEZ
{
    /*
     * Say you have an array for which the ith element is the price of a given stock on day i.
     *
     * If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.
     *
     * Note that you cannot sell a stock before you buy one.
     */
    public class Problem121 : IProblem
    {

        public void run()
        {
            var prices = new[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfitV2(prices));
        }
        /*
         * Runtime: 148 ms, faster than 26.80% of C# online submissions for Best Time to Buy and Sell Stock.
         * Memory Usage: 23.6 MB, less than 5.61% of C# online submissions for Best Time to Buy and Sell Stock.
         */
        // Worst ever!!!!!! Looking for better solution!
        public int MaxProfit(int[] prices)
        {
            return MaxProfitSub(prices, 0, prices.Length - 1);
        }

        public int MaxProfitSub(int[] prices, int start, int stop)
        {
            if (stop <= start)
            {
                return 0;
            }
            int min = prices[start], max = prices[stop];
            int m = start;
            for (int i = 0; i < stop; i++)
            {
                if (prices[i] < min)
                {
                    m = i;
                    min = prices[i];
                }
            }

            for (int i = m + 1; i < stop; i++)
            {
                if (prices[i] > max)
                {
                    max = prices[i];
                }
            }
            return Math.Max((max - min), MaxProfitSub(prices, start, m - 1));
        }

        /*
         * Runtime: 92 ms, faster than 100.00% of C# online submissions for Best Time to Buy and Sell Stock.
         * Memory Usage: 23.1 MB, less than 66.35% of C# online submissions for Best Time to Buy and Sell Stock.
         *
         */
        // Much better, first was too complicated!
        public int MaxProfitV2(int[] prices)
        {
            if (prices.Length == 0) return 0;
            int minPrice = prices[0];
            int maxPro = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                maxPro = Math.Max(maxPro, (prices[i] - minPrice));
            }

            return maxPro;
        }
    }
}
