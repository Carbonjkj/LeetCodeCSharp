using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp4.Objects;

namespace ConsoleApp4.ProblemEZ
{
    /*
     * Given two binary trees, write a function to check if they are the same or not.
     *
     * Two binary trees are considered the same if they are structurally identical and the nodes have the same value.
     *
     */
    public class Problem100 : IProblem
    {


        public void run()
        {
            TreeNode p = new TreeNode(10), q = new TreeNode(10);
            q.left = new TreeNode(5);
            q.right = new TreeNode(15);
            p.left = new TreeNode(5);
            p.left.right = new TreeNode(15);
            Console.WriteLine(IsSameTreeV2(p, q));

        }

        /*
         * Runtime: 112 ms, faster than 46.82% of C# online submissions for Same Tree.
         * Memory Usage: 22.6 MB, less than 5.88% of C# online submissions for Same Tree.
         */
        // Too Slow, It's bullshit!
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            var traceP = TraversalTree(p, "", 0);
            Console.WriteLine(traceP);
            var traceQ = TraversalTree(q, "", 0);
            Console.WriteLine(traceQ);
            return traceP.Equals(traceQ);
        }
        public string TraversalTree(TreeNode p, string trace, int deep)
        {
            if (p != null)
            {
                trace = p.val.ToString();
                deep++;
            }
            else
            {
                return trace;
            }
            if (p.left != null)
            {
                trace += "0" + deep + TraversalTree(p.left, trace, deep);
            }

            if (p.right != null)
            {
                trace += "1" + deep + TraversalTree(p.right, trace, deep);
            }

            return trace;

        }

        /*
         * Runtime: 92 ms, faster than 100.00% of C# online submissions for Same Tree.
         * Memory Usage: 22.2 MB, less than 76.47% of C# online submissions for Same Tree.
         */
        // Much Faster!
        public bool IsSameTreeV2(TreeNode p, TreeNode q)
        {
            return p != null && q != null
                ? p.val == q.val && IsSameTreeV2(p.left, q.left) && IsSameTreeV2(p.right, q.right)
                : p == null && q == null;
        }
    }
}
