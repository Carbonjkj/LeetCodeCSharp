using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
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

    // 237. Delete Node in a Linked List
    public class Problem237 : IProblem
    {
        /*
         * Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.
         *
         * Given linked list -- head = [4,5,1,9], which looks like following:
         */
        public void run()
        {

        }
        /*
         *
         * Runtime: 92 ms, faster than 100.00% of C# online submissions for Delete Node in a Linked List.
         * Memory Usage: 23.2 MB, less than 50.00% of C# online submissions for Delete Node in a Linked List.
         */
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }

    // 242. Valid Anagram
    public class Problem242 : IProblem
    {
        /*
         * Given two strings s and t , write a function to determine if t is an anagram of s.
         * Note:
         * You may assume the string contains only lowercase alphabets.
         *
         * Follow up:
         * What if the inputs contain unicode characters? How would you adapt your solution to such case?
         */
        public void run()
        {
            Console.WriteLine(IsAnagram("anagram", "nagaram"));
        }

        /*
         * Runtime: 76 ms, faster than 97.84% of C# online submissions for Valid Anagram.
         * Memory Usage: 21.8 MB, less than 38.98% of C# online submissions for Valid Anagram.
         */
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            var ascii = new char[256];
            for (int i = 0; i < s.Length; i++)
            {
                ascii[s[i]]++;
                ascii[t[i]]--;
            }

            for (int i = 0; i < 256; i++)
            {
                if (ascii[i] != 0) return false;
            }

            return true;
        }
    }

    // 257. Binary Tree Paths
    public class Problem257 : IProblem
    {
        /*
         * Given a binary tree, return all root-to-leaf paths.
         *
         * Note: A leaf is a node with no children.
         */
        public void run()
        {
            Console.WriteLine(string.Join("\n", BinaryTreePaths(new TreeNode(0))));
        }
        /*
         * Runtime: 260 ms, faster than 95.36% of C# online submissions for Binary Tree Paths.
         * Memory Usage: 29.8 MB, less than 53.57% of C# online submissions for Binary Tree Paths.
         */
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var list = new List<string>();
            if (root == null) return list;
            if (root.left == null && root.right == null)
            {
                list.Add(root.val.ToString());
                return list;
            }
            BinaryTreePaths(ref list, "", root);
            return list;
        }
        public void BinaryTreePaths(ref List<string> list, string str, TreeNode root)
        {
            if (root == null) return;
            if (root.left == null && root.right == null)
            {
                list.Add(str += root.val);
                return;
            }
            BinaryTreePaths(ref list, str + root.val + "->", root.left);
            BinaryTreePaths(ref list, str + root.val + "->", root.right);
        }
    }

    // 258. Add Digits
    public class Problem258 : IProblem
    {
        /*
         * Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.
         */
        public void run()
        {
            Console.WriteLine(AddDigits(1654983516));

        }
        /*
         * Runtime: 40 ms, faster than 100.00% of C# online submissions for Add Digits.
         * Memory Usage: 12.9 MB, less than 38.46% of C# online submissions for Add Digits.
         */
        public int AddDigits(int num)
        {
            if (num < 10) return num;
            int n = 0;
            while (num > 0)
            {
                n += num % 10;
                num = num / 10;
            }
            return AddDigits(n);
        }
    }

    //263. Ugly Number
    public class Problem263 : IProblem
    {
        /*
         * Write a program to check whether a given number is an ugly number.
         *
         * Ugly numbers are positive numbers whose prime factors only include 2, 3, 5.
         *
         * Note:
         *
         * 1 is typically treated as an ugly number.
         * Input is within the 32-bit signed integer range: [−231,  231 − 1].
         */
        public void run()
        {
            Console.WriteLine(IsUgly(-2147483648));
        }
        /*
         * Runtime: 48 ms, faster than 72.41% of C# online submissions for Ugly Number.
         * Memory Usage: 12.9 MB, less than 88.89% of C# online submissions for Ugly Number.
         */

        public bool IsUgly(int num)
        {
            if (num == 0) return false;
            if (num == 1) return true;
            if (num % 2 == 0)
            {
                num /= 2;
                return IsUgly(num);
            }

            if (num % 3 == 0)
            {
                num /= 3;
                return IsUgly(num);
            }

            if (num % 5 == 0)
            {
                num /= 5;
                return IsUgly(num);
            }

            return num == 1;
        }
    }

    // 268. Missing Number
    public class Problem268 : IProblem
    {
        /*
         * Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.
         * Note:
         * Your algorithm should run in linear runtime complexity. Could you implement it using only constant extra space complexity?
         */
        public void run()
        {

        }
        /*
         * Runtime: 112 ms, faster than 91.00% of C# online submissions for Missing Number.
         * Memory Usage: 27.4 MB, less than 51.79% of C# online submissions for Missing Number.
         */
        public int MissingNumber(int[] nums)
        {
            int min = nums.Min();
            int max = nums.Max();
            if (min != 0) return 0; // for case [1];
            int i = (max + min) * (max - min + 1) / 2 - nums.Sum();
            if (i == 0) return max + 1; // for case[0];
            return i;
        }
    }

    // 278. First Bad Version   
    public class Problem278 : IProblem
    {
        /*
         * You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.
         *
         * Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
         *
         * You are given an API bool isBadVersion(version) which will return whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.
         */
        public void run()
        {
            Console.WriteLine(FirstBadVersion(2126753390));
        }
        /*
         * Runtime: 36 ms, faster than 100.00% of C# online submissions for First Bad Version.
         * Memory Usage: 12.9 MB, less than 8.33% of C# online submissions for First Bad Version.
         */
        public int FirstBadVersion(int n)
        {
            int k = 0;
            while (n - k > 1)
            {
                int check = (int)(((long)k + n) / 2);
                Console.WriteLine($"n: {n}, k:{k}, Check {check}");
                if (IsBadVersion(check))
                {
                    n = check;
                }
                else
                {
                    k = check;
                }
                Console.WriteLine($"n: {n}, k:{k}");
            }
            return n;
        }


        bool IsBadVersion(int version)
        {
            return version >= 1702766719;
        }
    }

    // 283. Move Zeroes
    public class Problem283 : IProblem
    {
        /*
         * Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
         *
         * Example:
         *
         * Input: [0,1,0,3,12]
         * Output: [1,3,12,0,0]
         *
         * Note:
         *
         * You must do this in-place without making a copy of the array.
         * Minimize the total number of operations.
         */
        public void run()
        {
            MoveZeroes(new[] { 1, 0 });
        }
        /*
         * Runtime: 336 ms, faster than 15.74% of C# online submissions for Move Zeroes.
         * Memory Usage: 30 MB, less than 66.96% of C# online submissions for Move Zeroes.
         */
        public void MoveZeroes(int[] nums)
        {
            int nzero = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    if (nzero == 0) nzero = i + 1;
                    if (nzero >= nums.Length) return;
                    for (int j = nzero; j < nums.Length; j++)
                    {
                        if (nums[j] != 0)
                        {
                            nums[i] = nums[j];
                            nums[j] = 0;
                            nzero = j + 1;
                            break;
                        }
                    }
                }
            }
        }

        /*
         * Runtime: 304 ms, faster than 42.29% of C# online submissions for Move Zeroes.
         * Memory Usage: 29.9 MB, less than 90.43% of C# online submissions for Move Zeroes.
         */
        public void MoveZeroesV2(int[] nums)
        {
            int nzero = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0) nums[nzero++] = nums[i];
            }
            while (nzero < nums.Length)
            {
                nums[nzero++] = 0;
            }
        }
    }

    // 290. Word Pattern
    public class Problem290 : IProblem
    {
        /*
         * Given a pattern and a string str, find if str follows the same pattern.
         *
         * Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.
         *
         * Notes:
         * You may assume pattern contains only lowercase letters, and str contains lowercase letters separated by a single space.
         */
        public void run()
        {
            Console.WriteLine(WordPattern("abba", "dog cat cat dog"));
        }

        /*
         * Runtime: 96 ms, faster than 34.04% of C# online submissions for Word Pattern.
         * Memory Usage: 20 MB, less than 10.00% of C# online submissions for Word Pattern.
         */
        public bool WordPattern(string pattern, string str)
        {
            Dictionary<char, string> dict = new Dictionary<char, string>();
            var strs = str.Split(' ');
            if (pattern.Length != strs.Length) return false;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (!dict.ContainsKey(pattern[i]))
                {
                    dict.Add(pattern[i], strs[i]);
                }
                else
                {
                    if (!dict[pattern[i]].Equals(strs[i])) return false;
                }
            }
            var set = new HashSet<string>();
            foreach (var dictKey in dict.Keys)
            {
                if (!set.Add(dict[dictKey])) return false;
            }
            return true;
        }
        // todo:
        public bool WordPatternV2(string pattern, string str)
        {
            return false;
        }

    }

    // 292. Nim Game
    public class Problem292 : IProblem
    {

        /*
         * You are playing the following Nim Game with your friend: There is a heap of stones on the table, each time one of you take turns to remove 1 to 3 stones. The one who removes the last stone will be the winner. You will take the first turn to remove the stones.
         *
         * Both of you are very clever and have optimal strategies for the game. Write a function to determine whether you can win the game given the number of stones in the heap.
         */
        public void run()
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine($"i = {i}, {CanWinNim(i)}");
            }
        }

        public bool CanWinNim(int n)
        {
            return CanWinNimSub(n, 1);
        }
        /*
         * Runtime: 36 ms, faster than 100.00% of C# online submissions for Nim Game.
         * Memory Usage: 12.8 MB, less than 75.00% of C# online submissions for Nim Game.
         */
        public bool CanWinNimSub(int n, int count)
        {
            if (n == 1) return count % 2 == 1;
            if (n % 4 == 0) return count % 2 == 0;
            if (n % 4 == 3) return CanWinNimSub(n - 3, ++count);
            if (n % 4 == 2) return CanWinNimSub(n - 2, ++count);
            return CanWinNimSub(n - 1, ++count);
        }

        /*
         * Runtime: 48 ms, faster than 16.84% of C# online submissions for Nim Game.
         * Memory Usage: 12.8 MB, less than 50.00% of C# online submissions for Nim Game.
         */
        public bool CanWinNimV2(int n)
        {
            return n % 4 != 0;
        }
    }
}
