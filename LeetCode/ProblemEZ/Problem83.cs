using ConsoleApp4.Objects;

namespace LeetCode.ProblemEZ
{
    public class Problem83 : IProblem
    {
        /*
         * Given a sorted linked list, delete all duplicates such that each element appear only once.
         */
        public void run()
        {
            var head = new ListNode(1);
            DeleteDuplicates(head);
        }

        /*
         * Runtime: 92 ms, faster than 100.00% of C# online submissions for Remove Duplicates from Sorted List.
         * Memory Usage: 23.9 MB, less than 13.95% of C# online submissions for Remove Duplicates from Sorted List.
         */
        public ListNode DeleteDuplicates(ListNode head)
        {
            var saveHead = head;
            while (head.next != null)
            {
                if (head.val == head.next.val)
                {
                    head.next = head.next.next;
                }
                else
                {
                    head = head.next;
                }
            }

            return saveHead;
        }
    }
}
