using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Problem35 : IProblem
    {
        /*
         * Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
         * You may assume no duplicates in the array.
         */
        public void run()
        {
            int[] nums = new[] { 1, 1, 3, 5 };
            int target = 5;
            Console.WriteLine(SearchInsert(nums, target));
        }

        /*
         * Runtime: 92 ms, faster than 100.00% of C# online submissions for Search Insert Position.
         * Memory Usage: 22.5 MB, less than 43.33% of C# online submissions for Search Insert Position.
         */
        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            if (nums[nums.Length - 1] < target)
            {
                return nums.Length;
            }
            int pos = 0;
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] < target)
                    {
                        pos = i + 1;
                    }
                    else if (nums[i] == target)
                    {
                        pos = i;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return pos;

        }
    }
}
