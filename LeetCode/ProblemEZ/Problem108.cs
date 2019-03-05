using LeetCode.Objects;

namespace LeetCode.ProblemEZ
{
    /*
     * Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
     *
     * For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
     *
     */
    public class Problem108 : IProblem
    {

        public void run()
        {
            int[] nums = new[] { -2, 3, 5, 8, 9, 10, 34, 69, 56, 77, 77, 77, 77, 77 };
        }

        /*
         * Runtime: 96 ms, faster than 100.00% of C# online submissions for Convert Sorted Array to Binary Search Tree.
         * Memory Usage: 23.6 MB, less than 84.21% of C# online submissions for Convert Sorted Array to Binary Search Tree.
         */
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return InsertIntoTree(nums, 0, nums.Length - 1);
        }

        public TreeNode InsertIntoTree(int[] nums, int start, int stop)
        {
            // end point;
            if (start > stop)
            {
                return null;
            }
            // took mid element in sub array
            var ind = (start + stop) / 2;
            var node = new TreeNode(nums[ind]);


            node.left = InsertIntoTree(nums, start, ind - 1);
            node.right = InsertIntoTree(nums, ind + 1, stop);
            return node;
        }


    }
}
