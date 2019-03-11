using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.ProblemEZ
{
    // 303. Range Sum Query - Immutable
    public class Problem303 : IProblem
    {
        /*
         * Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
         * Note:
         * You may assume that the array does not change.
         * There are many calls to sumRange function.
         */
        public void run()
        {

        }

        /*
         * Runtime: 148 ms, faster than 100.00% of C# online submissions for Range Sum Query - Immutable.
         * Memory Usage: 33.7 MB, less than 58.82% of C# online submissions for Range Sum Query - Immutable.
         */
        public class NumArray
        {

            public int[] sums;

            public NumArray(int[] nums)
            {
                sums = new int[nums.Length];
                int sum = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                    sums[i] = sum;
                }
            }

            public int SumRange(int i, int j)
            {
                if (i == 0) return sums[j];
                return sums[j] - sums[i - 1];
            }
        }
    }

    // 326. Power of Three
    public class Problem326 : IProblem
    {
        /*
         * Given an integer, write a function to determine if it is a power of three.
         * Follow up:
         * Could you do it without using any loop / recursion?
         */
        public void run()
        {

        }

        public bool IsPowerOfThree(int n)
        {
            return n > 0 && Math.Pow(3, 19) % n == 0;
        }
    }

    // 342. Power of Four
    public class Problem342 : IProblem
    {
        /*
         * Given an integer (signed 32 bits), write a function to check whether it is a power of 4.
         * Follow up: Could you solve it without loops/recursion?
         */
        public void run()
        {

        }

        /*
         * Runtime: 40 ms, faster than 100.00% of C# online submissions for Power of Four.
         * Memory Usage: 13.1 MB, less than 25.00% of C# online submissions for Power of Four.
         */
        bool isPowerOfFour(int num)
        {
            double sqrt = Math.Sqrt(num);
            return num > 0 && sqrt % 1 == 0 && 65536 % sqrt == 0;
        }
    }

    // 344. Reverse String
    public class Problem344 : IProblem
    {
        /*
         * Write a function that reverses a string. The input string is given as an array of characters char[].
         *
         * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
         *
         * You may assume all the characters consist of printable ascii characters.
         */
        public void run()
        {

        }
        /*
         * Runtime: 396 ms, faster than 57.30% of C# online submissions for Reverse String.
         * Memory Usage: 33.2 MB, less than 63.59% of C# online submissions for Reverse String.
         */
        public void ReverseString(char[] s)
        {
            int start = 0, stop = s.Length - 1;
            while (start < stop)
            {
                var tmp = s[start];
                s[start] = s[stop];
                s[stop] = tmp;
                start++;
                stop--;
            }
        }

    }

    // 345. Reverse Vowels of a String
    public class Problem345 : IProblem
    {
        /*
         * Write a function that takes a string as input and reverse only the vowels of a string.
         * Note:
         * The vowels does not include the letter "y".
         */
        public void run()
        {
        }
        /*
         * Use Array
         * Runtime: 136 ms, faster than 12.44% of C# online submissions for Reverse Vowels of a String.
         * Memory Usage: 26.9 MB, less than 7.69% of C# online submissions for Reverse Vowels of a String.
         */

        /*
         * Use HashSet
         * Runtime: 104 ms, faster than 83.11% of C# online submissions for Reverse Vowels of a String.
         * Memory Usage: 26.7 MB, less than 7.69% of C# online submissions for Reverse Vowels of a String.
         */
        public string ReverseVowels(string s)
        {
            var chars = s.ToCharArray();
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int start = 0, stop = chars.Length - 1;
            while (start < stop)
            {
                if (!vowels.Contains(chars[start])) start++;
                if (!vowels.Contains(chars[stop])) stop--;
                if (vowels.Contains(chars[start]) && vowels.Contains(chars[stop]))
                {
                    var tmp = chars[start];
                    chars[start] = chars[stop];
                    chars[stop] = tmp;
                    start++;
                    stop--;
                }
            }
            return string.Join("", chars);
        }
    }

    // 349. Intersection of Two Arrays
    public class Problem349 : IProblem
    {
        /*
         *
         * Given two arrays, write a function to compute their intersection.
         * Note:
         *
         * Each element in the result must be unique.
         * The result can be in any order.
         */
        public void run()
        {
        }
        /*
         * Runtime: 268 ms, faster than 81.61% of C# online submissions for Intersection of Two Arrays.
         * Memory Usage: 29.6 MB, less than 6.12% of C# online submissions for Intersection of Two Arrays.
         */
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            HashSet<int> set3 = new HashSet<int>();
            for (int i = 0; i < nums1.Length; i++)
                set1.Add(nums1[i]);
            for (int i = 0; i < nums2.Length; i++)
                set2.Add(nums2[i]);
            foreach (var i in set2)
            {
                if (!set1.Add(i)) set3.Add(i);
            }
            return set3.ToArray();
        }
        /*
         * Runtime: 272 ms, faster than 80.46% of C# online submissions for Intersection of Two Arrays.
         * Memory Usage: 29.3 MB, less than 26.53% of C# online submissions for Intersection of Two Arrays.
         */

        public int[] IntersectionV2(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                set1.Add(nums1[i]);
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                if (set1.Contains(nums2[i]))
                    set2.Add(nums2[1]);
            }

            return set2.ToArray();
        }
    }
}
