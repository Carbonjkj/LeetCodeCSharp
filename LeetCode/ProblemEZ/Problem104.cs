using System;
using LeetCode.Objects;

namespace LeetCode.ProblemEZ
{
    /*
     * Given a binary tree, find its maximum depth.
     *
     * The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
     *
     * Note: A leaf is a node with no children.
     * 
     */
    public class Problem104 : IProblem
    {
        public void run()
        {
            var root = new TreeNode(0);
            Console.WriteLine(MaxDepth(root));
        }
        /*
         * Runtime: 92 ms, faster than 100.00% of C# online submissions for Maximum Depth of Binary Tree.
         * Memory Usage: 23.4 MB, less than 47.41% of C# online submissions for Maximum Depth of Binary Tree.
         */
        public int MaxDepth(TreeNode root)
        {
            return MaxDepthSub(root, 0);
        }

        public int MaxDepthSub(TreeNode tn, int depth)
        {
            if (tn == null)
            {
                return depth;
            }
            else
            {
                depth++;
            }
            return Math.Max(MaxDepthSub(tn.left, depth), MaxDepthSub(tn.right, depth));
        }
    }
}
