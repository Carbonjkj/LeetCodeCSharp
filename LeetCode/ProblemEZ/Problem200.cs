using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Objects;

namespace LeetCode.ProblemEZ
{
    // 202. Happy Number
    public class Problem202 : IProblem
    {

        /*
         * Write an algorithm to determine if a number is "happy".

A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.
         */
        public void run()
        {
            Console.WriteLine(IsHappy((8)));
        }

        /*
         * Runtime: 52 ms, faster than 33.65% of C# online submissions for Happy Number.
         * Memory Usage: 12.8 MB, less than 93.55% of C# online submissions for Happy Number.
         */
        // todo: Optimize
        public bool IsHappy(int n)
        {
            if (n == 1) return true;
            if (n == 4) return false;
            int sum = 0;
            while (n > 0)
            {
                int p = n % 10;
                sum += p * p;
                n = n / 10;
            }
            return IsHappy(sum);
        }


    }

    // 203. Remove Linked List Elements
    public class Problem203 : IProblem
    {
        /*
         * Remove all elements from a linked list of integers that have value val.
         */
        public void run()
        {
            RemoveElements(new ListNode(2), 3);
        }

        /*
         * Runtime: 116 ms, faster than 86.60% of C# online submissions for Remove Linked List Elements.
         * Memory Usage: 26 MB, less than 80.00% of C# online submissions for Remove Linked List Elements.
         */
        public ListNode RemoveElements(ListNode head, int val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }

            var start = head;
            while (head != null)
            {
                var temp = head.next;
                while (temp != null && temp.val == val)
                {
                    temp = temp.next;
                }

                head.next = temp;
                head = head.next;
            }
            return start;
        }

    }

    // 204. Count Primes
    public class Problem204 : IProblem
    {
        /*
         * Count the number of prime numbers less than a non-negative number, n. 
         */
        public List<int> primes = new List<int>();
        public void run()
        {
            Console.WriteLine(CountPrimeV2(100));
        }

        /*
         * Runtime: 436 ms, faster than 26.32% of C# online submissions for Count Primes.
         * Memory Usage: 14.8 MB, less than 73.81% of C# online submissions for Count Primes.
         */
        public int CountPrimes(int n)
        {
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                cnt += (IsPrime(i) ? 1 : 0);
            }
            return cnt;

            /*StackOverFlow*/
            //if (n < 2) return 0;
            //if (stored.ContainsKey(n)) return stored[n];
            //int cnt = CountPrimes(n - 1) + (IsPrime(n) ? 1 : 0);
            //stored.Add(n, cnt);
            //return cnt;
        }
        public bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n < 4)
            {
                primes.Add(n);
                return true;
            }
            for (int i = 0; primes[i] <= Math.Sqrt(n); i++)
            {
                if (n % primes[i] == 0)
                {
                    return false;
                }
            }
            primes.Add(n);
            return true;
        }

        /*Runtime: 92 ms, faster than 50.69% of C# online submissions for Count Primes.
         Memory Usage: 15 MB, less than 26.19% of C# online submissions for Count Primes.*/
        public int CountPrimeV2(int n)
        {
            if (n < 2) return 0;
            bool[] notPrime = new bool[n + 1];

            for (int i = 2; i * i < n; i++)
            {
                for (int j = 2; i * j < n; j++)
                {
                    notPrime[i * j] = true;
                }
            }

            int cnt = 0;
            for (int i = 2; i < n; i++)
            {
                if (!notPrime[i]) cnt++;
            }

            return cnt;
        }


    }

    // 205. Isomorphic Strings
    public class Problem205 : IProblem
    {
        /*
         * Given two strings s and t, determine if they are isomorphic.
         *
         * Two strings are isomorphic if the characters in s can be replaced to get t.
         *
         * All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character but a character may map to itself.
         */
        public void run()
        {
            Console.WriteLine(IsIsomorphic("title", "paper"));
        }

        /*
         * Runtime: 72 ms, faster than 100.00% of C# online submissions for Isomorphic Strings.
         * Memory Usage: 21 MB, less than 100.00% of C# online submissions for Isomorphic Strings.
         */
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int[] ms = new int[256];
            int[] mt = new int[256];

            for (int i = 0; i < s.Length; i++)
            {
                if (ms[s[i]] == 0) ms[s[i]] = i + 1;
                if (mt[t[i]] == 0) mt[t[i]] = i + 1;
                if (ms[s[i]] != mt[t[i]])
                {
                    return false;
                }
            }

            return true;

        }
    }

    // 206. Reverse Linked List
    public class Problem206 : IProblem
    {
        /*
         * Reverse a singly linked list.
         */
        public void run()
        {

        }
        /*
         * Runtime: 92 ms, faster than 96.78% of C# online submissions for Reverse Linked List.
         * Memory Usage: 22.1 MB, less than 85.26% of C# online submissions for Reverse Linked List.
         */
        public ListNode ReverseList(ListNode head)
        {
            // no need to reverse conditions
            if (head == null || head.next == null) return head;
            // get the next
            var realHead = head.next;
            // save the current head
            var parent = head;
            // cut the first link
            head.next = null;
            while (realHead.next != null)
            {
                var tmp = realHead;
                realHead = realHead.next;
                tmp.next = parent;
                parent = tmp;
            }
            realHead.next = parent;
            return realHead;
        }
    }

    // 217. Contains Duplicate
    public class Problem217 : IProblem

    {
        /*
         * Given an array of integers, find if the array contains any duplicates.
         *
         * Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.
         */
        public void run()
        {
            var nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 2 };
            Console.WriteLine(ContainsDuplicate(nums));
        }

        /*
         * Runtime: 108 ms, faster than 100.00% of C# online submissions for Contains Duplicate.
         * Memory Usage: 29.6 MB, less than 27.12% of C# online submissions for Contains Duplicate.
         */
        public bool ContainsDuplicate(int[] nums)
        {
            // Seems no better idea than sort O(nlogn) mem(1), or using set O(n) mem:O(n)
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!set.Add(nums[i])) return true;
            }
            return false;
        }
    }

    // 219. Contains Duplicate II
    public class Problem219 : IProblem
    {
        /*
         * Given an array of integers and an integer k, find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the absolute difference between i and j is at most k.
         */
        public void run()
        {
            Console.WriteLine(ContainsNearbyDuplicate(new int[] { 1, 0, 1, 1 }, 1));
        }

        /*
         * Runtime: 132 ms, faster than 41.77% of C# online submissions for Contains Duplicate II.
         * Memory Usage: 33.8 MB, less than 6.25% of C# online submissions for Contains Duplicate II.
         */
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++) // O(n)
            {
                if (!dict.ContainsKey(nums[i])) dict.Add(nums[i], new List<int>() { i });
                else dict[nums[i]].Add(i);
            }
            foreach (var dictKey in dict.Keys)
            {
                if (dict[dictKey].Count > 1)
                {
                    int min = k + 1;
                    for (int i = 1; i < dict[dictKey].Count; i++)
                    {
                        min = Math.Min(min, dict[dictKey][i] - dict[dictKey][i - 1]);
                    }

                    if (min <= k) return true;
                }
            }
            return false;
        }

        /*
         * Runtime: 104 ms, faster than 99.58% of C# online submissions for Contains Duplicate II.
         * Memory Usage: 25.6 MB, less than 87.50% of C# online submissions for Contains Duplicate II.
         */
        public bool ContainsNearbyDuplicateV2(int[] nums, int k)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > k) set.Remove(nums[i - k - 1]);
                if (!set.Add(nums[i])) return true;
            }
            return false;
        }

    }

    // 225. Implement Stack using Queues
    public class Problem225 : IProblem
    {
        /*
         * Implement the following operations of a stack using queues.
         *
         * push(x) -- Push element x onto stack.
         * pop() -- Removes the element on top of the stack.
         * top() -- Get the top element.
         * empty() -- Return whether the stack is empty.
         *
         * Notes:
         *
         * You must use only standard operations of a queue -- which means only push to back, peek/pop from front, size, and is empty operations are valid.
         * Depending on your language, queue may not be supported natively. You may simulate a queue by using a list or deque (double-ended queue), as long as you use only standard operations of a queue.
         * You may assume that all operations are valid (for example, no pop or top operations will be called on an empty stack).
         */
        public void run()
        {

        }
        /*
         * Runtime: 104 ms, faster than 100.00% of C# online submissions for Implement Stack using Queues.
         * emory Usage: 22.1 MB, less than 61.29% of C# online submissions for Implement Stack using Queues.
         */
        public class MyStack
        {

            private Queue<int> queue = new Queue<int>();
            /** Initialize your data structure here. */
            public MyStack()
            {

            }

            /** Push element x onto stack. */
            // push the element to the first in queue
            // Rest operation just like a queue
            public void Push(int x)
            {
                var temp = new Queue<int>();
                while (queue.Count > 0)
                {
                    temp.Enqueue(queue.Dequeue());
                }
                queue.Enqueue(x);
                while (temp.Count > 0)
                {
                    queue.Enqueue(temp.Dequeue());
                }
            }

            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                return queue.Dequeue();
            }

            /** Get the top element. */
            public int Top()
            {
                return queue.Peek();
            }

            /** Returns whether the stack is empty. */
            public bool Empty()
            {
                return queue.Count == 0;
            }
        }
    }

    // 226. Invert Binary Tree
    public class Problem226 : IProblem
    {
        /*
         * Invert a binary tree.(Mirror Invert)
         */
        public void run()
        {
            InvertTree(new TreeNode(0));
        }

        /*
         * Runtime: 92 ms, faster than 98.64% of C# online submissions for Invert Binary Tree.
         * emory Usage: 22 MB, less than 53.33% of C# online submissions for Invert Binary Tree.
         */
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;
            var left = InvertTree(root.right);
            var right = InvertTree(root.left);
            root.left = left;
            root.right = right;
            return root;
        }

    }

    // 231. Power of Two
    public class Problem231 : IProblem
    {
        /*
         * Given an integer, write a function to determine if it is a power of two.
         */
        public void run()
        {
            for (int i = 0; i < 9000; i++)
            {
                if (IsPowerOfTwo(i))
                    Console.WriteLine(i);
            }
        }
        /*
         * Runtime: 40 ms, faster than 100.00% of C# online submissions for Power of Two.
         * Memory Usage: 13 MB, less than 65.22% of C# online submissions for Power of Two.
         */
        public bool IsPowerOfTwo(int n)
        {
            if (n == 0) return false;
            if (n == 2 || n == 1) return true;
            if (n % 2 != 0) return false;
            return IsPowerOfTwo(n / 2);
        }
    }

    // 232. Implement Queue using Stacks
    public class Problem232 : IProblem
    {

        /*
         * Implement the following operations of a queue using stacks.
         *
         * push(x) -- Push element x to the back of queue.
         * pop() -- Removes the element from in front of queue.
         * peek() -- Get the front element.
         * empty() -- Return whether the queue is empty.
         *
         * You must use only standard operations of a stack -- which means only push to top, peek/pop from top, size, and is empty operations are valid.
         * Depending on your language, stack may not be supported natively. You may simulate a stack by using a list or deque (double-ended queue), as long as you use only standard operations of a stack.
         * You may assume that all operations are valid (for example, no pop or peek operations will be called on an empty queue).
         */
        public void run()
        {

        }
        /*
         * Runtime: 104 ms, faster than 98.94% of C# online submissions for Implement Queue using Stacks.
         * Memory Usage: 22 MB, less than 75.00% of C# online submissions for Implement Queue using Stacks.
         */
        public class MyQueue
        {
            Stack<int> stack = new Stack<int>();
            /** Initialize your data structure here. */
            public MyQueue()
            {

            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                var temp = new Stack<int>();
                while (stack.Count > 0)
                {
                    temp.Push(stack.Pop());
                }
                stack.Push(x);
                while (temp.Count > 0)
                {
                    stack.Push(temp.Pop());
                }

            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                return stack.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                return stack.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return stack.Count == 0;
            }
        }
    }

    // 234. Palindrome Linked List
    public class Problem234 : IProblem
    {
        /*
         * Given a singly linked list, determine if it is a palindrome.  time O(n) memory O(1);
         */
        public void run()
        {
            Console.WriteLine(IsPalindrome(new ListNode(0)));
        }

        /*
         * Runtime: 100 ms, faster than 99.78% of C# online submissions for Palindrome Linked List.
         * Memory Usage: 26 MB, less than 46.67% of C# online submissions for Palindrome Linked List.
         */
        public bool IsPalindrome(ListNode head)
        {
            // only need to reverse half of the list.
            // and check first half and the last half is same.
            if (head == null || head.next == null) return true;
            var fast = head;
            var slow = head;
            var sf = false;
            while (fast.next != null)
            {
                fast = fast.next;
                if (sf) slow = slow.next;
                sf = !sf;
            }

            slow = ReverseList(slow);
            while (slow.next != null)
            {
                if (slow.val != head.val) return false;
                slow = slow.next;
                head = head.next;
            }
            return true;
        }

        // from problem 206;
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            var realHead = head.next;
            var parent = head;
            head.next = null;
            while (realHead.next != null)
            {
                var tmp = realHead;
                realHead = realHead.next;
                tmp.next = parent;
                parent = tmp;
            }
            realHead.next = parent;
            return realHead;
        }
    }

    // 235. Lowest Common Ancestor of a Binary Search Tree
    public class Problem235 : IProblem
    {
        /*
         * Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST.
         *
         * According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”
         *
         * Given binary search tree:  root = [6,2,8,0,4,7,9,null,null,3,5]
         *
         * Note:
         *
         * All of the nodes' values will be unique.
         * p and q are different and both values will exist in the BST.
         */
        public void run()
        {

        }
        /*
         * Runtime: 112 ms, faster than 99.76% of C# online submissions for Lowest Common Ancestor of a Binary Search Tree.
         * Memory Usage: 29.9 MB, less than 13.51% of C# online submissions for Lowest Common Ancestor of a Binary Search Tree.
         */
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // lowest ancestor must has p and q on each side.
            if (root == null || p == null || q == null) return null;
            TreeNode larger = p.val > q.val ? p : q;
            TreeNode smaller = p.val > q.val ? q : p;

            if (smaller.val > root.val)
            {
                return LowestCommonAncestor(root.right, p, q);
            }
            if (larger.val < root.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            return root;
        }
    }
}
