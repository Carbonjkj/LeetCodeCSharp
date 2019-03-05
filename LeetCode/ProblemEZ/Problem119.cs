using System;
using System.Collections.Generic;

namespace LeetCode.ProblemEZ
{
    /*
     *
     * Given a non-negative index k where k ≤ 33, return the kth index row of the Pascal's triangle.
     *
     * Note that the row index starts from 0.
     *
     */
    public class Problem119 : IProblem
    {
        public void run()
        {
            Console.WriteLine(string.Join(" ", GetRow(12)));
        }

        /*
         * Runtime: 208 ms, faster than 100.00% of C# online submissions for Pascal's Triangle II.
         * Memory Usage: 23.4 MB, less than 7.32% of C# online submissions for Pascal's Triangle II.
         */
        public IList<int> GetRow(int rowIndex)
        {
            return GetRowSub(new List<int>(), rowIndex);
        }

        public IList<int> GetRowSub(IList<int> list, int row)
        {
            if (row == 0)
            {
                return new List<int>() { 1 };
            }

            return AddFromList(GetRowSub(list, row - 1));

        }
        public List<int> AddFromList(IList<int> list)
        {
            var newList = new List<int>();
            for (int i = 0; i <= list.Count; i++)
            {
                if (i == 0 || i == list.Count)
                {
                    newList.Add(1);
                }
                else
                {
                    newList.Add(list[i - 1] + list[i]);
                }
            }

            return newList;
        }

    }
}
