using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp4.Objects;

namespace ConsoleApp4.ProblemEZ
{
    /*
     * Given a binary tree, find its minimum depth.
     *
     * The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
     *
     * Note: A leaf is a node with no children.
     */
    public class Problem111 : IProblem
    {

        public void run()
        {
            var root = new TreeNode(0);
            root.left = new TreeNode(0);
            root.left = new TreeNode(0);
            root.left.right = new TreeNode(0);
            root.left.left = new TreeNode(0);
            root.left.left.left = new TreeNode(0);
            root.left.left.left.left = new TreeNode(0);
            root.right = new TreeNode(0);
            root.right.left = new TreeNode(0);
            root.right.left.right = new TreeNode(0);
            Console.WriteLine(MinDepth(root));
        }

        /*
         * Runtime: 112 ms, faster than 99.66% of C# online submissions for Minimum Depth of Binary Tree.
         * Memory Usage: 24 MB, less than 81.48% of C# online submissions for Minimum Depth of Binary Tree.
         */
        // Not faster than 100% :(
        public int MinDepth(TreeNode root)
        {
            return MinDepthSub(root, 0);
        }

        public int MinDepthSub(TreeNode tn, int depth)
        {
            if (tn == null)
            {
                return depth;
            }
            depth++;
            if (tn.left != null && tn.right != null)
            {
                return Math.Min(MinDepthSub(tn.left, depth), MinDepthSub(tn.right, depth));
            }
            return Math.Max(MinDepthSub(tn.left, depth), MinDepthSub(tn.right, depth));
        }

    }
}
