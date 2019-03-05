using System.Collections.Generic;

namespace LeetCode.ProblemEZ
{
    /*
     * Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
     */
    public class Problem118 : IProblem
    {
        public void run()
        {
            var rows = 8;
            var res = Generate(rows);
        }
        /*
         * Not use ref
         * Runtime: 212 ms, faster than 100.00% of C# online submissions for Pascal's Triangle.
         * Memory Usage: 23.5 MB, less than 26.32% of C# online submissions for Pascal's Triangle.
         */


        /*
         * use ref
         * Runtime: 236 ms, faster than 100.00% of C# online submissions for Pascal's Triangle.
         * Memory Usage: 23.3 MB, less than 78.95% of C# online submissions for Pascal's Triangle.
         *
         */
        // Confused, Thought is will be slow.
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> list = new List<IList<int>>();
            return GenerateSub(ref list, numRows, 1);
        }

        public IList<IList<int>> GenerateSub(ref IList<IList<int>> list, int target, int row)
        {
            if (target == 0)
            {
                return list;
            }
            if (row == target - 1)
            {
                return list;
            }
            if (row == 1)
            {
                list.Add(new List<int>() { 1 });
            }
            if (row > 1)
            {
                list.Add(AddFromList(list[row - 2]));

            }
            return GenerateSub(ref list, target, row + 1);
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
