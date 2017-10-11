using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class Trees
    {
        public Node ConvertArray2BST(int[] arr)
        {
            var tree = Array2BST(arr, 0, 3);
            return tree;
        }

        private Node Array2BST(int[] arr, int start, int end)
        {
            Node tree = null;
            if(start > end)
            {
                return null;
            }
            else
            {
                int mid = (start + end) / 2;
                tree = new Node(arr[mid]);
                tree.Left = Array2BST(arr, start, mid - 1);
                tree.Right = Array2BST(arr, mid + 1, end);

                return tree;
            }
        }

        public void FindLCA()
        {
            Node node = new Node(1);
            node.Left = new Node(2);
            node.Right = new Node(3);
            node.Left.Left = new Node(4);
            node.Left.Right = new Node(5);
            node.Right.Left = new Node(6);
            node.Right.Right = new Node(7);
            node.Left.Left.Left = new Node(9);

            Node LCANode = LCA(node, 4, 9);
            Console.WriteLine(LCANode.Value);
        }

        public Node LCA(Node root, int num1, int num2)
        {
            if (root == null) return null;

            // If either num1 or num2 matches with root's key, report
            // the presence by returning root (Note that if a key is
            // ancestor of other, then the ancestor key becomes LCA
            if (root.Value == num1 || root.Value == num2)
                return root;

            // Look for keys in left and right subtrees
            Node left_lca = LCA(root.Left, num1, num2);
            Node right_lca = LCA(root.Right, num1, num2);

            // If both of the above calls return Non-NULL, then one key
            // is present in once subtree and other is present in other,
            // So this node is the LCA
            if (left_lca != null && right_lca != null) return root;

            // Otherwise check if left subtree or right subtree is LCA
            return (left_lca != null) ? left_lca : right_lca;
        }

        public LinkedListNode BinaryTreeToDLL()
        {
            Node node = new Node(10);
            node.Left = new Node(12);
            node.Right = new Node(15);
            node.Left.Left = new Node(25);
            node.Left.Right = new Node(30);
            node.Right.Left = new Node(36);

            LinkedListNode linkedListNode = null;
            BinaryTreeToDLL(node, ref linkedListNode);
            return linkedListNode;
        }

        private void BinaryTreeToDLL(Node root, ref LinkedListNode linkedListNode)
        {
            LinkedListNode temp = null;

            if (root == null)
            {
                return;
            }
            else
            {
                BinaryTreeToDLL(root.Left, ref linkedListNode);

                if (linkedListNode == null)
                {
                    linkedListNode = new LinkedListNode(root.Value);
                    linkedListNode.Prev = null;
                    temp = linkedListNode;
                }
                else
                {
                    temp = new LinkedListNode(root.Value);
                    temp.Prev = linkedListNode;
                    temp.Prev.Next = temp;
                    linkedListNode = temp;
                }

                BinaryTreeToDLL(root.Right, ref linkedListNode);

                return;
            }
        }

        public void ReturnHeadNodeOfTree()
        {
            Node leafNode = new Node(3)
            {
                Left = null,
                Right = null
            };

            Node leafNode2 = new Node(9)
            {
                Left = null,
                Right = null
            };

            Node leafNode3 = new Node(1)
            {
                Left = null,
                Right = null
            };

            Node leafNode4 = new Node(8)
            {
                Left = null,
                Right = null
            };


            Node parent1L1 = new Node(6)
            {
                Left = leafNode,
                Right = leafNode2
            };

            Node parent2L1 = new Node(2)
            {
                Left = leafNode3,
                Right = leafNode4
            };

            Node root = new Node(5)
            {
                Left = parent1L1,
                Right = parent2L1
            };

            Node someNode = new Node(8)
            {
                Left = null,
                Right = null
            };

            Node[] nodes = new Node[] {parent1L1, leafNode3, someNode, root, leafNode, leafNode2, parent2L1, leafNode4};
            Console.WriteLine(FindHeadNodeOfTree(nodes).Value);
        }

        private Node FindHeadNodeOfTree(Node[] nodes)
        {
            Dictionary<Tuple<int?, int?>, int> map = new Dictionary<Tuple<int?, int?>, int>();
            int idx = 0;
            Node cur = null;
            Node head = null;
            while(idx < nodes.Length -1)
            {
                cur = nodes[idx];

                if(map.Count ==0 && (cur.Left != null || cur.Right != null))
                {
                    Tuple<int?, int?> tuple = new Tuple<int?, int?>(cur.Left.Value, cur.Right.Value);
                    map.Add(tuple, cur.Value);
                }
                else
                {
                    if(cur.Left != null && cur.Right!= null)
                    {
                        if (map.ContainsValue(cur.Left.Value) || map.ContainsValue(cur.Right.Value))
                        {
                            head = cur;
                        }
                        else
                        {
                            var value = new Tuple<int?, int?>(cur.Left.Value, cur.Left.Value);
                            map.Add(value, cur.Value);
                        }
                    }
                    else if(cur.Left!= null)
                    {
                        if (map.ContainsValue(cur.Left.Value))
                        {
                            head = cur;
                        }
                        else
                        {
                            var value = new Tuple<int?,int?>(cur.Left.Value, cur.Left.Value);
                            map.Add(value, cur.Value);
                        }
                    }
                    else if(cur.Right != null)
                    
                        if (map.ContainsValue(cur.Right.Value))
                        {
                            head = cur;
                        }
                        else
                        {
                            var value = new Tuple<int?, int?>(cur.Left.Value, cur.Left.Value);
                            map.Add(value, cur.Value);
                        }
                
                }
                idx++;
            }
            return head;
        }

        public void DoesPathExists()
        {
            Node node = new Node(5);
            node.Left = new Node(3);
            node.Right = new Node(8);
            node.Left.Left = new Node(2);
            node.Left.Right = new Node(4);
            node.Right.Left = new Node(6);
            node.Left.Left.Left = new Node(1);
            node.Right.Left.Right = new Node(7);

            int[] arr = new int[4] { 5, 8, 6, 7 };

            Console.WriteLine("Path exists: {0}", IsPathExists(node, arr));
        }

        private bool IsPathExists(Node root, int[] arr)
        {
            if(arr.Length == 0 || root == null)
            {
                return false;
            }
            else
            {
                int idx = 0;
                int cur = arr[idx];
                if(cur != root.Value)
                {
                    return false;
                }
                
                while(root.Left != null || root.Right != null && (idx < arr.Length))
                {
                    cur = arr[++idx];
                    if (root.Left != null && root.Left.Value == cur)
                    {
                        root = root.Left;
                        
                    }
                    else if(root.Right!= null && root.Right.Value == cur)
                    {
                        root = root.Right;
                        
                    }
                    else
                    {
                        if (root.Left == null && root.Right == null && idx < arr.Length)
                        {
                            return false;
                        }
                        else if (root.Left == null && root.Right == null && idx == arr.Length)
                        {
                            return true;
                        }
                    }
                    
                }
                return true;
            }
        }

        public void FindPathForDesiredSum()
        {
            Node node = new Node(1);
            node.Left = new Node(3);
            node.Right = new Node(-1);
            node.Left.Left = new Node(2);
            node.Left.Right = new Node(1);
            node.Right.Left = new Node(4);
            node.Right.Right = new Node(5);
            node.Left.Right.Left = new Node(1);
            node.Right.Left.Left = new Node(1);
            node.Right.Left.Right = new Node(2);
            node.Right.Right.Right = new Node(6);
            int[] arr= new int[] { 1};
            FindPathforSum(node, 5, new List<int>());
        }

        private void FindPathforSum(Node root, int Sum, List<int> path)
        {
            if(root == null)
            {
                return;
            }
            else
            {
                path.Add(root.Value);
                //stk.Push(root.Value);
    
                FindPathforSum(root.Left, Sum, path);
                FindPathforSum(root.Right, Sum, path);

                PrintPath(path, Sum);

                path.Remove(root.Value);
            }
        }

        private void PrintPath(List<int> path, int Sum)
        {
            List<int> temp = path;
            int idx = 0;
            int value = 0;
            
            while(idx < path.Count )
            {
                value += path[idx];

                if (value < Sum)
                {
                    idx++;                      
                }
                else if(value == Sum)
                {
                    Console.WriteLine("Met sum");
                    return;
                }
                else
                {
                    return;                   
                }               
            }
        }

        public void EvalExpressionTree()
        {
            ExpressionNode root = new ExpressionNode("+");
            root.Left = new ExpressionNode("*");
            root.Right = new ExpressionNode("-");
            root.Left.Left = new ExpressionNode("5");
            root.Left.Right = new ExpressionNode("4");
            root.Right.Left = new ExpressionNode("100");
            root.Right.Right = new ExpressionNode("20");

            Console.WriteLine(EvalExpTree(root));
        }

        private int EvalExpTree(ExpressionNode root)
        {
            if(root == null)
            {
                return 0;
            }

            if (root.Left == null && root.Right == null)
            {
                return int.Parse(root.Value);
            }

            int left = EvalExpTree(root.Left);
            int right = EvalExpTree(root.Right);

            switch(root.Value)
            {
                case "+":
                    {
                        return left + right;
                        
                    }
                case "-":
                    {
                        return left - right;

                    }
                case "*":
                    {
                        return left * right;

                    }
                case "/":
                    {
                        return left / right;

                    }
                default:
                    return 0;
            }
        }

        public void FindCousinOfNode()
        {
            Node root = new Node(1);
            root.Left = new Node(2);
            root.Right = new Node(3);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(5);
            root.Right.Left = new Node(6);
            root.Right.Right = new Node(7);

            PrintCousinsOfNode(root, root.Left.Right);
        }

        private void PrintCousinsOfNode(Node root, Node desiredNode)
        {
            if(root == null)
            {
                Console.WriteLine("root is null");
                return;
            }

            if(root == desiredNode)
            {
                Console.WriteLine("no cousins");
                return;
            }

            Queue<Node> levelQueue = new Queue<Node>();
            levelQueue.Enqueue(root);

            while (levelQueue.Count > 0)
            {
                Node current = levelQueue.Dequeue();

                if(current.Left == desiredNode ||
                    current.Right == desiredNode)
                {
                    Node parent = levelQueue.Dequeue();
                    Console.WriteLine(parent.Left.Value);
                    Console.WriteLine(parent.Right.Value);
                    return;
                }
                else
                {
                    levelQueue.Enqueue(current.Left);
                    levelQueue.Enqueue(current.Right);
                }
            }
            return;
        }

        public void IsBst()
        {
            Node root = new Node(10);
            root.Left = new Node(6);
            root.Right = new Node(12);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(7);
            root.Right.Left = new Node(17);
            root.Right.Right = new Node(15);

            Console.WriteLine(IsBstUtil(root));
        }

        private bool IsBstUtil(Node root)
        {
            bool isBst = true;
            if(root.Left == null || root.Right == null)
            {
                return true;
            }
            else
            {
                if (isBst)
                {
                    isBst = IsBstUtil(root.Left);
                    int left = root.Left.Value;
                    isBst = IsBstUtil(root.Right);
                    int right = root.Right.Value;

                    if (left > right)
                    {
                        isBst = false;
                        return isBst;
                    }
                }
                else
                {
                    return isBst;
                }
            }

            return isBst;
        }

        public void TernaryTree()
        {
            string str = "a?b?c:d:e";
            TernaryTreeUtil(str);
            
        }

        private Node TernaryTreeUtil(string str)
        {
            Stack<Node> stk = new Stack<Node>();
            bool IsExpressionTrue = true;
            Node node = null;
            Node root = null;

            for(int idx = 0; idx < str.Length; idx ++)
            {
                switch(str.ElementAt(idx))
                {
                    case '?':
                        {
                            if (node != null)
                            {
                                stk.Push(node);
                            }
                            IsExpressionTrue = true;
                            break;
                        }
                    case ':':
                        {
                            IsExpressionTrue = false;
                            break;
                        }
                    default:
                        {
                            char ch = str.ElementAt(idx);
                            Node newNode = new Node(ch);

                            if (root == null)
                            {
                                root = newNode;
                            }

                            if (node == null)
                            {
                                node = newNode;
                                break;
                            }

                            if (IsExpressionTrue)
                            {
                                node = ConstructTree(node, newNode, true);
                                IsExpressionTrue = false;
                            }
                            else
                            {
                                Node parent = stk.Pop();
                                node = ConstructTree(parent, newNode, false);
                            }

                            break;
                        }
                }
            }
            return root;
        }

        private Node ConstructTree(Node parent, Node child, bool IsLeftChild)
        {
            if(IsLeftChild)
            {
                parent.Left = child;
            }
            else
            {
                parent.Right = child;
            }

            return child;
        }

        public void SatisfyAndProperty()
        {
            Node root = new Node(0);
            root.Left = new Node(1);
            root.Right = new Node(0);
            root.Left.Left = new Node(0);
            root.Left.Right = new Node(1);
            root.Right.Left = new Node(1);
            root.Right.Right = new Node(1);

            SatisfyAndPropertyUtil(root);
        }

        private Node SatisfyAndPropertyUtil(Node current)
        {
            if (current == null)
            {
                return null;
            }

            Node Left = SatisfyAndPropertyUtil(current.Left);

            Node right = SatisfyAndPropertyUtil(current.Right);
            if (Left != null && right != null)
            {
                current.Value = Left.Value & right.Value;
            }
            
            return current;
        }

        public void LCAMyImpl()
        {
            Node node = new Node(3);
            node.Left = new Node(6);
            node.Right = new Node(8);
            node.Left.Left = new Node(2);
            node.Left.Right = new Node(11);
            //node.Right.Left = new Node(6);
            node.Right.Right = new Node(13);
            node.Left.Right.Left = new Node(9);
            node.Left.Right.Left = new Node(5);
            node.Right.Right.Left = new Node(7);

            Stack<Node> rootnodes = new Stack<Node>();
            bool foundLeft = false;
            bool foundRight = false;
            LCAMyImplUtil(node,9, 5, rootnodes, ref foundLeft, ref foundRight);
        }

        private void LCAMyImplUtil(Node node, int left, int right, Stack<Node> rootNodes, ref bool foundLeft, ref bool foundRight)
        {
            Node rootNode = null;


            if(foundLeft && foundRight)
            {
                while (rootNodes.Count > 1)
                {
                    rootNodes.Pop();
                }

                Console.WriteLine(rootNodes.Pop().Value);
                return;
            }

            if(node == null)
            {
                return;
            }

            if (node.Left != null && node.Left.Value == left)
            {
                foundLeft = true;
                rootNode = node;
                //return node;
            }
            else if(node.Right!= null && node.Right.Value == right)
            {
                foundRight = true;
                rootNode = node;
                //return rootNode;
            }

            rootNodes.Push(node);


            if (!foundLeft || !foundRight)
            {
                LCAMyImplUtil(node.Left, left, right, rootNodes, ref foundLeft, ref foundRight);

                LCAMyImplUtil(node.Right, left, right, rootNodes, ref foundLeft, ref foundRight);
            }
            else
            {
                return;
            }

        }

        public void FindDistancebetweenNodes()
        {
            Node node = new Node(3);
            node.Left = new Node(6);
            node.Right = new Node(8);
            node.Left.Left = new Node(2);
            node.Left.Right = new Node(11);
            //node.Right.Left = new Node(6);
            node.Right.Right = new Node(13);
            node.Right.Left = new Node(9);
            node.Left.Right.Left = new Node(5);
            node.Right.Right.Left = new Node(7);

            int dist = 0;
            int d1 = -1;
            int d2 = -1;
            int n1 = 11;
            int n2 = 5;
            node = DistanceBetweenNodesUtil(node, n1, n2, ref d1, ref d2, ref dist, 1);

            if(d1 == -1)
            {
                dist = FindLevel(node, n1, 0);
            }

            if(d2 == -1)
            {
                dist = FindLevel(node, n2, 0);
            }

            Console.WriteLine(dist);
        }

        private Node DistanceBetweenNodesUtil(Node node, int n1, int n2, ref int d1, ref int d2,ref int dist, int lvl)
        {
            if(node== null)
            {
                return null;
            }

            if(node.Value == n1)
            {
                d1 = lvl;
                return node;
            }

            if(node.Value == n2)
            {
                d2 = lvl;
                return node;
            }

            Node left_LCA = DistanceBetweenNodesUtil(node.Left, n1, n2, ref d1, ref d2, ref dist, lvl +1);
            Node right_LCA = DistanceBetweenNodesUtil(node.Right, n1, n2, ref d1, ref d2, ref dist, lvl + 1);

            if(left_LCA != null && right_LCA != null)
            {
                dist = d1 + d2 - 2 * lvl;
                return node;
            }

            return (left_LCA == null) ? right_LCA : left_LCA;
        }

        private int FindLevel(Node node, int k, int lvl)
        {
            if(node == null)
            {
                return -1;
            }

            if(node.Value == k)
            {
                return lvl;
            }

            int l = FindLevel(node.Left, k, lvl + 1);

            return (lvl != -1) ? l : FindLevel(node.Right, k, lvl +1);
        }

        public void FindNodeDistFromRoot()
        {
            Node node = new Node(3);
            node.Left = new Node(6);
            node.Right = new Node(8);
            node.Left.Left = new Node(2);
            node.Left.Right = new Node(11);
            node.Right.Right = new Node(13);
            node.Right.Left = new Node(9);
            node.Left.Right.Left = new Node(5);
            node.Right.Right.Left = new Node(7);

            Console.WriteLine(findNodeDistFromrootUtil(node, 9, 0));
        }

        private int findNodeDistFromrootUtil(Node root, int Value, int level)
        {
            int d = 0;

            if(root == null)
            {
                return 0;
            }

            if(root.Value == Value)
            {
                d = level;
            }
            else
            {
                if (d == 0)
                {
                    d = findNodeDistFromrootUtil(root.Left, Value, level + 1);
                }

                if (d == 0)
                {
                    d = findNodeDistFromrootUtil(root.Right, Value, level + 1);
                }
            }

            return d;
        }

        public void ConvertTreeToSLL()
        {
            Node node = new Node(1);
            node.Left = new Node(2);
            node.Right = new Node(5);
            node.Left.Left = new Node(3);
            node.Left.Right = new Node(4);
            node.Right.Right = new Node(6);
            SLLNode sllNode = null;
            SLLNode head = sllNode;
            //head = ConvertTreeToSLLUtil(node, head, ref sllNode);
            Node result = ConvertTreeToSLLInPlace(node, null);
        }

        private SLLNode ConvertTreeToSLLUtil(Node node, SLLNode head, ref SLLNode sllNode)
        {
            if(node == null)
            {
                return head;
            }

            if(sllNode == null)
            {
                sllNode = new SLLNode(node.Value);
                head = sllNode;
            }
            else
            {
                sllNode.Next = new SLLNode(node.Value);
                sllNode = sllNode.Next;
            }

            head = ConvertTreeToSLLUtil(node.Left,head,  ref sllNode);
            head = ConvertTreeToSLLUtil(node.Right, head, ref sllNode);

            return head;
        }

        private Node ConvertTreeToSLLInPlace(Node root, Node pre)
        {
            if (root == null)
            {
                return pre;
            }

            pre = ConvertTreeToSLLInPlace(root.Right, pre);
            pre = ConvertTreeToSLLInPlace(root.Left, pre);
            root.Right = pre;
            root.Left = null;
            pre = root;
            return pre;
        }

        public void TreeToDLL()
        {
            Node node = new Node(1);
            node.Left = new Node(2);
            node.Right = new Node(3);
            node.Left.Left = new Node(4);
            node.Left.Right = new Node(5);
            node.Right.Left = new Node(6);
            node.Right.Right = new Node(7);
            Node head = null;
            Node pre = null;

           TreeToDLL(node, ref pre, ref head);
        }

        private void TreeToDLL(Node node, ref Node pre, ref Node head)
        {
            if(node == null)
            {
                return;
            }

            TreeToDLL(node.Left, ref pre, ref head);

            if (pre != null)
            { 
                pre.Right = node;
            }
            else
            {
                if (head == null)
                {
                    head = node;
                }
            }

            node.Left = pre;
            pre = node;

            TreeToDLL(node.Right, ref pre, ref head);
        }

        public void DisplayRightMostNodes()
        {
            Queue<int> nodeQueue = new Queue<int>();

            Node node = new Node(1);
            node.Left = new Node(2);
            node.Right = new Node(5);
            node.Left.Left = new Node(3);
            node.Left.Right = new Node(4);
            node.Right.Right = new Node(6);

            for (int idx = 1; idx < 4; idx++)
            {
                DisplayRightMostNodesUtil(node, idx, nodeQueue);
                while(nodeQueue.Count > 1)
                {
                    nodeQueue.Dequeue();
                }
                if (nodeQueue.Any())
                {
                    Console.WriteLine(nodeQueue.Dequeue());
                }
            }
        }

        private void DisplayRightMostNodesUtil(Node node, int level, Queue<int> nodeQueue)
        {
            if(node == null)
            {
                return;
            }

            if(level == 1)
            {
                if (node != null)
                {
                    nodeQueue.Enqueue(node.Value);
                }
                return;
            }

            DisplayRightMostNodesUtil(node.Left, level - 1, nodeQueue);
            DisplayRightMostNodesUtil(node.Right, level - 1, nodeQueue);
        }

        public void HasDuplicateSubTree()
        {
            Node node = new Node(1);
            node.Left = new Node(2);
            node.Right = new Node(3);
            node.Left.Left = new Node(4);
            node.Left.Right = new Node(5);
            node.Right.Right = new Node(3);
            node.Right.Right.Left = new Node(4);
            node.Right.Right.Right = new Node(5);

            bool result = true;
            Dictionary<int, Node> map = new Dictionary<int, Node>();
            Console.WriteLine(HasDuplicateSubTree(node,map, ref result));
        }

        public bool HasDuplicateSubTree(Node node,Dictionary<int, Node> map, ref bool result)
        {
            if(node == null)
            {
                return result;
            }

            if(!map.ContainsKey(node.Value) && result)
            {
                map.Add(node.Value, node);
                result = HasDuplicateSubTree(node.Left, map, ref result);
                result = HasDuplicateSubTree(node.Right, map,ref  result);
            }
            else
            {
                return HasDupeSubTreeUtil(node, map[node.Value], ref result);
            }

            return result;
        }

        private bool HasDupeSubTreeUtil(Node node, Node dupe, ref bool result)
        {
            if((node.Left == null && node.Right == null) || 
                (dupe.Left==null && dupe.Right == null))
            {
                return result;
            }

            if(node.Left.Value != dupe.Left.Value ||
                node.Right.Value != dupe.Right.Value)
            {
                result = false;
            }

            if (result)
            {
                result = HasDupeSubTreeUtil(node.Left, dupe.Left, ref result);
            }
            if (result)
            {
                result = HasDupeSubTreeUtil(node.Right, dupe.Right, ref result);
            }

            return result;
        }

        public void KthSmallestInBst()
        {
            Node root = new Node(20);
            root.Left = new Node(8);
            root.Right = new Node(22);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(12);
            root.Left.Right.Left = new Node(10);
            root.Left.Right.Right = new Node(14);

            int count = 0;
            Console.WriteLine(KthSmallestInBst(root, 7, ref count));
        }

        private int KthSmallestInBst(Node node, int k, ref int count)
        {
            int res = 0;

            if (node == null)
            {
                return 0;
            }

            count++;

            if (count == k)
            {
                return node.Value;
            }

            if (count < k)
            {
                res = KthSmallestInBst(node.Left, k, ref count);
            }

            if(count < k)
            {
                res = KthSmallestInBst(node.Right, k, ref count);
            }

            return res;
        }

        public void MaxSumPathRootToleaf()
        {
            Node node = new Node(10);
            node.Left = new Node(-2);
            node.Right = new Node(7);
            node.Left.Left = new Node(8);
            node.Left.Right = new Node(-4);
            int max = 0;
            Console.WriteLine(MaxSumPathRootToleaf(node, 0, ref max));
        }

        private int MaxSumPathRootToleaf(Node node, int Sum, ref int Max)
        {
            if(node == null)
            {
                if (Max < Sum)
                {
                    Max = Sum;
                }

                return Max;
            }

            int result = 0;

            result = MaxSumPathRootToleaf(node.Left, Sum + node.Value, ref Max);
            result = MaxSumPathRootToleaf(node.Right, Sum + node.Value, ref Max);

            return result;
        }

        public void FindMaxSumPath()
        {
            Node node = new Node(10);
            node.Left = new Node(2);
            node.Right = new Node(10);
            node.Left.Left = new Node(20);
            node.Left.Right = new Node(1);
            node.Right.Right = new Node(-25);
            int maxSum = 0;

            Console.WriteLine(findMaxsumPath(node, ref maxSum));
        }

        private int findMaxsumPath(Node node, ref int maxSum)
        {
            if(node == null)
            {
                return 0;
            }

            int left = findMaxsumPath(node.Left, ref maxSum);
            int right = findMaxsumPath(node.Right, ref maxSum);

            int max_single = Math.Max(Math.Max(left, right) + node.Value, node.Value);

            int max_top = Math.Max(max_single, left + right + node.Value);

            maxSum = Math.Max(max_top, maxSum);

            return max_single;
        }

        public void MaxSumPathOf2Leaves()
        {
            Node node = new Node(-15);
            node.Left = new Node(5);
            node.Right = new Node(6);
            node.Left.Left = new Node(-8);
            node.Left.Right = new Node(1);
            node.Left.Left.Left= new Node(2);
            node.Left.Left.Right = new Node(6);
            node.Right.Right = new Node(9);
            node.Right.Left = new Node(3);
            node.Right.Right.Right = new Node(0);
            node.Right.Right.Right.Left = new Node(4);
            node.Right.Right.Right.Right = new Node(-1);
            node.Right.Right.Right.Right.Left = new Node(10);
            int max = 0;

            Console.WriteLine(MaxSumPathOf2Leaves(node, 0, ref max));
        }

        private int MaxSumPathOf2Leaves(Node node, int sum, ref int max)
        {
            if(node == null)
            {
                return 0;
            }

            int left = MaxSumPathOf2Leaves(node.Left, sum, ref max);
            int right = MaxSumPathOf2Leaves(node.Right, sum, ref max);

            sum = Math.Max(left, right) + node.Value;

            max = Math.Max(left + right + node.Value , max);

            return sum;
        }

        public void LeftView()
        {
            Node node = new Node(12);
            node.Left = new Node(10);
            node.Right = new Node(30);
            node.Right.Left = new Node(25);
            node.Right.Right = new Node(40);

            int maxLevel = 0;
            PrintLeftView(node, 1, ref maxLevel);
        }

        private void PrintLeftView(Node node, int curLevel, ref int maxLevel)
        {
            if(node == null)
            {
                return;
            }

            if(maxLevel < curLevel)
            {
                Console.WriteLine(node.Value);
                maxLevel = curLevel;
            }

            PrintLeftView(node.Left, curLevel + 1, ref maxLevel);
            PrintLeftView(node.Right, curLevel + 1, ref maxLevel);
        }

        public void MaxsumRootToLeaf()
        {
            Node node = new Node(10);
            node.Left = new Node(-2);
            node.Right = new Node(7);
            node.Left.Left = new Node(8);
            node.Left.Right = new Node(-4);

            Console.WriteLine(MaxsumRootToLeaf(node));
        }

        private int MaxsumRootToLeaf(Node node)
        {
            if(node == null)
            {
                return 0;
            }

            int left = MaxsumRootToLeaf(node.Left);
            int right = MaxsumRootToLeaf(node.Right);

            return (node.Value + Math.Max(left, right));
        }

        public void HeightOfTree()
        {
            Node node = new Node(10);
            node.Left = new Node(-2);
            node.Right = new Node(7);
            node.Left.Left = new Node(8);
            node.Left.Right = new Node(-4);

            Console.WriteLine(HeightOfTree(node));
        }

        private int HeightOfTree(Node node)
        {
            int height = 0;

            if(node == null)
            {
                return 0;
            }

            height = 1 + Math.Max(HeightOfTree(node.Left), HeightOfTree(node.Right));

            return height;
        }

        public void AreIdentical()
        {
            Node root = new Node(10);
            root.Left = new Node(8);
            root.Right = new Node(15);
            root.Left.Left = new Node(6);
            root.Left.Right = new Node(9);
            bool result = true;
            Node dupe = root.Right;
            Console.WriteLine(AreIdentical(root.Left, dupe, ref result));
        }

        private bool AreIdentical(Node first, Node second, ref bool result)
        {
            if(! result)
            {
                return false;
            }

            if(first != second)
            {
                return false;
            }

            if(first == null & second == null)
            {
                return true;
            }

            //if(first == null && second != null ||
            //    first != null && second == null)
            //{
            //    return false;
            //}

            result = AreIdentical(first.Left, second.Left, ref result);

            if(result)
            {
                result = AreIdentical(first.Right, second.Right, ref result);
            }

            return result;
        }

        public void SubTreeNodeCount()
        {
            Node node = new Node(1);
            node.Left = new Node(4);
            node.Right = new Node(2);
            node.Left.Left = new Node(3);
            node.Left.Right = new Node(5);

            SubTreeNodeCount(node);
        }

        private int SubTreeNodeCount(Node node)
        {
            if(node == null)
            {
                return 0;
            }

            int left = SubTreeNodeCount(node.Left);
            int right = SubTreeNodeCount(node.Right);

            int nodecount = 1 + left + right;

            Console.WriteLine("Node count at node {0} is {1}", node.Value, nodecount);

            return nodecount;
        }

        public void BstIterator()
        {
            Node root = new Node(10);
            root.Left = new Node(8);
            root.Right = new Node(15);
            root.Left.Left = new Node(6);
            root.Left.Right = new Node(9);

            var iterator = new BSTIterator(root);
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }

        public void ZigZag()
        {
            Node node = new Node(1);
            node.Left = new Node(2);
            node.Right = new Node(3);
            node.Left.Left = new Node(4);
            node.Left.Right = new Node(5);
            //node.Right.Left = new Node(6);
            node.Right.Right = new Node(7);
            node.Right.Left = new Node(6);

            ZigZag(node);
        }

        private void ZigZag(Node node)
        {
            if (node == null)
            {
                Console.WriteLine("Tree is null");
                return;
            }

            var primary = new Stack<Node>();
            var secondary = new Stack<Node>();

            primary.Push(node);

            while (primary.Count > 0 || secondary.Count > 0)
            {
                if (primary.Count > 0)
                {
                    Print(primary, secondary, true);
                }
                else
                {
                    Print(secondary, primary, false);
                }
            }
        }

        private void Print(Stack<Node> source, Stack<Node> target, bool isPrimary)
        {
            while (source.Count > 0)
            {
                var item = source.Pop();
                Console.WriteLine(item.Value);

                if (isPrimary && item != null)
                {
                    if (item.Left != null)
                    {
                        target.Push(item.Right);
                    }
                    if (item.Right != null)
                    {
                        target.Push(item.Left);
                    }
                }
                else
                {
                    if (item.Right != null)
                    {
                        target.Push(item.Left);
                    }
                    if (item.Left != null)
                    {
                        target.Push(item.Right);
                    }
                }
            }
        }
    }


    public class Node
    {
        public Node (int Value)
        {
            this.Value = Value;
        }

        public Node Left;
        public Node Right;
        public int Value;
    }

    public class BSTIterator
    {
        private Stack<Node> stack = new Stack<Node>();
        private Node current = null;

        public BSTIterator(Node root)
        {
            this.current = root;
            stack.Push(current);
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }

        public int Next()
        {
            while(current != null)
            {
                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
                current = current.Left;
            }
            
            var nextNode = stack.Pop();
            current = nextNode.Right;
            return nextNode.Value;
        }
    }

    public class ExpressionNode
    {
        public ExpressionNode(string Value)
        {
            this.Value = Value;
        }

        public ExpressionNode Left;
        public ExpressionNode Right;
        public string Value;
    }

    public class LinkedListNode
    {
        int Value;
        public LinkedListNode(int Value)
        {
            this.Value = Value;
        }

        public LinkedListNode Prev;
        public LinkedListNode Next;
    }
}
