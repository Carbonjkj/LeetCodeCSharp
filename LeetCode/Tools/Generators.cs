using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tools
{
    public class Generators
    {
        public static int[] RandomIntArray(int length)
        {
            var random = new Random();
            var fileName = "randomInt" + length + ".txt";
            var nums = new int[length];
            if (File.Exists(fileName))
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
    }
}
