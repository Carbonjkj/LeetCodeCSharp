using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Problem28 : IProblem
    {
        /*Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.*/

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
}
