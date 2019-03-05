using System;

namespace LeetCode.ProblemEZ
{
    /*
     * Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
     *
     * Note:
     *
     *      The number of elements initialized in nums1 and nums2 are m and n respectively.
     *      You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.
     */
    class Problem88 : IProblem
    {
        public void run()
        {
            int[] nums1 = new[] { 1, 2, 3, 0, 0, 0 }, nums2 = new int[] { 2, 5, 6 };// output 1,2,2,3,4,6
            int m = 3, n = 3;

            Merge(nums1, m, nums2, n);

        }
        /*
         * Runtime: 244 ms, faster than 100.00% of C# online submissions for Merge Sorted Array.
         * Memory Usage: 28.7 MB, less than 34.43% of C# online submissions for Merge Sorted Array.
         */
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int ind = 0;
            var tempind = 0;
            for (int i = 0; i < n; i++)
            {
                while (nums1[ind] <= nums2[i] && ind < m + i)
                {
                    ind++;
                }

                tempind = ind;
                var temp = nums1[ind];
                var temp2 = 0;
                nums1[ind] = nums2[i];

                while (ind < m + n - 1)
                {
                    ind++;
                    temp2 = nums1[ind];
                    nums1[ind] = temp;
                    temp = temp2;


                }
                ind = tempind;
            }
            Console.WriteLine(string.Join(" ", nums1));
        }
    }
}
