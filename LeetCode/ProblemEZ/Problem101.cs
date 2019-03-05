using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp4.Objects;

namespace ConsoleApp4.ProblemEZ
{
    public class Problem101 : IProblem
    {
        /*
         * Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
         *
         * For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
         */
        public void run()
        {
            var root = new TreeNode(1);
            Console.WriteLine(IsSymmetric(root));
        }
        /*
         * Runtime: 92 ms, faster than 100.00% of C# online submissions for Symmetric Tree.
         * Memory Usage: 23 MB, less than 64.37% of C# online submissions for Symmetric Tree.
         */
        public bool IsSymmetric(TreeNode root)
        {
            return root == null ? true : IsSymmetricSub(root.left, root.right);
        }

        public bool IsSymmetricSub(TreeNode left, TreeNode right)
        {
            return left != null && right != null
                ? left.val == right.val
                  && IsSymmetricSub(left.left, right.right)
                  && IsSymmetricSub(left.right, right.left)
                : left == null && right == null;
        }
    }
}
