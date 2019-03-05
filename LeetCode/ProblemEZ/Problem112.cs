using System;
using LeetCode.Objects;

namespace LeetCode.ProblemEZ
{
    /*
     * Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.
     *
     * Note: A leaf is a node with no children.
     */
    public class Problem112 : IProblem
    {
        public void run()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);

            int sum = 1;
            Console.WriteLine(HasPathSum(root, sum));
        }
        /*
         * Runtime: 96 ms, faster than 100.00% of C# online submissions for Path Sum.
         * Memory Usage: 24.2 MB, less than 8.33% of C# online submissions for Path Sum.
         */
        public bool HasPathSum(TreeNode root, int sum)
        {
            return HasPathSumSub(root, sum, 0);
        }

        public bool HasPathSumSub(TreeNode tn, int target, int currSum)
        {
            if (tn == null)
            {
                return false;
            }
            currSum += tn.val;
            if (tn.left == null && tn.right == null)
            {
                // after leaves, get sum for the path.
                return currSum == target;
            }
            // any sub path has true for return.
            return HasPathSumSub(tn.left, target, currSum) || HasPathSumSub(tn.right, target, currSum);
        }

    }
}
