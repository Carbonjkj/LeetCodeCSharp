using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.ProblemMD
{
    // 5. Longest Palindromic Substring
    public class Problem5 : IProblem
    {
        /*
         * Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
         */
        public void run()
        {
            Console.WriteLine(LongestPalindrome(""));
        }
        /*
         * Runtime: 84 ms, faster than 100.00% of C# online submissions for Longest Palindromic Substring.
         * Memory Usage: 21.5 MB, less than 58.49% of C# online submissions for Longest Palindromic Substring.
         */

        public string LongestPalindrome(string s)
        {
            if (s == "") return "";
            if (s.Length == 1) return s;
            var bytes = s.ToCharArray();
            // Example cbaaaaabc
            int maxLen = 0;
            int maxInd = 0;
            // c b a a a a a b c

            for (int i = 0; i < bytes.Length;)
            {
                if (bytes.Length - i <= maxLen / 2) break;
                int start = i, stop = i;
                // c b a a a a a b c
                //     i(j)       
                while (stop < bytes.Length - 1 && bytes[stop + 1] == bytes[stop])
                {
                    stop++;
                }

                i = stop + 1;
                // c b a a a a a b c
                //     i       j
                while (start > 0 && stop < bytes.Length - 1 && bytes[start - 1] == bytes[stop + 1])
                {
                    stop++;
                    start--;
                }

                // c b a a a a a b c   =>  c b a a a a a b c
                //   i           j     =>  i     length    j
                int newLen = stop - start + 1;
                if (newLen > maxLen)
                {
                    maxInd = start;
                    maxLen = newLen;
                }
            }

            return s.Substring(maxInd, maxLen);
        }
    }

    // 6. ZigZag Conversion
    public class Problem6 : IProblem
    {
        /*
         * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
         *
         * P   A   H   N
         * A P L S I I G
         * Y   I   R
         * And then read line by line: "PAHNAPLSIIGYIR"
         *
         * Write the code that will take a string and make this conversion given a number of rows:
         *
         * string convert(string s, int numRows);
         */
        public void run()
        {
            Convert("01234567890123456789", 4);
        }
        /*
         * Runtime: 172 ms, faster than 17.79% of C# online submissions for ZigZag Conversion.
         * Memory Usage: 34.2 MB, less than 5.95% of C# online submissions for ZigZag Conversion.
         */
        public string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;
            int len = s.Length;
            int numCols = 0;
            if (len < numRows)
            {
                numCols = 1;
            }
            else
            {
                numCols = (len - numRows) / (numRows * 2 - 2);
                int ex = (len - numRows) % (numRows * 2 - 2);
                if (ex > numRows - 2) ex = numRows - 1;
                numCols = 1 + numCols * (numRows - 1) + ex;
            }
            char[,] charMatrix = new char[numRows, numCols];
            int k = 0;
            for (int j = 0; j < numCols; j++)
            {
                for (int i = 0; i < numRows; i++)
                {
                    if (k >= len) break;
                    if (j % (numRows - 1) == 0) charMatrix[i, j] = s[k++];
                    else
                    {
                        int m = j % (numRows - 1);
                        if (i == (numRows - 1) - m) charMatrix[i, j] = s[k++];
                    }
                }
            }

            string retval = "";
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (charMatrix[i, j] != 0x00)
                    {
                        retval += charMatrix[i, j];
                    }
                }

            }
            Console.WriteLine($"numRows: {numRows}, numCols: {numCols} \nS:\n{retval}");
            return retval;
        }
    } //todo:

    // 8. String to Integer (atoi)
    public class Problem8 : IProblem
    {
        /*
         * Implement atoi which converts a string to an integer.
         *
         * The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.
         * The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.
         *
         *
         * If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.
         *
         * If no valid conversion could be performed, a zero value is returned.
         *
         * Note:
         *
         * Only the space character ' ' is considered as whitespace character.
         * Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. If the numerical value is out of the range of representable values, INT_MAX (231 − 1) or INT_MIN (−231) is returned.
         */
        public void run()
        {
            Console.WriteLine(MyAtoi("-91283472332"));
        }
        /*
         * Runtime: 76 ms, faster than 100.00% of C# online submissions for String to Integer (atoi).
         * Memory Usage: 22.7 MB, less than 94.17% of C# online submissions for String to Integer (atoi).
         */
        public int MyAtoi(string str)
        {
            int start = 0;
            bool negative = false;
            // remove white space
            while (start < str.Length - 1 && str[start] == ' ')
            {
                start++;
            }
            // check if signed
            if (start >= str.Length) return 0;
            if (str[start] == 43 || str[start] == 45)
            {
                negative = str[start] == 45;
                start++;
            }
            int sum = 0;
            while (start < str.Length)
            {
                if (str[start] >= 48 && str[start] <= 57)
                {
                    // Check overflow
                    if (sum > 214748364 || sum == 214748364 && str[start] - 48 > 7) return negative ? int.MinValue : int.MaxValue;
                    sum = str[start] - 48 + sum * 10;
                    start++;
                }
                else
                {
                    break;
                }
            }

            return negative ? 0 - sum : sum;
        }
    }

    // 11. Container With Most Water
    public class Problem11 : IProblem
    {
        /*
         * Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.
         *
         * Note: You may not slant the container and n is at least 2.
         */
        public void run()
        {
            Console.WriteLine(MaxArea(new[] { 3, 2, 1, 3 }));
        }
        /*
         * Runtime: 1728 ms, faster than 8.29% of C# online submissions for Container With Most Water.
         * Memory Usage: 25.7 MB, less than 7.63% of C# online submissions for Container With Most Water.
         */
        public int MaxArea(int[] height)
        {

            int curMax = Math.Min(height[0], height[height.Length - 1]) * (height.Length - 1);
            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] * Math.Max(i - 0, height.Length - 1 - i) < curMax) continue;
                for (int j = height.Length - 1; j >= 0; j--)
                {
                    curMax = Math.Max(Math.Min(height[i], height[j]) * Math.Abs(i - j), curMax);
                }
            }

            return curMax;
        }
        /*
         * Runtime: 104 ms, faster than 95.89% of C# online submissions for Container With Most Water.
         * Memory Usage: 25.3 MB, less than 93.13% of C# online submissions for Container With Most Water.
         */
        public int MaxAreaV2(int[] height)
        {

            int start = 0, stop = height.Length - 1;
            int curMax = Math.Min(height[start], height[stop]) * (height.Length - 1);
            while (start < stop)
            {
                curMax = Math.Max(Math.Min(height[start], height[stop]) * Math.Abs(stop - start), curMax);
                if (height[start] > height[stop])
                {
                    stop--;
                }
                else
                {
                    start++;
                }
            }

            return curMax;
        }
    }

    // 12. Integer to Roman
    public class Problem12 : IProblem
    {
        /*
         * Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
         *
         * Symbol       Value
         * I             1
         * V             5
         * X             10
         * L             50
         * C             100
         * D             500
         * M             1000
         * For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.
         *
         * Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
         *
         * I can be placed before V (5) and X (10) to make 4 and 9.
         * X can be placed before L (50) and C (100) to make 40 and 90.
         * C can be placed before D (500) and M (1000) to make 400 and 900.
         * Given an integer, convert it to a roman numeral. Input is guaranteed to be within the range from 1 to 3999.
         */
        public void run()
        {
            var random = new Random();
            for (int i = 0; i < 20; i++)
            {
                IntToRoman(random.Next(1000, 4000));
            }
        }
        /*
         * Runtime: 100 ms, faster than 99.67% of C# online submissions for Integer to Roman.
         * Memory Usage: 24.4 MB, less than 30.44% of C# online submissions for Integer to Roman.
         */
        public string IntToRoman(int num)
        {
            Console.WriteLine("input:   " + num);
            int a = 0, b = 0;
            char[] tecken = new char[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M', ' ' };
            string roman = "";
            while (num > 0)
            {
                a = num % 10;
                string s = tecken[2 * b] + "", m = tecken[2 * b + 1] + "";
                switch (a)
                {
                    case 0:
                        break;
                    case 1:
                        roman = s + roman;
                        break;
                    case 2:
                        roman = s + s + roman;
                        break;
                    case 3:
                        roman = s + s + s + roman;
                        break;
                    case 4:
                        roman = s + m + roman;
                        break;
                    case 5:
                        roman = m + roman;
                        break;
                    case 6:
                        roman = m + s + roman;
                        break;
                    case 7:
                        roman = m + s + s + roman;
                        break;
                    case 8:
                        roman = m + s + s + s + roman;
                        break;
                    case 9:
                        roman = s + tecken[2 * b + 2] + roman;
                        break;
                }
                num = num / 10;
                b++;
            }
            Console.WriteLine("output:  " + roman);
            return roman;
        }

    }  // todo: 

    // 15. 3Sum
    public class Problem15 : IProblem
    {
        /*
         * Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
         *
         * Note:
         *
         * The solution set must not contain duplicate triplets.
         */
        public void run()
        {
            var list = ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });
            foreach (var l in list)
            {
                Console.WriteLine(string.Join(" ", l));
            }
        }
        /*
         * Runtime: 4008 ms, faster than 7.33% of C# online submissions for 3Sum.
         * Memory Usage: 52 MB, less than 5.66% of C# online submissions for 3Sum.
         */

        // todo: Is O(n^2) so slow?
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            HashSet<string> listSet = new HashSet<string>();
            for (int i = 0; i < nums.Length; i++)
            {
                list.AddRange(TwoSum(nums, i, -nums[i], ref listSet));
            }
            return list;
        }
        public IList<IList<int>> TwoSum(int[] nums, int start, int target, ref HashSet<string> listSet)
        {
            HashSet<int> set = new HashSet<int>();
            IList<IList<int>> list = new List<IList<int>>();
            for (int i = start + 1; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    var li = new List<int>() { -target, nums[i], target - nums[i] };
                    li.Sort(); // O(1) because n is always 3
                    if (listSet.Add(string.Join(";", li)))
                    {
                        list.Add(li);
                    }
                }
                else
                {
                    set.Add(target - nums[i]);
                }
            }

            return list;
        }

        public IList<IList<int>> ThreeSumV2(int[] nums)
        {
            return null;
        }
    }
}
