using System;

namespace LeetCode.ProblemEZ
{
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
            var lastsep = -1;
            var sepbeforelast = -1;
            var wordsize = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    sepbeforelast = lastsep;
                    lastsep = i;
                    wordsize = lastsep - sepbeforelast <= 1 ? wordsize : lastsep - sepbeforelast - 1;
                }
            }

            if (lastsep != s.Length - 1)
            {
                wordsize = s.Length - 1 - lastsep;
            }

            return wordsize;




        }

    }
}
