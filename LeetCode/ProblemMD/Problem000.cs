using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LeetCode.Objects;
using LeetCode.Tools;

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

    // 6. ZigZag Conversion todo optimize
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
    }

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
                    if (sum > 214748364 || sum == 214748364 && str[start] - 48 > 7)
                        return negative ? int.MinValue : int.MaxValue;
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

    // 12. Integer to Roman todo optimize
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

    }

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
            int[] nums = Generators.RandomIntArray(1000);
            Console.WriteLine(ThreeSumV2(nums).Count == ThreeSumV3(nums).Count);
            //var list = ThreeSum(nums);



            // Print
            //foreach (var l in list)
            //{
            //    Console.WriteLine(string.Join(" ", l));
            //}
        }

        /*
         * Runtime: 4008 ms, faster than 7.33% of C# online submissions for 3Sum.
         * Memory Usage: 52 MB, less than 5.66% of C# online submissions for 3Sum.
         */

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            HashSet<string> listSet = new HashSet<string>();
            var watch = new Stopwatch();
            int k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 100 == 0)
                {
                    watch.Stop();
                    Console.WriteLine("Time for " + 100 * k++ + ": " + watch.Elapsed + " Found: " + list.Count);
                    watch.Restart();
                }

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

        /*
         * Runtime: 712 ms, faster than 27.26% of C# online submissions for 3Sum.
         * Memory Usage: 51.2 MB, less than 5.66% of C# online submissions for 3Sum.
         */
        // todo: Improve filter more
        public IList<IList<int>> ThreeSumV2(int[] nums)
        {
            HashSet<int> filter = new HashSet<int>();
            HashSet<string> dupSet = new HashSet<string>();
            List<IList<int>> list = new List<IList<int>>();
            var watch = new Stopwatch();
            int k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 100 == 0)
                {
                    watch.Stop();
                    Console.WriteLine("Time for " + 100 * k++ + ": " + watch.Elapsed + " Found: " + list.Count);
                    watch.Restart();
                }

                if (filter.Add(nums[i]))
                {
                    list.AddRange(TwoSumV2(nums, i, -nums[i], ref dupSet));
                }
            }

            return list;
        }

        public IList<IList<int>> TwoSumV2(int[] nums, int start, int target, ref HashSet<string> dupSet)
        {
            HashSet<int> set = new HashSet<int>();
            IList<IList<int>> list = new List<IList<int>>();
            for (int i = start + 1; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    var li = new List<int>() { -target, nums[i], target - nums[i] };
                    li.Sort(); // O(1) because n is always 3
                    if (dupSet.Add(string.Join(";", li)))
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


        // Use sorted array take O(nlogn) to O(n^2)
        /*
         * Runtime: 312 ms, faster than 94.66% of C# online submissions for 3Sum.
         * Memory Usage: 34.3 MB, less than 93.40% of C# online submissions for 3Sum.
         */
        public IList<IList<int>> ThreeSumV3(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            Array.Sort(nums);
            var watch = new Stopwatch();
            for (int i = 0; i < nums.Length;)
            {
                if (i % 100 == 0)
                {
                    watch.Stop();
                    Console.WriteLine("Time for " + i + ": " + watch.Elapsed + " Found: " + list.Count);
                    watch.Restart();
                }

                int start = i + 1, stop = nums.Length - 1, target = -nums[i];
                while (start < stop)
                {
                    if (nums[start] + nums[stop] == target)
                    {
                        list.Add(new List<int>() { nums[i], nums[start], nums[stop] });
                        while (start < stop && nums[start] == nums[++start]) ;
                        while (start < stop && nums[stop] == nums[--stop]) ;
                    }
                    else if (nums[start] + nums[stop] > target)
                        while (start < stop && nums[stop] == nums[--stop])
                            ;
                    else
                        while (start < stop && nums[start] == nums[++start])
                            ;
                }

                while (++i < nums.Length && nums[i] == -target)
                {
                    ;
                }
            }

            return list;
        }
    }

    // 16. 3Sum Closest
    public class Problem16 : IProblem
    {
        /*
         * Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target. Return the sum of the three integers. You may assume that each input would have exactly one solution.
         *
         * Example:
         *
         * Given array nums = [-1, 2, 1, -4], and target = 1.
         *
         * The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
         */
        public void run()
        {
            var random = new Random();
            int length = 10000;
            var fileName = "nums" + length + ".txt";
            var nums = new int[length];

            // Create File;
            //for (int i = 0; i < length; i++)
            //{
            //    nums[i] = random.Next(-length, length);
            //}
            //File.WriteAllText(fileName, string.Join(";", nums));

            // Read File;
            var text = File.ReadAllText(fileName);
            var numStrs = text.Split(';');
            for (int i = 0; i < length; i++)
            {
                nums[i] = Convert.ToInt32(numStrs[i]);
            }

            //var list = ThreeSum(nums);
            //nums = new int[] { -1, -5, -3, -4, 2, -2 };
            int target = 7000;
            ThreeSumClosest(nums, target);
        }

        /*
         * Runtime: 116 ms, faster than 73.06% of C# online submissions for 3Sum Closest.
         * Memory Usage: 22.5 MB, less than 100.00% of C# online submissions for 3Sum Closest.
         */
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Length <= 3) return nums.Sum();
            Array.Sort(nums);
            int closest = nums[0] + nums[1] + nums[2];
            for (int i = 0; i < nums.Length;)
            {
                int old = target - nums[i], start = i + 1, stop = nums.Length - 1;
                while (start < stop)
                {
                    if (nums[start] + nums[stop] == old)
                    {
                        Console.WriteLine(
                            $"new combination find: {target - old},{nums[start]},{nums[stop]} :{closest}");
                        return target;
                    }

                    if (nums[start] + nums[stop] < old)
                    {
                        int s = old - nums[start] - nums[stop];
                        if (s < Math.Abs(closest - target))
                        {
                            closest = target - s;
                            Console.WriteLine(
                                $"new combination find: {target - old},{nums[start]},{nums[stop]} :{closest}");
                        }

                        while (start < stop && nums[start] == nums[++start]) ;
                    }
                    else
                    {
                        int s = nums[start] + nums[stop] - old;
                        if (s < Math.Abs(closest - target))
                        {
                            closest = target + s;
                            Console.WriteLine(
                                $"new combination find: {target - old},{nums[start]},{nums[stop]} :{closest}");
                        }

                        while (start < stop && nums[stop] == nums[--stop]) ;
                    }
                }

                while (++i < nums.Length && nums[i] == target - old) ;
            }

            return closest;
        }


    }

    // 17. Letter Combinations of a Phone Number
    public class Problem17 : IProblem
    {
        /*
         * Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
         *
         * A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
         *
         * Note:
         *
         * Although the above answer is in lexicographical order, your answer could be in any order you want.
         */

        public void run()
        {
            Console.WriteLine(string.Join("\n", LetterCombinations("235927")));
        }

        /*
         * Runtime: 264 ms, faster than 78.88% of C# online submissions for Letter Combinations of a Phone Number.
         * Memory Usage: 29.3 MB, less than 36.15% of C# online submissions for Letter Combinations of a Phone 
         */
        public IList<string> LetterCombinations(string digits)
        {
            var list = new List<string>();
            foreach (var digit in digits)
            {
                Combination(ref list, GetChars(digit));
            }

            return list;
        }

        private char[] GetChars(char digit)
        {
            switch (digit)
            {
                case '2':
                    return new char[] { 'a', 'b', 'c' };
                case '3':
                    return new char[] { 'd', 'e', 'f' };
                case '4':
                    return new char[] { 'g', 'h', 'i' };
                case '5':
                    return new char[] { 'j', 'k', 'l' };
                case '6':
                    return new char[] { 'm', 'n', 'o' };
                case '7':
                    return new char[] { 'p', 'q', 'r', 's' };
                case '8':
                    return new char[] { 't', 'u', 'v' };
                case '9':
                    return new char[] { 'w', 'x', 'y', 'z' };
                default:
                    return null;
            }
        }

        public void Combination(ref List<string> list, char[] chars)
        {
            if (chars == null) return;
            if (list.Count == 0)
            {
                foreach (var c in chars)
                {
                    list.Add(c + "");
                }

                return;
            }

            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                for (int j = chars.Length - 1; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        list[i] += chars[j];
                    }
                    else
                    {
                        list.Add(list[i] + chars[j]);
                    }
                }
            }
        }
    }

    // 18. 4Sum
    public class Problem18 : IProblem
    {
        /*
         * Given an array nums of n integers and an integer target, are there elements a, b, c, and d in nums such that a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.
         *
         * Note:
         *
         * The solution set must not contain duplicate quadruplets.
         */
        public void run()
        {
            var nums = Generators.RandomIntArray(500);
            int target = 0;
            FourSum(nums, target);
        }

        /*
         * Runtime: 1700 ms, faster than 5.14% of C# online submissions for 4Sum.
         * Memory Usage: 30.6 MB, less than 33.33% of C# online submissions for 4Sum.
         */
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Array.Sort(nums);
            var sw = new Stopwatch();
            sw.Start();
            TargetSum(nums, -1, 4, target, ref list);
            sw.Stop();
            Console.WriteLine(list.Count + " time: " + sw.Elapsed);
            list = new List<IList<int>>();
            sw.Restart();
            TargetSumV2(nums, -1, 4, target, ref list);
            sw.Stop();
            Console.WriteLine(list.Count + " time: " + sw.Elapsed);
            return list;
        }

        private static int counter = 0;

        public bool TargetSum(int[] nums, int start, int level, int target, ref IList<IList<int>> list)
        {
            if (level == 0) return false;
            for (int i = start + 1; i < nums.Length;)
            {
                counter++;
                int tmp = nums[i];
                if (level == 1 && tmp == target)
                {
                    //Console.WriteLine($"Found {target} @ loop {counter}");
                    list.Add(new List<int>() { tmp });
                    return true;
                }
                else
                {
                    if (TargetSum(nums, i, level - 1, target - nums[i], ref list))
                    {
                        foreach (var li in list)
                        {
                            if (li.Count == level - 1) li.Add(tmp);
                            //Console.WriteLine("(" + string.Join(",", li) + ")");
                        }
                    }

                }

                while (++i < nums.Length && nums[i] == tmp) ;
            }

            return true;
        }

        /*
         * Runtime: 292 ms, faster than 89.12% of C# online submissions for 4Sum.
         * Memory Usage: 30.5 MB, less than 41.67% of C# online submissions for 4Sum.
         */
        public bool TargetSumV2(int[] nums, int start, int level, int target, ref IList<IList<int>> list)
        {
            if (level == 0) return false;
            if (level == 2)
            {
                int begin = start + 1, stop = nums.Length - 1;
                while (begin < stop)
                {
                    if (nums[begin] + nums[stop] == target)
                    {
                        list.Add(new List<int>() { nums[begin], nums[stop] });
                        while (begin < stop && nums[begin] == nums[++begin]) ;
                        while (begin < stop && nums[stop] == nums[--stop]) ;
                    }
                    else if (nums[begin] + nums[stop] > target)
                        while (begin < stop && nums[stop] == nums[--stop])
                            ;
                    else
                        while (begin < stop && nums[begin] == nums[++begin])
                            ;
                }

                return true;
            }

            for (int i = start + 1; i < nums.Length;)
            {
                counter++;
                int tmp = nums[i];
                if (TargetSum(nums, i, level - 1, target - nums[i], ref list))
                {
                    foreach (var li in list)
                    {
                        if (li.Count == level - 1) li.Add(tmp);
                        //Console.WriteLine("(" + string.Join(",", li) + ")");
                    }
                }

                while (++i < nums.Length && nums[i] == tmp) ;
            }

            return true;
        }

    }

    // 19. Remove Nth Node From End of List
    public class Problem19 : IProblem
    {
        /*
         * Given a linked list, remove the n-th node from the end of list and return its head.
         *
         * Example:
         *
         * Given linked list: 1->2->3->4->5, and n = 2.
         *
         * After removing the second node from the end, the linked list becomes 1->2->3->5.
         * Note:
         *
         * Given n will always be valid.
         *
         * Follow up:
         *
         * Could you do this in one pass?
         */
        public void run()
        {
            var ln = new ListNode(1);
            ln.next = new ListNode(2);
            RemoveNthFromEnd(ln, 2);
        }

        /*
         * Runtime: 88 ms, faster than 100.00% of C# online submissions for Remove Nth Node From End of List.
         * Memory Usage: 22.2 MB, less than 97.47% of C# online submissions for Remove Nth Node From End of List.
         */
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null || head.next == null) return null;
            var saved = head;
            var tempNode = head;
            int cnt = 0;

            while (head.next != null)
            {
                if (cnt >= n)
                {
                    tempNode = tempNode.next;
                }


                cnt++;
                head = head.next;
            }

            if (cnt == n - 1) return saved.next;
            tempNode.next = n == 1 ? null : tempNode.next.next;
            return saved;
        }
    }

    // 22. Generate Parentheses
    public class Problem22 : IProblem
    {
        /*
         * Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
         *
         * For example, given n = 3, a solution set is:
         * [
         * "((()))",
         * "(()())",
         * "(())()",
         * "()(())",
         * "()()()"
         * ]
         */

        public void run()
        {
            var list = GenerateParenthesisV2(3);
            Console.WriteLine(string.Join("\n", list));
        }

        // Todo fix this idea  (())(()) doesnt work.
        public IList<string> GenerateParenthesis(int n)
        {
            var hash = new HashSet<string>();
            int k = n;
            while (k > 1)
            {
                string sides = "";
                for (int i = 0; i < n - k; i++)
                {
                    sides = "(" + sides + ")";
                }
                var pn = new ParenthesisNode(k--);
                var list = GetBranch(pn);
                foreach (var str in list)
                {
                    hash.Add(str + sides);
                }
            }


            //Console.WriteLine(string.Join("\n", hash));
            return hash.ToList();

        }

        public List<string> GetBranch(ParenthesisNode pn)
        {
            var list = new List<string>();
            if (pn.Left == null || pn.Inner == null || pn.Right == null) return new List<string>() { "()" };
            foreach (var str in GetBranch(pn.Left))
            {
                list.Add(str + "()");
            }
            foreach (var str in GetBranch(pn.Right))
            {
                list.Add("()" + str);
            }
            foreach (var str in GetBranch(pn.Inner))
            {
                list.Add("(" + str + ")");
            }
            return list;
        }

        public class ParenthesisNode
        {
            public ParenthesisNode Left { get; set; }
            public ParenthesisNode Inner { get; set; }
            public ParenthesisNode Right { get; set; }

            public ParenthesisNode(int n)
            {
                if (--n <= 0)
                {
                    Left = null;
                    Right = null;
                    Inner = null;
                }
                else
                {
                    Left = new ParenthesisNode(n);
                    Right = new ParenthesisNode(n);
                    Inner = new ParenthesisNode(n);
                }

            }
        }

        // V2
        /*
         * Runtime: 244 ms, faster than 95.69% of C# online submissions for Generate Parentheses.
         * Memory Usage: 31.2 MB, less than 21.31% of C# online submissions for Generate Parentheses.
         */
        public IList<string> GenerateParenthesisV2(int n)
        {
            var list = new List<string>();
            GenerateParenthesisSub(ref list, "", 0, 0, n);
            return list;
        }

        public void GenerateParenthesisSub(ref List<string> list, string str, int open, int close, int n)
        {
            if (str.Length == n * 2)
            {
                list.Add(str);
                return;
            }

            if (open < n)
            {
                Console.WriteLine(str + "(");
                GenerateParenthesisSub(ref list, str + "(", open + 1, close, n);
            }

            if (close < open)
            {
                Console.WriteLine(str + ")");
                GenerateParenthesisSub(ref list, str + ")", open, close + 1, n);
            }
        }


    }

    // 24. Swap Nodes in Pairs
    public class Problem24 : IProblem
    {
        /*
         * Given a linked list, swap every two adjacent nodes and return its head.
         *
         * You may not modify the values in the list's nodes, only nodes itself may be changed.
         * Example:
         *
         * Given 1->2->3->4, you should return the list as 2->1->4->3.
         *
         */
        public void run()
        {
            var nod = new ListNode(1);
            nod.next = new ListNode(2);
            nod.next.next = new ListNode(3);
            nod.next.next.next = new ListNode(4);
            SwapPairs(nod);
        }
        /*
         * Runtime: 104 ms, faster than 69.35% of C# online submissions for Swap Nodes in Pairs.
         * Memory Usage: 22 MB, less than 25.81% of C# online submissions for Swap Nodes in Pairs.
         */
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;
            int k = 0;
            var newHead = head.next;
            var temp = head;
            while (head != null && head.next != null)
            {
                temp.next = head.next;
                temp = head;
                head = head.next;
                temp.next = head.next;
                head.next = temp;
                head = temp.next;
            }
            return newHead;
        }
    }

    // 29. Divide Two Integers todo: Not done yet.
    public class Problem29 : IProblem
    {
        /*
         * Given two integers dividend and divisor, divide two integers without using multiplication, division and mod operator.
         *
         * Return the quotient after dividing dividend by divisor.
         *
         * The integer division should truncate toward zero.
         *
         * Note:
         *
         * Both dividend and divisor will be 32-bit signed integers.
         * The divisor will never be 0.
         * Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 231 − 1 when the division result overflows.
         *
         */
        public void run()
        {
            bool failed = false;
            var rand = new Random();
            int c = 2;
            switch (c)
            {
                case 1:
                    Console.WriteLine(Divide(2082257274, 1413922502));
                    break;
                case 2:
                    while (!failed)
                    {
                        int a = rand.Next(Int32.MinValue, Int32.MaxValue);
                        int b = rand.Next(1, 3);
                        int std = a / b;
                        int myd = Divide(a, b);
                        failed = std != myd;
                        Console.WriteLine($"{a} , {b} = {std}:{myd}, {!failed}");
                    }
                    break;
            }

        }
        /*
         * Int32.MinValue > Int32.MaxValue  make overflow
         * Int32.MinValue/MaxValue divided by small divisor take long time.
         */
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 1) return dividend;
            if (divisor == -1) return dividend == Int32.MinValue ? Int32.MaxValue : -dividend;
            bool positive = true;
            if (divisor > 0)
            {
                positive = !positive;
                divisor = -divisor;
            }
            if (dividend > 0)
            {
                positive = !positive;
                dividend = -dividend;
            }
            int count = 0;
            while (dividend < 0)
            {
                dividend -= divisor;
                if (dividend <= 0) count++;
            }
            return positive ? count : -count;
        }
    }

    // 31. Next Permutation
    public class Problem31 : IProblem
    {
        /*
         * Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
         *
         * If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).
         *
         * The replacement must be in-place and use only constant extra memory.
         *
         * Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
         *
         * 1,2,3 → 1,3,2
         * 3,2,1 → 1,2,3
         * 1,1,5 → 1,5,1
         */
        public void run()
        {
            NextPermutation(new[] { 1, 2, 3 });
        }
        /*
         * Runtime: 248 ms, faster than 93.03% of C# online submissions for Next Permutation.
         * Memory Usage: 29.5 MB, less than 76.74% of C# online submissions for Next Permutation.
         */

        /*
         * 1. Iterate over every character, we will get the last value i (starting from the first character) that satisfies the given condition S[i] < S[i + 1]
         * 2. Now, we will get the last value j such that S[i] < S[j]
         * 3. We now interchange S[i] and S[j]. And for every character from i+1 till the end, we sort the characters. i.e., sort(S[i+1]..S[len(S) - 1])
         */
        public void NextPermutation(int[] nums)
        {
            var size = nums.Length;
            int i = -1, j = 0;
            for (int k = 0; k < size - 1; k++)
            {
                if (nums[k] < nums[k + 1]) i = k;
            }

            if (i == -1)
            {
                Reverse(ref nums, 0);
                return;
            }
            for (int k = +1; k < size; k++)
            {
                if (nums[k] > nums[i]) j = k;
            }

            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            Reverse(ref nums, i + 1);
            return;
        }

        public void Reverse(ref int[] nums, int start)
        {
            int stop = nums.Length - 1;
            while (start < stop)
            {
                var temp = nums[start];
                nums[start] = nums[stop];
                nums[stop] = temp;
                start++;
                stop--;
            }
        }
    }

    // 33. Search in Rotated Sorted Array
    public class Problem33 : IProblem
    {
        /*
         * Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
         *
         * (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).
         *
         * You are given a target value to search. If found in the array return its index, otherwise return -1.
         *
         * You may assume no duplicate exists in the array.
         *
         * Your algorithm's runtime complexity must be in the order of O(log n).
         */
        public void run()
        {
            Console.WriteLine(Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6));
        }
        /*
         * Runtime: 92 ms, faster than 99.89% of C# online submissions for Search in Rotated Sorted Array.
         * Memory Usage: 22.5 MB, less than 87.39% of C# online submissions for Search in Rotated Sorted Array.
         */
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            return SearchSub(nums, 0, nums.Length - 1, target);
        }

        public int SearchSub(int[] nums, int start, int stop, int target)
        {
            if (nums[start] == target) return start;
            if (nums[stop] == target) return stop;
            if (stop - start <= 1) return -1;
            if (nums[stop] > nums[start])
            {
                if (target > nums[stop]) return -1;
                if (target < nums[start]) return -1;

            }
            var first = SearchSub(nums, start, (start + stop) / 2, target);
            var last = SearchSub(nums, (start + stop) / 2, stop, target);
            if (first != -1) return first;
            if (last != -1) return last;
            return -1;

        }
    }

    //
}
