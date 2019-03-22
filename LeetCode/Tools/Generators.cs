using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tools
{
    public class Generators
    {
        public static int[] RandomIntArray(int length, bool alwaysNew = false)
        {
            var random = new Random();
            var fileName = "randomInt" + length + ".txt";
            var nums = new int[length];
            if (File.Exists(fileName) && !alwaysNew)
            {
                var text = File.ReadAllText(fileName);
                var numStrs = text.Split(';');
                for (int i = 0; i < length; i++)
                {
                    nums[i] = Convert.ToInt32(numStrs[i]);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    nums[i] = random.Next(-length, length);
                }
                File.WriteAllText(fileName, string.Join(";", nums));
            }
            return nums;
        }
        public static int[] RandomIntArrayPositive(int length, bool alwaysNew = false)
        {
            var random = new Random();
            var fileName = "randomIntPos" + length + ".txt";
            var nums = new int[length];
            if (File.Exists(fileName) && !alwaysNew)
            {
                var text = File.ReadAllText(fileName);
                var numStrs = text.Split(';');
                for (int i = 0; i < length; i++)
                {
                    nums[i] = Convert.ToInt32(numStrs[i]);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    nums[i] = random.Next(1, length * 2);
                }
                File.WriteAllText(fileName, string.Join(";", nums));
            }
            return nums;
        }

        public static int[] RandomIntArrayNonDuplicate(int length, bool alwaysNew = false)
        {
            var random = new Random();
            var fileName = "randomIntNonDup" + length + ".txt";
            var nums = new int[length];
            if (File.Exists(fileName) && !alwaysNew)
            {
                var text = File.ReadAllText(fileName);
                var numStrs = text.Split(';');
                for (int i = 0; i < length; i++)
                {
                    nums[i] = Convert.ToInt32(numStrs[i]);
                }
            }
            else
            {
                HashSet<int> hash = new HashSet<int>();
                while (hash.Count < length)
                {
                    hash.Add(random.Next(-length, length));
                }
                File.WriteAllText(fileName, string.Join(";", hash.ToArray()));
            }
            return nums;
        }

        public static int[] RandomIntArrayNonDuplicatePos(int length, bool alwaysNew = false)
        {
            var random = new Random();
            var fileName = "randomIntNonDupPos" + length + ".txt";
            var nums = new int[length];
            if (File.Exists(fileName) && !alwaysNew)
            {
                var text = File.ReadAllText(fileName);
                var numStrs = text.Split(';');
                for (int i = 0; i < length; i++)
                {
                    nums[i] = Convert.ToInt32(numStrs[i]);
                }
            }
            else
            {
                HashSet<int> hash = new HashSet<int>();
                while (hash.Count < length)
                {
                    hash.Add(random.Next(1, length * 2));
                }
                File.WriteAllText(fileName, string.Join(";", hash.ToArray()));
            }
            return nums;
        }

        public static int[] RandomIntArrayNonNeg(int length, bool alwaysNew = false)
        {
            var random = new Random();
            var fileName = "randomIntNonNeg" + length + ".txt";
            var nums = new int[length];
            if (File.Exists(fileName) && !alwaysNew)
            {
                var text = File.ReadAllText(fileName);
                var numStrs = text.Split(';');
                nums = new int[numStrs.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = Convert.ToInt32(numStrs[i]);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    nums[i] = random.Next(0, length / 2);
                }
                File.WriteAllText(fileName, string.Join(";", nums));
            }
            return nums;
        }

        public static int[,] Ordered2DMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            int value = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = value++;
                }
            }
            return matrix;
        }
    }
}
