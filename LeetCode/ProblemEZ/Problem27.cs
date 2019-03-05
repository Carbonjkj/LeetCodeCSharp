using System;

namespace LeetCode.ProblemEZ
{
    /*
     * Given an array nums and a value val, remove all instances of that value in-place and return the new length.
     *
     * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
     *
     * The order of elements can be changed. It doesn't matter what you leave beyond the new length.
     *
     */
    public class Problem27 : IProblem
    {
        public void run()
        {
            int[] nums = new[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            int val = 2;
            RemoveElement(nums, val);
        }

        /*
         * Runtime: 252 ms, faster than 100.00% of C# online submissions for Remove Element.
         * Memory Usage: 28.6 MB, less than 5.06% of C# online submissions for Remove Element.
         */
        public int RemoveElement(int[] nums, int val)
        {
            int found = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(string.Join(" ", nums));
                if (nums[i] == val)
                {
                    found = 1;
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[j] != val)
                        {
                            break;
                        }
                        found++;
                    }

                    Console.WriteLine($"i = {i}, found = {found}");
                    if (i + found >= nums.Length)
                    {
                        break;
                    }
                    nums[i] = nums[i + found];
                    nums[i + found] = val;
                }
            }
            return 0;
        }

    }
}
