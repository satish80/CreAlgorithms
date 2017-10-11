using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class SLL
    {
        public void ReverseSLL()
        {
            SLLNode head = new SLLNode(2);
            head.Next = new SLLNode(4);
            head.Next.Next = new SLLNode(7);
            head.Next.Next.Next = new SLLNode(1);
            head.Next.Next.Next.Next = new SLLNode(8);
            head.Next.Next.Next.Next.Next = new SLLNode(12);
            head.Next.Next.Next.Next.Next.Next = new SLLNode(16);
            head.Next.Next.Next.Next.Next.Next.Next = null;


            //SLLNode reversedHead = Reverse(head);
            SLLNode reverse = ReverseIt(head);
            //Console.Write
        }

        private SLLNode Reverse(SLLNode head)
        {
            SLLNode prev = null;
            
            while(head != null)
            {
                SLLNode temp = head.Next;
                head.Next = prev;
                prev = head;
                head = temp;
            }
            return prev;
        }

        private SLLNode ReverseIt(SLLNode head)
        {
            SLLNode Current = head;
            SLLNode Next = Current.Next;
            SLLNode Prev = null;

            while(Current != null)
            {
                Next = Current.Next;
                Current.Next = Prev;
                Prev = Current;
                Current = Next;
            }

            return Prev;
        }

        public void ReverseKNodes()
        {
            SLLNode head = new SLLNode(1);
            head.Next = new SLLNode(2);
            head.Next.Next = new SLLNode(3);
            head.Next.Next.Next = new SLLNode(4);
            head.Next.Next.Next.Next = new SLLNode(5);
            head.Next.Next.Next.Next.Next = new SLLNode(6);
            head.Next.Next.Next.Next.Next.Next = new SLLNode(7);
            head.Next.Next.Next.Next.Next.Next.Next = null;

            ReverseKNodesUtil(head, 3);

        }

        private SLLNode ReverseKNodesUtil(SLLNode head, int k)
        {
            SLLNode Current = head;
            SLLNode prev = head;
            SLLNode current = head.Next;
            SLLNode next = current.Next;
            SLLNode temp = prev;

            while (current.Next != null && k > 1)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
                k--;
            }
            temp.Next = next;
            return prev;
        }

        public void IsPalindrome()
        {
            SLLNode head = new SLLNode(1);
            head.Next = new SLLNode(2);
            head.Next.Next = new SLLNode(3);
            head.Next.Next.Next = new SLLNode(2);
            head.Next.Next.Next.Next = new SLLNode(1);

            Console.WriteLine(IsPalindromeUtil(head));
        }

        private bool IsPalindromeUtil(SLLNode node)
        {
            if(node == null)
            {
                return false;
            }

            SLLNode slow = node;
            SLLNode fast = node;

            while(fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            SLLNode reversedNode = ReverseNodes(slow);
            
            while(reversedNode != null)
            {
                if (node.Value != reversedNode.Value)
                {
                    return false;
                }
                node = node.Next;
                reversedNode = reversedNode.Next;
            }
            return true;
        }

        private SLLNode ReverseNodes(SLLNode node)
        {
            SLLNode prev = null;
            SLLNode cur = node;
            SLLNode next = node.Next;

            while(next != null)
            {
                next = cur.Next;
                cur.Next = prev;
                prev = cur;
                cur = next;
            }

            return prev;
        }

        public void LengthOfLoop()
        {
            SLLNode head = new SLLNode(1);
            head.Next = new SLLNode(2);
            head.Next.Next = new SLLNode(3);
            head.Next.Next.Next = new SLLNode(4);
            head.Next.Next.Next.Next = new SLLNode(5);
            head.Next.Next.Next.Next.Next = head.Next;

            Console.WriteLine(LengthOfLoop(head));
        }

        private int LengthOfLoop(SLLNode head)
        {
            int length = 0;

            if(head == null)
            {
                return length;
            }

            SLLNode slow = head.Next;
            SLLNode fast = null;
            SLLNode loopNode = null;
            SLLNode curNode = null;

            if(slow != null)
            {
                fast = slow.Next;
            }


            while(fast.Next != null)
            {
                if(slow == fast)
                {
                    loopNode = slow;
                    break;
                }
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            curNode = loopNode.Next;

            while(curNode != loopNode)
            {
                length++;
                curNode = curNode.Next;
            }

            return length +1;
        }

        public void Clone()
        {
            SLLNodeRandom head = new SLLNodeRandom(1);
            SLLNodeRandom node2 = new SLLNodeRandom(2);
            SLLNodeRandom node3 = new SLLNodeRandom(3);
            SLLNodeRandom node4 = new SLLNodeRandom(4);

            head.Next = node2;
            head.Random = node3;
            node2.Next = node3;
            node2.Random = node4;
            node3.Next = node4;
            node3.Random = node3;
            node4.Next = null;
            node4.Random = null;

            SLLNodeRandom node = Clone(head);
        }

        private SLLNodeRandom Clone(SLLNodeRandom head)
        {
            Dictionary<SLLNodeRandom, SLLNodeRandom> map = new Dictionary<SLLNodeRandom, SLLNodeRandom>();
            SLLNodeRandom current = head;
            SLLNodeRandom cloneHead = null;

            while (current != null)
            {
                SLLNodeRandom cloneNode = new SLLNodeRandom(current.Value);

                if(cloneHead == null)
                {
                    cloneHead = cloneNode;
                }

                map.Add(current, cloneNode);
                current = current.Next;
            }

            while(head!= null)
            {
                if (head.Next != null)
                {
                    map[head].Next = map[head.Next];
                }
                if (head.Random != null)
                {
                    map[head].Random = map[head.Random];
                }

                head = head.Next;
            }

            return cloneHead;
        }

        public void ReverseKnodes()
        {
            SLLNode head = new SLLNode(1);
            SLLNode node2 = new SLLNode(2);
            SLLNode node3 = new SLLNode(3);
            SLLNode node4 = new SLLNode(4);
            SLLNode node5 = new SLLNode(5);
            SLLNode node6 = new SLLNode(6);
            SLLNode node7 = new SLLNode(7);
            SLLNode node8 = new SLLNode(8);
            SLLNode node9 = new SLLNode(9);
            head.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;
            node7.Next = node8;
            node8.Next = node9;
            node9.Next = null;

            SLLNode newNode = ReverseKNodes(head, 3);
        }

        private SLLNode ReverseKNodes(SLLNode node, int k)
        {
            if(node == null || node.Next == null)
            {
                return node;
            }

            return ReverseNodes(ref node, k);
        }

        private SLLNode ReverseNodes(ref SLLNode head, int k)
        {
            SLLNode prev = null;
            SLLNode current = head;
            SLLNode next = null;

            int count = 0;

            while (current != null && count < k)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;

                count++;
            }

            if (current != null)
            {
                head.Next = ReverseNodes(ref current, k);
            }

            return prev;
        }

        public void FindKthNodeFromLast()
        {
            SLLNode node = new SLLNode(1);
            node.Next = new SLLNode(2);
            node.Next.Next = new SLLNode(3);
            node.Next.Next.Next = new SLLNode(4);
            node.Next.Next.Next.Next = new SLLNode(5);
            node.Next.Next.Next.Next.Next = new SLLNode(6);
            node.Next.Next.Next.Next.Next.Next = new SLLNode(7);

            Console.WriteLine(FindKthNodeFromLast(node, 3));
        }

        private int FindKthNodeFromLast(SLLNode node, int k)
        {
            if(node == null)
            {
                return 0;
            }

            if(node.Next == null)
            {
                if(k == 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                int length = FindListLength(node);
                int count = 0;

                while(count < length -k)
                {
                    node = node.Next;
                    count++;
                }

                return node.Value;
            }
        }

        private int FindListLength(SLLNode node)
        {
            SLLNode slow = node;
            SLLNode fast = node.Next.Next;
            int length = 1;

            while(fast != null)
            {
                slow = slow.Next;
                if(fast.Next != null)
                {
                    fast = fast.Next.Next;
                }
                else
                {
                    break;
                }
                length++;
            }

            if(fast == null)
            {
                return length * 2;
            }
            else
            {
                return length * 2 + 1;
            }
        }
    }

    public class SLLNodeRandom
    {
        public SLLNodeRandom Next;
        public SLLNodeRandom Random;
        public int Value;

        public SLLNodeRandom(int Value)
        {
            this.Value = Value;
        }
    }

    public class SLLNode
    {
        public SLLNode Next;
        public int Value;

        public SLLNode(int Value)
        {
            this.Value = Value;
        }
    }
}
