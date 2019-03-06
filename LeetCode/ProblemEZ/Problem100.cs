using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.Objects;

namespace LeetCode.ProblemEZ
{
    // 100. Same Tree
    public class Problem100 : IProblem
    {
        /*
         * Given two binary trees, write a function to check if they are the same or not.
         *
         * Two binary trees are considered the same if they are structurally identical and the nodes have the same value.
         *
         */

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
            return p != null && q != null // not all null condition
                ? p.val == q.val && IsSameTreeV2(p.left, q.left) &&
                  IsSameTreeV2(p.right, q.right) // p.left = q.left and p.right = q.right and p.val == q.val(endpoint)
                : p == null && q == null; // all null = true(endpoint);
        }
    }

    // 101. Symmetric Tree
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

    // 104. Maximum Depth of Binary Tree
    public class Problem104 : IProblem
    {
        /*
         * Given a binary tree, find its maximum depth.
         *
         * The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
         *
         * Note: A leaf is a node with no children.
         * 
         */

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

    // 107. Binary Tree Level Order Traversal II
    public class Problem107 : IProblem
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

    // 108. Convert Sorted Array to Binary Search Tree
    public class Problem108 : IProblem
    {

        /*
         * Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
         *
         * For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
         *
         */
        public void run()
        {
            int[] nums = new[] { -2, 3, 5, 8, 9, 10, 34, 69, 56, 77, 77, 77, 77, 77 };
            SortedArrayToBST(nums);
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

    // 110. Balanced Binary Tree
    public class Problem110 : IProblem
    {
        /*
         * Given a binary tree, determine if it is height-balanced.
         *
         * For this problem, a height-balanced binary tree is defined as:
         *
         * a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
         */
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

    // 111. Minimum Depth of Binary Tree
    public class Problem111 : IProblem
    {
        /*
         * Given a binary tree, find its minimum depth.
         *
         * The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
         *
         * Note: A leaf is a node with no children.
         */

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

    // 112. Path Sum
    public class Problem112 : IProblem
    {
        /*
         * Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.
         *
         * Note: A leaf is a node with no children.
         */
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

    // 118. Pascal's Triangle
    public class Problem118 : IProblem
    {
        /*
         * Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
         */
        public void run()
        {
            var rows = 8;
            Generate(rows);
        }
        /*
         * Not use ref
         * Runtime: 212 ms, faster than 100.00% of C# online submissions for Pascal's Triangle.
         * Memory Usage: 23.5 MB, less than 26.32% of C# online submissions for Pascal's Triangle.
         */


        /*
         * use ref
         * Runtime: 236 ms, faster than 100.00% of C# online submissions for Pascal's Triangle.
         * Memory Usage: 23.3 MB, less than 78.95% of C# online submissions for Pascal's Triangle.
         *
         */
        // Confused, Thought is will be slow.
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> list = new List<IList<int>>();
            return GenerateSub(ref list, numRows, 1);
        }

        public IList<IList<int>> GenerateSub(ref IList<IList<int>> list, int target, int row)
        {
            if (target == 0)
            {
                return list;
            }

            if (row == target - 1)
            {
                return list;
            }

            if (row == 1)
            {
                list.Add(new List<int>() { 1 });
            }

            if (row > 1)
            {
                list.Add(AddFromList(list[row - 2]));

            }

            return GenerateSub(ref list, target, row + 1);
        }

        public List<int> AddFromList(IList<int> list)
        {
            var newList = new List<int>();
            for (int i = 0; i <= list.Count; i++)
            {
                if (i == 0 || i == list.Count)
                {
                    newList.Add(1);
                }
                else
                {
                    newList.Add(list[i - 1] + list[i]);
                }
            }

            return newList;
        }
    }


    // 119. Pascal's Triangle II
    public class Problem119 : IProblem
    {
        /*
         *
         * Given a non-negative index k where k ≤ 33, return the kth index row of the Pascal's triangle.
         *
         * Note that the row index starts from 0.
         *
         */
        public void run()
        {
            Console.WriteLine(string.Join(" ", GetRow(12)));
        }

        /*
         * Runtime: 208 ms, faster than 100.00% of C# online submissions for Pascal's Triangle II.
         * Memory Usage: 23.4 MB, less than 7.32% of C# online submissions for Pascal's Triangle II.
         */
        public IList<int> GetRow(int rowIndex)
        {
            return GetRowSub(new List<int>(), rowIndex);
        }

        public IList<int> GetRowSub(IList<int> list, int row)
        {
            if (row == 0)
            {
                return new List<int>() { 1 };
            }

            return AddFromList(GetRowSub(list, row - 1));

        }

        public List<int> AddFromList(IList<int> list)
        {
            var newList = new List<int>();
            for (int i = 0; i <= list.Count; i++)
            {
                if (i == 0 || i == list.Count)
                {
                    newList.Add(1);
                }
                else
                {
                    newList.Add(list[i - 1] + list[i]);
                }
            }

            return newList;
        }

    }

    // 121. Best Time to Buy and Sell Stock
    public class Problem121 : IProblem
    {
        /*
        * Say you have an array for which the ith element is the price of a given stock on day i.
        *
        * If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.
        *
        * Note that you cannot sell a stock before you buy one.
        */

        public void run()
        {
            var prices = new[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfitV2(prices));
        }

        /*
         * Runtime: 148 ms, faster than 26.80% of C# online submissions for Best Time to Buy and Sell Stock.
         * Memory Usage: 23.6 MB, less than 5.61% of C# online submissions for Best Time to Buy and Sell Stock.
         */
        // Worst ever!!!!!! Looking for better solution!
        public int MaxProfit(int[] prices)
        {
            return MaxProfitSub(prices, 0, prices.Length - 1);
        }

        public int MaxProfitSub(int[] prices, int start, int stop)
        {
            if (stop <= start)
            {
                return 0;
            }

            int min = prices[start], max = prices[stop];
            int m = start;
            for (int i = 0; i < stop; i++)
            {
                if (prices[i] < min)
                {
                    m = i;
                    min = prices[i];
                }
            }

            for (int i = m + 1; i < stop; i++)
            {
                if (prices[i] > max)
                {
                    max = prices[i];
                }
            }

            return Math.Max((max - min), MaxProfitSub(prices, start, m - 1));
        }

        /*
         * Runtime: 92 ms, faster than 100.00% of C# online submissions for Best Time to Buy and Sell Stock.
         * Memory Usage: 23.1 MB, less than 66.35% of C# online submissions for Best Time to Buy and Sell Stock.
         *
         */
        // Much better, first one was too complicated!
        public int MaxProfitV2(int[] prices)
        {
            if (prices.Length == 0) return 0;
            int minPrice = prices[0];
            int maxPro = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                maxPro = Math.Max(maxPro, (prices[i] - minPrice));
            }

            return maxPro;
        }
    }

    // 122. Best Time to Buy and Sell Stock II
    class Problem122 : IProblem
    {
        /*
         *
         * Say you have an array for which the ith element is the price of a given stock on day i.
         *
         * Design an algorithm to find the maximum profit. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).
         *
         * Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).
         */
        public void run()
        {
            var prices = new[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(MaxProfit(prices));
        }

        /*
         * Runtime: 96 ms, faster than 100.00% of C# online submissions for Best Time to Buy and Sell Stock II.
         * Memory Usage: 23.1 MB, less than 60.78% of C# online submissions for Best Time to Buy and Sell Stock II.
         */
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }

            int min = prices[0];
            int profit = 0;
            // bottom and peak
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i - 1] > prices[i])
                {
                    profit += (prices[i - 1] - min);
                    min = prices[i];
                    continue;
                }

                if (i < prices.Length - 2 && prices[i] < prices[i + 1])
                {
                    min = Math.Min(min, prices[i]);
                    //min = prices[i];
                }

            }

            if (prices[prices.Length - 1] > min)
            {
                profit += prices[prices.Length - 1] - min;
            }

            return profit;
        }
    }

    // 125. Valid Palindrome
    public class Problem125 : IProblem
    {
        /*
         * Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
         *
         * Note: For the purpose of this problem, we define empty string as valid palindrome.
         *
         */
        public void run()
        {
            Console.WriteLine(IsPalindrome("0 man, a plan, a anal: PanamP"));
        }

        /*
         * Runtime: 76 ms, faster than 100.00% of C# online submissions for Valid Palindrome.
         * Memory Usage: 22.1 MB, less than 60.92% of C# online submissions for Valid Palindrome.
         */
        public bool IsPalindrome(string s)
        {
            int start = 0;
            int stop = s.Length - 1;
            char c1, c2;
            while (start < stop)
            {
                c1 = s[start];
                c2 = s[stop];
                if (!ValidChar(c1))
                {
                    start++;
                    continue;
                }

                if (!ValidChar(c2))
                {
                    stop--;
                    continue;
                }

                if (c1 > 96) c1 = (char)(c1 - 32);
                if (c2 > 96) c2 = (char)(c2 - 32);
                if (c1 != c2)
                {
                    return false;
                }

                start++;
                stop--;

            }

            return true;
        }

        public bool ValidChar(char c)
        {
            return (c > 64 && c < 91) || (c > 96 && c < 123) || (c > 47 && c < 58);
        }

    }

    // 136. Single Number
    public class Problem136 : IProblem
    {
        /**
         * Given a non-empty array of integers, every element appears twice except for one. Find that single one.
         *
         * Note:
         *
         * Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
         */
        public void run()
        {
            var nums = new[] { 4, 4, 2 };
            Console.WriteLine(SingleNumber(nums));
        }

        /*
         *  Runtime: 104 ms, faster than 93.39% of C# online submissions for Single Number.
         *  Memory Usage: 24.2 MB, less than 87.84% of C# online submissions for Single Number.
         */
        public int SingleNumber(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                // 0 XOR A = A and A XOR A = 0; 
                nums[0] ^= nums[i];
            }

            return nums[0];
        }

        /*
         * 96 ms -> 100%
         * 24.3MB -> 50% 
         */
        public int SingleNumberV2(int[] nums)
        {
            int n = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                // 0 XOR A = A and A XOR A = 0; 
                n ^= nums[i];
            }

            return n;
        }
    }

    // 141. Linked List Cycle
    public class Problem141 : IProblem
    {
        /*
         * Given a linked list, determine if it has a cycle in it.
         *
         * To represent a cycle in the given linked list, we use an integer pos which represents the position (0-indexed) in the linked list where tail connects to. If pos is -1, then there is no cycle in the linked list.
         */

        public void run()
        {
            var head = new ListNode(0);
            head.next = new ListNode(0);
            Console.WriteLine(HasCycle(head));
        }

        /*
         * Runtime: 108 ms, faster than 86.16% of C# online submissions for Linked List Cycle.
         * Memory Usage: 23.7 MB, less than 43.24% of C# online submissions for Linked List Cycle.
         */

        // todo: Optimize somewhere to beat 100%
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;
            bool bo = false;
            var headSlow = head;
            while (head.next != null)
            {
                head = head.next;
                if (headSlow == head) return true;
                if (bo) headSlow = headSlow.next;
                bo = !bo;
            }

            return false;
        }



        /*
         * Runtime: 116 ms, faster than 46.57% of C# online submissions for Linked List Cycle.
         * Memory Usage: 23.8 MB, less than 25.67% of C# online submissions for Linked List Cycle.
         */
        public bool HasCyclev2(ListNode head)
        {
            if (head == null) return false;
            var headSlow = head;
            while (head.next?.next != null)
            {
                head = head.next.next;
                headSlow = headSlow.next;
                if (headSlow == head) return true;
            }

            return false;
        }

        /*
         * Runtime: 112 ms, faster than 79.82% of C# online submissions for Linked List Cycle.
         * Memory Usage: 23.8 MB, less than 20.27% of C# online submissions for Linked List Cycle.
         */
        public bool HasCyclev3(ListNode head)
        {
            if (head == null) return false;
            var headSlow = head;
            head = head.next;
            while (head?.next?.next != null)
            {
                if (headSlow == head) return true;
                headSlow = headSlow.next;
                head = head.next.next;
            }

            return false;
        }

    }

    // 155. Min Stack
    #region Problem155

    public class Problem155 : IProblem
    {
        /*
     * Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
     *
     * push(x) -- Push element x onto stack.
     * pop() -- Removes the element on top of the stack.
     * top() -- Get the top element.
     * getMin() -- Retrieve the minimum element in the stack.
     */
        /*
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(x);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.GetMin();
         */
        public void run()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-1);
            Console.WriteLine(minStack.Top()); // --> Returns 0.
            Console.WriteLine(minStack.GetMin());
            minStack.Push(1);
            Console.WriteLine(minStack.Top()); // --> Returns 0.
            Console.WriteLine(minStack.GetMin()); //--> Returns - 3.
            //minStack.Pop();
            //Console.WriteLine(minStack.GetMin());   //--> Returns - 2.
        }
    }


    public class MinStackBad
    {
        /*
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(x);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.GetMin();
         */
        // First In Last Out


        /*
         * Runtime: 728 ms, faster than 5.09% of C# online submissions for Min Stack.
         * Memory Usage: 33.4 MB, less than 44.90% of C# online submissions for Min Stack.
         */
        // This is bullshit!!!!!! This is STUPID!! Why did i consist at looking for the last element!!!!
        private ListNode stack;

        /** initialize your data structure here. */


        public void Push(int x)
        {
            if (stack == null)
            {
                stack = new ListNode(x);
            }
            else
            {
                var temp = stack;
                while (temp.next != null)
                {
                    temp = temp.next;
                }

                temp.next = new ListNode(x);
            }
        }

        public void Pop()
        {
            if (stack?.next == null)
            {
                stack = null;
                return;
            }

            var temp = stack;
            while (temp.next.next != null)
            {
                temp = temp.next;
            }

            temp.next = null;
        }

        public int Top()
        {
            var temp = stack;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            return temp.val;
        }

        public int GetMin()
        {
            var temp = stack;
            int min = stack?.val ?? 0;
            while (temp.next != null)
            {
                temp = temp.next;
                min = Math.Min(min, temp.val);
            }

            return min;
        }
    }

    public class MinStackBetter
    {
        /*
         * Runtime: 300 ms, faster than 16.55% of C# online submissions for Min Stack.
         * Memory Usage: 33.2 MB, less than 91.84% of C# online submissions for Min Stack.
         */

        // This is Still BullShit!
        /** initialize your data structure here. */
        private List<int> _stack;
        private int _pos;

        public MinStackBetter()
        {
            _stack = new List<int>();
            _pos = 0;
        }

        public void Push(int x)
        {
            if (_pos > _stack.Count - 1)
            {
                _stack.Add(x);
                _pos++;
            }
            else
            {
                _stack[_pos++] = x;
            }
        }

        public void Pop()
        {
            if (--_pos < 0) _pos = 0;
        }

        public int Top()
        {
            if (_pos - 1 < 0) _pos = 0;
            return _stack[_pos - 1];
        }

        public int GetMin()
        {
            int min = _stack[0];
            for (int i = 0; i < _pos; i++)
            {
                if (_stack[i] < min)
                {
                    min = _stack[i];
                }
            }

            return min;
        }
    }


    public class MinStack
    {
        /*
         * Runtime: 140 ms, faster than 92.73% of C# online submissions for Min Stack.
         * Memory Usage: 33.5 MB, less than 30.61% of C# online submissions for Min Stack.
         */
        private MinNode stack;

        /** initialize your data structure here. */

        public void Push(int x)
        {
            if (stack == null)
            {
                stack = new MinNode(x);
            }
            else
            {
                stack = new MinNode(x, stack);
            }
        }

        public void Pop()
        {
            stack = stack.Next;
        }

        public int Top()
        {
            return stack.Val;
        }

        public int GetMin()
        {
            return stack.Min;
        }
    }



    #endregion

    // 160. Intersection of Two Linked Lists
    public class Problem160 : IProblem
    {
        /*
         * Write a program to find the node at which the intersection of two singly linked lists begins.
         *
         * For example, the following two linked lists:
         *
         *
         * begin to intersect at node c1.
         *
         *
         *
         * Example 1:
         *
         *
         * Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,0,1,8,4,5], skipA = 2, skipB = 3
         * Output: Reference of the node with value = 8
         * Input Explanation:   The intersected node's value is 8 (note that this must not be 0 if the two lists intersect).
         *                      From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,0,1,8,4,5].
         *                      There are 2 nodes before the intersected node in A;
         *                      There are 3 nodes before the intersected node in B.
         *
         *
         * Example 2:
         *
         *
         * Input: intersectVal = 2, listA = [0,9,1,2,4], listB = [3,2,4], skipA = 3, skipB = 1
         * Output: Reference of the node with value = 2
         * Input Explanation:   The intersected node's value is 2 (note that this must not be 0 if the two lists intersect).
         *                      From the head of A, it reads as [0,9,1,2,4]. From the head of B, it reads as [3,2,4].
         *                      There are 3 nodes before the intersected node in A;
         *                      There are 1 node before the intersected node in B.
         *
         *
         * Example 3:
         *
         *
         * Input: intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
         * Output: null
         * Input Explanation: From the head of A, it reads as [2,6,4]. From the head of B, it reads as [1,5]. Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
         * Explanation: The two lists do not intersect, so return null.
         *
         *
         * Notes:
         *
         * If the two linked lists have no intersection at all, return null.
         * The linked lists must retain their original structure after the function returns.
         * You may assume there are no cycles anywhere in the entire linked structure.
         * Your code should preferably run in O(n) time and use only O(1) memory.
         */
        public void run()
        {
            var listCommon = new ListNode(8);
            listCommon.next = new ListNode(7);
            listCommon.next.next = new ListNode(6);
            var headA = new ListNode(2);
            headA.next = new ListNode(1);
            headA.next.next = listCommon;
            var headB = new ListNode(3);
            headB.next = new ListNode(5);
            headB.next.next = new ListNode(1);
            headB.next.next.next = listCommon;
            Console.WriteLine(GetIntersectionNode(headA, headB).val);
        }

        /*
         *
         * Runtime: 132 ms, faster than 96.19% of C# online submissions for Intersection of Two Linked Lists.
         * Memory Usage: 34 MB, less than 35.85% of C# online submissions for Intersection of Two Linked Lists.
         */
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;
            var a = headA;
            var b = headB;

            // Get from discussion, it's an awesome solution.
            // list a = headA + headB and list b = headB + headA
            // if they have intersection, both a and b will be in a cycle, and the first intersection node will return;
            // if they dont have intersection, both a and  b will become null, and out of while loop, return null;
            while (a != b)
            {
                a = a != null ? a.next : headB;
                b = b != null ? b.next : headA;
            }

            return a;
        }


    }

    // 167. Two Sum II - Input array is sorted
    public class Problem167 : IProblem
    {
        /*
         * Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
         *
         * The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.
         *
         * Note:
         *
         * Your returned answers (both index1 and index2) are not zero-based.
         * You may assume that each input would have exactly one solution and you may not use the same element twice.
         */
        public void run()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7 };
            int target = 3;
            Console.WriteLine(string.Join(" ", TwoSum(numbers, target)));
        }

        /*
         * Runtime: 280 ms, faster than 87.22% of C# online submissions for Two Sum II - Input array is sorted.
         * Memory Usage: 29.3 MB, less than 14.71% of C# online submissions for Two Sum II - Input array is sorted.
         */
        public int[] TwoSum(int[] numbers, int target)
        {
            int start = 0;
            int stop = numbers.Length - 1;

            while (start < stop)
            {
                if (numbers[start] + numbers[stop] < target)
                {
                    start++;
                    continue;
                }

                if (numbers[start] + numbers[stop] > target)
                {
                    stop--;
                    continue;
                }

                return new[] { ++start, ++stop };
            }

            return null;
        }
    }

    // 168. Excel Sheet Column Title
    public class Problem168 : IProblem
    {
        /*
         * Given a positive integer, return its corresponding column title as appear in an Excel sheet.
         */
        public void run()
        {
            Console.WriteLine(ConvertToTitle(28));
        }

        /*
         * Runtime: 76 ms, faster than 100.00% of C# online submissions for Excel Sheet Column Title.
         * Memory Usage: 20.2 MB, less than 68.42% of C# online submissions for Excel Sheet Column Title.
         */
        public string ConvertToTitle(int n)
        {
            string s = "";
            while (n > 0)
            {
                int m = n % 26;
                if (m == 0) m = 26;
                s = (char)(m + 64) + s;
                n = (n - m) / 26;
            }

            return s;
        }

    }

    // 169. Majority Element
    public class Problem169 : IProblem
    {
        /*
         * Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
         *
         * You may assume that the array is non-empty and the majority element always exist in the array.
         */
        public void run()
        {
            var nums = new[] { 1, 2, 1, 1, 1, 6 };
            Console.WriteLine(MajorityElement(nums));
        }

        /*
         * Runtime: 120 ms, faster than 93.78% of C# online submissions for Majority Element.
         * Memory Usage: 27.4 MB, less than 85.71% of C# online submissions for Majority Element.
         */
        public int MajorityElement(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }

        /*
         * Moore voting algorithm
         * Runtime: 108 ms, faster than 100.00% of C# online submissions for Majority Element.
         * Memory Usage: 27.6 MB, less than 22.45% of C# online submissions for Majority Element.
         */
        public int MajorityElementV2(int[] nums)
        {
            int count = 0;
            int major = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    count++;
                    major = nums[i];
                }
                else if (major == nums[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }

            }

            return major;
        }
    }

    // 171. Excel Sheet Column Number
    public class Problem171 : IProblem
    {
        /*
        * Given a column title as appear in an Excel sheet, return its corresponding column number.
        *
        * For example: Z = 26; AA = 27; AB = 28;
        */
        public void run()
        {
            Console.WriteLine(TitleToNumber("AA"));
        }

        /*
         * Runtime: 76 ms, faster than 100.00% of C# online submissions for Excel Sheet Column Number.
         * Memory Usage: 22.9 MB, less than 9.52% of C# online submissions for Excel Sheet Column Number.
         */
        public int TitleToNumber(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            int k, sum = 0, size = s.Length;
            for (int i = 0; i < size; i++)
            {
                k = s[i] - 64;
                sum += k * (int)Math.Pow(26, (size - 1 - i));
            }

            return sum;
        }
    }

    // 172. Factorial Trailing Zeroes
    public class Problem172 : IProblem
    {
        /*
        * Given an integer n, return the number of trailing zeroes in n!.
        */
        public void run()
        {
            Console.WriteLine(TrailingZeroes(99));
        }

        /*
         * Runtime: 36 ms, faster than 100.00% of C# online submissions for Factorial Trailing Zeroes.
         * Memory Usage: 12.9 MB, less than 88.89% of C# online submissions for Factorial Trailing Zeroes.
         */
        public int TrailingZeroes(int n)
        {
            return n == 0 ? 0 : n / 5 + TrailingZeroes(n / 5);
        }


    }

    // 175. Combine Two Tables (SQL)   
    public class Problem175 : IProblem
    {
        /*
        * SQL Schema
        * Table: Person
        * 
        * +-------------+---------+
        * | Column Name | Type    |
        * +-------------+---------+
        * | PersonId    | int     |
        * | FirstName   | varchar |
        * | LastName    | varchar |
        * +-------------+---------+
        * PersonId is the primary key column for this table.
        * Table: Address
        * 
        * +-------------+---------+
        * | Column Name | Type    |
        * +-------------+---------+
        * | AddressId   | int     |
        * | PersonId    | int     |
        * | City        | varchar |
        * | State       | varchar |
        * +-------------+---------+
        * AddressId is the primary key column for this table.
        *  
        * 
        * Write a SQL query for a report that provides the following information for each person in the Person table, regardless if there is an address for each of those people:
        * 
        * FirstName, LastName, City, State
        */
        public void run()
        {
            /*
             * Runtime: 233 ms, faster than 20.77% of MySQL online submissions for Combine Two Tables.
             */
            // SELECT FirstName, LastName, City, State from Person left JOIN Address on Person.PersonId = Address.PersonId;

            /*
             * Runtime: 204 ms, faster than 80.13% of MySQL online submissions for Combine Two Tables.
             */
            // SELECT FirstName, LastName, City, State from Person a left JOIN Address b on a.PersonId = b.PersonId;
        }
    }

    // 176. Second Highest Salary (SQL)   
    public class Problem176 : IProblem
    {
        /*
       * Write a SQL query to get the second highest salary from the Employee table.
       * 
       * +----+--------+
       * | Id | Salary |
       * +----+--------+
       * | 1  | 100    |
       * | 2  | 200    |
       * | 3  | 300    |
       * +----+--------+
       * For example, given the above Employee table, the query should return 200 as the second highest salary. If there is no second highest salary, then the query should return null.
       * 
       * +---------------------+
       * | SecondHighestSalary |
       * +---------------------+
       * | 200                 |
       * +---------------------+
       */
        public void run()
        {
            /*
             * Runtime: 130 ms, faster than 70.11% of MySQL online submissions for Second Highest Salary.
             */
            // select MAX(Salary ) as SecondHighestSalary  from Employee where Salary  <> (SELECT MAX(Salary ) from Employee) ;
        }
    }

    // 189. Rotate Array    
    public class Problem189 : IProblem
    {
        /*
         * Given an array, rotate the array to the right by k steps, where k is non-negative.
         */
        public void run()
        {
            var nums = new[] { 1, 2 };
            Rotate(nums, 1);
        }

        /*
         * Runtime: 248 ms, faster than 100.00% of C# online submissions for Rotate Array.
         * Memory Usage: 30.6 MB, less than 25.00% of C# online submissions for Rotate Array.
         */
        public void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            Reverse(ref nums, 0, nums.Length - 1);
            Reverse(ref nums, 0, k - 1);
            Reverse(ref nums, k, nums.Length - 1);
        }

        public void Reverse(ref int[] nums, int start, int stop)
        {
            while (start < stop)
            {
                var temp = nums[start];
                nums[start] = nums[stop];
                nums[stop] = temp;
                start++;
                stop--;
            }
        }
    }

    // 190. Reverse Bits
    public class Problem190 : IProblem
    {
        /*
         * Reverse bits of a given 32 bits unsigned integer.
         */
        public void run()
        {
            Console.WriteLine(reverseBits(4294967293));
        }

        /*
         * Runtime: 40 ms, faster than 100.00% of C# online submissions for Reverse Bits.
         * Memory Usage: 13.1 MB, less than 96.00% of C# online submissions for Reverse Bits.
         */
        public uint reverseBits(uint n)
        {
            uint sum = 0;
            for (int i = 0; i <= 31; i++)
            {
                sum += ((n >> i) & 0x01) << (31 - i);
            }

            return sum;
        }
    }

    // 191. Number of 1 Bits
    public class Problem191 : IProblem
    {
        /*
         * Write a function that takes an unsigned integer and return the number of '1' bits it has (also known as the Hamming weight).
         */
        public void run()
        {
            Console.WriteLine(HammingWeight(13));
        }
        /*
         * Runtime: 36 ms, faster than 100.00% of C# online submissions for Number of 1 Bits.
         * Memory Usage: 12.8 MB, less than 87.50% of C# online submissions for Number of 1 Bits.
         */
        public int HammingWeight(uint n)
        {
            int cnt = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((n & 0x0001) == 1) cnt++;
                n = n >> 1;
            }
            return cnt;
        }
    }

    // 193. Valid Phone Numbers (bash) todo
    public class Problem193 : IProblem
    {
        /*
         * Given a text file file.txt that contains list of phone numbers (one per line), write a one liner bash script to print all valid phone numbers.
         *
         * You may assume that a valid phone number must appear in one of the following two formats: (xxx) xxx-xxxx or xxx-xxx-xxxx. (x means a digit)
         *
         * You may also assume each line in the text file must not contain leading or trailing white spaces.
         */
        public void run()
        {

        }
    }

    // 198. House Robber
    public class Problem198 : IProblem
    {
        /*
         * You are a professional robber planning to rob houses along a street.
         * Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
         *
         * Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
         */
        public static Dictionary<int, int> stored = new Dictionary<int, int>();
        public void run()
        {
            //var nums = new[] { 114, 117, 207, 117, 235, 82, 90, 67, 143, 146, 53, 108, 200, 91, 80, 223, 58, 170, 110, 236, 81, 90, 222, 160, 165, 195, 187, 199, 114, 235, 197, 187, 69, 129, 64, 214, 228, 78, 188, 67, 205, 94, 205, 169, 241, 202, 144, 240 };
            var nums = new[] { 2, 7, 9, 3, 1 };
            Console.WriteLine(Rob(nums));
        }
        public int Rob(int[] nums)
        {
            return RobSub(nums, nums.Length - 1);
        }

        public int RobSub(int[] nums, int k)
        {
            if (k < 0)
            {
                return 0;
            }
            if (stored.ContainsKey(k))
            {
                return stored[k];
            }
            int value = Math.Max(RobSub(nums, k - 2) + nums[k], RobSub(nums, k - 1));
            Console.WriteLine($"k:{k}, value:{value}");
            stored.Add(k, value);

            return value;
        }
    }
}

