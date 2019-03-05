using System.Collections.Generic;
using System.Linq;
using LeetCode.Objects;

namespace LeetCode.ProblemEZ
{
    /*
     * Given a binary tree, return the bottom-up level order traversal of its nodes' values. (ie, from left to right, level by level from leaf to root).
     *
     * For example:
     * Given binary tree [3,9,20,null,null,15,7],
     *
     * Return
     * [
     *  [15,7],
     *  [9,20],
     *  [3]
     * ]
     */
    public class Problem107 : IProblem
    {
        public void run()
        {
            var root = new TreeNode(0);
            root.left = new TreeNode(2);
            root.right = new TreeNode(4);
            root.right.left = new TreeNode(8);
            root.right.right = new TreeNode(10);
            LevelOrderBottom(root);
        }
        /*
         * Runtime: 276 ms, faster than 100.00% of C# online submissions for Binary Tree Level Order Traversal II.
         * Memory Usage: 29.2 MB, less than 60.00% of C# online submissions for Binary Tree Level Order Traversal II.
         */
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            list = TreeTraversal(root, list, 0);
            list = list.Reverse().ToList();
            return list;
        }

        public IList<IList<int>> TreeTraversal(TreeNode root, IList<IList<int>> list, int depth)
        {
            if (root == null)
            {
                return list;
            }

            if (depth > list.Count - 1)
            {
                list.Add(new List<int>());
            }
            list[depth].Add(root.val);
            depth++;
            list = TreeTraversal(root.left, list, depth);
            list = TreeTraversal(root.right, list, depth);
            return list;
        }
    }
}
