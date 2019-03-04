using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    /**
     * Given two binary strings, return their sum (also a binary string).
     *
     * The input strings are both non-empty and contains only characters 1 or 0.
     */
    public class Problem67 : IProblem
    {
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
}
