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
            Console.WriteLine(IsBalanced(root));
        }
        public bool IsBalanced(TreeNode root)
        {
            return false;
        }
    }
}
