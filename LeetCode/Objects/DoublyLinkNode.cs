using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Objects
{
    public class DoublyLinkNode
    {
        public int val;
        public DoublyLinkNode next;
        public DoublyLinkNode parent;
        public DoublyLinkNode(int x)
        {
            val = x;
            next = null;
            parent = null;
        }
    }
}
