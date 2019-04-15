using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Objects;

namespace LeetCode.ProblemEZ
{
    // 1. Two Sum
    public class Problem1 : IProblem
    {
        /*
         * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
         *
         * You may assume that each input would have exactly one solution, and you may not use the same element twice.
         */
        public void run()
        {

        }
        /*
         * Runtime: 248 ms, faster than 99.47% of C# online submissions for Two Sum.
         * Memory Usage: 29.1 MB, less than 46.69% of C# online submissions for Two 
         */
        public int[] TwoSum(int[] nums, int target)
        {
            HashSet<int> set = new HashSet<int>();
            int first = 0, last = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    last = i;
                    break;
                }
                set.Add(target - nums[i]);
            }

            for (int i = 0; i < last; i++)
            {
                if (nums[i] == target - nums[last])
                {
                    first = i;
                }
            }
            return new[] { first, last };

        }
    }

    // 27. Remove Element
    public class Problem27 : IProblem
    {
        /*
         * Given an array nums and a value val, remove all instances of that value in-place and return the new length.
         *
         * Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
         *
         * The order of elements can be changed. It doesn't matter what you leave beyond the new length.
         *
         */
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
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(string.Join(" ", nums));
                if (nums[i] == val)
                {
                    var found = 1;
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

    // 28. Implement strStr()
    public class Problem28 : IProblem
    {
        /*
         * Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
         */

        public void run()
        {
            string haystack = "hellllco", needle = "llc"; //return 2
            Console.WriteLine(StrStr(haystack, needle));
        }


        /*
         * Runtime: 72 ms, faster than 100.00% of C# online submissions for Implement strStr().
         * Memory Usage: 20.4 MB, less than 44.93% of C# online submissions for Implement strStr().
         */
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }
            if (string.IsNullOrEmpty(haystack) || string.IsNullOrEmpty(needle))
            {
                return -1;
            }
            int found = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    found = 1;
                    for (int j = 1; j < needle.Length; j++)
                    {
                        if (i + j >= haystack.Length)
                        {
                            return -1;
                        }
                        if (haystack[i + j] == needle[j])
                        {
                            found++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (found == needle.Length)
                {
                    return i;
                }


            }
            return -1;
        }
    }

    // 35. Search Insert Position
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

    // 38. Count and Say
    public class Problem38 : IProblem
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

    // 53. Maximum Subarray
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

    // 58. Length of Last Word
    public class Problem58 : IProblem
    {
        /*
         * Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.
         *
         * If the last word does not exist, return 0.
         *
         * Note: A word is defined as a character sequence consists of non-space characters only.
         */
        public void run()
        {
            string str = "        "; //string.split should not be used.
            Console.WriteLine(LengthOfLastWord(str));
        }
        /*
         *  Runtime: 72 ms, faster than 100.00% of C# online submissions for Length of Last Word.
         *  Memory Usage: 19.8 MB, less than 97.87% of C# online submissions for Length of Last Word.
         */
        public int LengthOfLastWord(string s)
        {
            var lastStep = -1;
            var wordSize = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    var sepBeforeLast = lastStep;
                    lastStep = i;
                    wordSize = lastStep - sepBeforeLast <= 1 ? wordSize : lastStep - sepBeforeLast - 1;
                }
            }

            if (lastStep != s.Length - 1)
            {
                wordSize = s.Length - 1 - lastStep;
            }

            return wordSize;




        }

    }

    // 66. Plus One
    public class Problem66 : IProblem
    {
        /*
         * Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
         *
         * The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.
         *
         * You may assume the integer does not contain any leading zero, except the number 0 itself.     *
         */

        public void run()
        {
            int[] digits = new[] { 9, 9, 9 };
            Console.WriteLine(string.Join("", PlusOne(digits)));
        }
        /*
         * Runtime: 240 ms, faster than 100.00% of C# online submissions for Plus One.
         * Memory Usage: 28.1 MB, less than 71.23% of C# online submissions for Plus One.
         */
        public int[] PlusOne(int[] digits)
        {
            return PlusOneSub(digits, digits.Length - 1);
        }

        public int[] PlusOneSub(int[] digits, int pos)
        {
            if (pos < 0)
            {
                var di = new int[digits.Length + 1];
                di[0] = 1;
                digits.CopyTo(di, 1);
                return di;
            }
            if (digits[pos] != 9)
            {
                digits[pos] += 1;
                return digits;
            }
            else
            {
                digits[pos] = 0;
                return PlusOneSub(digits, pos - 1);
            }
        }
    }

    // 67. Add Binary
    public class Problem67 : IProblem
    {
        /**
         * Given two binary strings, return their sum (also a binary string).
         *
         * The input strings are both non-empty and contains only characters 1 or 0.
         */
        public void run()
        {
            string a = "1010", b = "1011"; // output 100;
            Console.WriteLine(AddBinary(a, b));
        }

        /*
         * Runtime: 84 ms, faster than 100.00% of C# online submissions for Add Binary.
         * Memory Usage: 23.6 MB, less than 37.88% of C# online submissions for Add Binary.
         */
        public string AddBinary(string a, string b)
        {
            int size = Math.Max(a.Length, b.Length);
            for (int i = a.Length; i < size; i++)
            {
                a = "0" + a;
            }
            for (int i = b.Length; i < size; i++)
            {
                b = "0" + b;
            }
            string c = "";
            bool add = false;
            for (int i = size - 1; i >= 0; i--)
            {
                if (a[i] == b[i])
                {
                    if (a[i] == '0')
                    {
                        c = (add ? "1" : "0") + c;
                        add = false;
                    }
                    else
                    {
                        c = (add ? "1" : "0") + c;
                        add = true;
                    }

                }
                else
                {
                    c = (add ? "0" : "1") + c;
                }
            }
            if (add)
            {
                c = "1" + c;
            }
            return c;
        }


    }

    // 69. Sqrt(x)
    public class Problem69 : IProblem
    {
        /*
         * Implement int sqrt(int x).
         *
         * Compute and return the square root of x, where x is guaranteed to be a non-negative integer.
         *
         * Since the return type is an integer, the decimal digits are truncated and only the integer part of the result is returned.
         *
         * */
        public void run()
        {
            int x = 2110439694;
            Console.WriteLine(MySqrt(x));
        }
        /*
         * Runtime: 48 ms, faster than 100.00% of C# online submissions for Sqrt(x).
         * Memory Usage: 13.1 MB, less than 36.07% of C# online submissions for Sqrt(x).
         */
        public int MySqrt(int x)
        {
            long tempx = x;
            for (long i = 0; i <= x; i++)
            {
                long tempi = i;
                if (i * i > tempx)
                {
                    return (int)i - 1;
                }

                for (int j = 2; j < i; j++)
                {
                    if (j * j * i * i < x)
                    {
                        tempi = j * i;
                    }
                    else
                    {
                        break;
                    }
                }
                i = tempi;
            }

            return x;
        }
    }

    // 70. Climbing Stairs
    public class Problem70 : IProblem
    {
        /*
         * You are climbing a stair case. It takes n steps to reach to the top.
         *
         * Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
         *
         * Note: Given n will be a positive integer.
         */
        public static int Count;

        public static Dictionary<int, int> KnownList = new Dictionary<int, int>();
        public void run()
        {
            int n = 44; // output 3
            Console.WriteLine(ClimbStairs(n));
            Console.WriteLine("Count: " + Count);
        }
        /*
         * Runtime: 40 ms, faster than 100.00% of C# online submissions for Climbing Stairs.
         * Memory Usage: 13.7 MB, less than 6.86% of C# online submissions for Climbing Stairs.
         */
        public int ClimbStairs(int n)
        {
            return ClimbOneStep(n);
        }

        public int ClimbOneStep(int n)
        {
            if (KnownList.Keys.Contains(n))
            {
                return KnownList[n];
            }
            Count++;
            if (n == 1)
            {
                return 1;
            }

            if (n == 2)
            {
                return 2;
            }

            var ways = ClimbOneStep(n - 2) + ClimbOneStep(n - 1);
            KnownList.Add(n, ways);
            Console.WriteLine($"curren Step {n}, current ways {ways}");
            return ways;
        }

    }

    // 83. Remove Duplicates from Sorted List
    public class Problem83 : IProblem
    {
        /*
         * Given a sorted linked list, delete all duplicates such that each element appear only once.
         */
        public void run()
        {
            var head = new ListNode(1);
            DeleteDuplicates(head);
        }

        /*
         * Runtime: 92 ms, faster than 100.00% of C# online submissions for Remove Duplicates from Sorted List.
         * Memory Usage: 23.9 MB, less than 13.95% of C# online submissions for Remove Duplicates from Sorted List.
         */
        public ListNode DeleteDuplicates(ListNode head)
        {
            var saveHead = head;
            while (head.next != null)
            {
                if (head.val == head.next.val)
                {
                    head.next = head.next.next;
                }
                else
                {
                    head = head.next;
                }
            }

            return saveHead;
        }
    }

    // 88. Merge Sorted Array
    class Problem88 : IProblem
    {
        /*
         * Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
         *
         * Note:
         *
         *      The number of elements initialized in nums1 and nums2 are m and n respectively.
         *      You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.
         */
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
            for (int i = 0; i < n; i++)
            {
                while (nums1[ind] <= nums2[i] && ind < m + i)
                {
                    ind++;
                }

                var tempind = ind;
                var temp = nums1[ind];
                nums1[ind] = nums2[i];

                while (ind < m + n - 1)
                {
                    ind++;
                    var temp2 = nums1[ind];
                    nums1[ind] = temp;
                    temp = temp2;
                }
                ind = tempind;
            }
            Console.WriteLine(string.Join(" ", nums1));
        }
    }

}
