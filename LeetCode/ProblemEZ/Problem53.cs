using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Problem53 : IProblem
    {
        /*
         * Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
         */
        public void run()
        {
            int[] nums = new[] { -1, -2, -1, 2 };
            Console.WriteLine(MaxSubArray(nums));
        }
        /*  OBS: RETRY!
         *  Runtime: 112 ms, faster than 99.89% of C# online submissions for Maximum Subarray.
         *  Memory Usage: 23.2 MB, less than 63.21% of C# online submissions for Maximum Subarray.
         */
        public int MaxSubArray(int[] nums)
        {
            int MaxSoFar = nums[0];
            int MaxForNow = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                MaxForNow = Math.Max(MaxForNow + nums[i], nums[i]);
                MaxSoFar = Math.Max(MaxSoFar, MaxForNow);
                Console.WriteLine($"MFN {MaxForNow}, MSF {MaxSoFar}");
            }
            return MaxSoFar;

        }



    }
}
