using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp4.Objects;

namespace ConsoleApp4.ProblemEZ
{
    /*
     * Given a binary tree, determine if it is height-balanced.
     *
     * For this problem, a height-balanced binary tree is defined as:
     *
     * a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
     */
    public class Problem110 : IProblem
    {
        public void run()
        {
            var root = new TreeNode(0);
            //root.left = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.right = new TreeNode(2);
            Console.WriteLine(IsBalanced(root));
        }

        /*
         * Runtime: 100 ms, faster than 100.00% of C# online submissions for Balanced Binary Tree.
         * Memory Usage: 25.2 MB, less than 62.86% of C# online submissions for Balanced Binary Tree.
         */
        public bool IsBalanced(TreeNode root)
        {
            var n = IsBalancedSub(root, 0);
            Console.WriteLine(n);
            return n != -1;
        }

        public int IsBalancedSub(TreeNode tn, int depth)
        {

            if (tn == null)
            {
                return depth;
            }
            if (depth == -1)
            {
                depth = -1;
            }
            else
            {
                depth++;
            }
            var depl = IsBalancedSub(tn.left, depth);
            var depr = IsBalancedSub(tn.right, depth);
            if (Math.Abs(depl - depr) > 1)
            {
                return -1;
            }
            return Math.Max(depl, depr);
        }
    }
}
