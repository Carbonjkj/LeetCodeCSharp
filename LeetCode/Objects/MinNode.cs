using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Objects
{
    public class MinNode
    {
        public int Val;
        public int Min;
        public MinNode Next;

        public MinNode(int val)
        {
            Val = val;
            Min = val;
        }
        public MinNode(int val, MinNode next)
        {
            Val = val;
            Min = Math.Min(val, next.Min);
            Next = next;
        }
    }
}
