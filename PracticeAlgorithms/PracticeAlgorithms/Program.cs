using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(6);
            //g.AddEdge(0, 1);
            //g.AddEdge(1, 2);
            //g.AddEdge(2, 0);
            //g.AddEdge(2, 0);
            //g.AddEdge(2, 3);
            //g.AddEdge(3, 3);
            //g.IsCyclic();

            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            //g.TopologicalSort();
            //g.AddEdge(3, 4);
            //g.AddEdge(4, 5);
            //g.AddEdge(0, 3);
            //g.AddEdge(3, 4);
            //g.IsCyclicUndirected();
            //g.FindMinTreeHeight();
            //g.IsCyclicUndirected();
            //g.CheckPathExistence();
            //g.FindSameContacts();
            //g.TraverseGraph(g);
            //g.BfsPathToNode();
            //g.SourceToDestMatrixBfs();

            int[] arr = { 1, 2, 5 };
            int n = arr.Length;

            //subsetSums(arr, 0, n - 1);

            SubsetSum obj = new SubsetSum();
            //obj.subsetSums(arr, 0, n - 1);
            //obj.CheckSubSetSumExists(arr, 0, n - 1, 5);
            //obj.PrintSequenceMatchingNumber();

            //obj.CheckSubSetSumExists(arr, 0, 2, 4);
            RecursionConcepts recursionObj = new RecursionConcepts();
            //obj.FindExponent(2, 3);
            //recursionObj.PermutationUnderConstraints();
            //recursionObj.GoldMine();
            //recursionObj.TowerOfHanoi();
            //recursionObj.FindMedianOfSortedArrays();
            //recursionObj.SolveCoinChange();
            //recursionObj.FindKthElementSortedArray();
            //recursionObj.TugOfWar();

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(7);
            stack.Push(3);
            stack.Push(4);
            stack.Push(6);

            //recursionObj.ReverseStack(stack);

            SortStack stkObj = new SortStack();
            //stkObj.SortAscending(stack);
            //stkObj.ReverseStackUsingRecursion();

            //recursionObj.RecurseSortStack(stack);
            //recursionObj.Permutation();
            //recursionObj.PhoneDialpad();
            //recursionObj.CountCombinations();

            //recursionObj.Combination();
            //recursionObj.DiffWaysToCompute();
            //recursionObj.CalcMedianOfsortedArrays();

            int[] Val = { 7 , 4, 5, 1};
            int[] W = {5, 3, 4, 1 };
            //recursionObj.Knapsack(Val, W, 50);
            //recursionObj.SolveCoinChange(arr, arr.Length - 10, 9);
            //recursionObj.FindIslands();
            //recursionObj.SubsetSum();
            //recursionObj.MaxSubSequence();

            DynamicProgramming dpObj = new DynamicProgramming();
            //dpObj.IsSubSetSum(arr, 17);
            //dpObj.KnapSack(Val, W, 7);
            //dpObj.HighwayBillboard();
            //dpObj.FriendsPair();
            //dpObj.ConsecutiveModulo();
            //dpObj.MatrixBoundary();
            //dpObj.MorseCode();
            //dpObj.Histogram();
            //dpObj.LongestPalindronomicSubsequence();
            //dpObj.LongestPalindromicSubstring();
            //dpObj.LCS();
            //dpObj.DecodeCombinations();
            //dpObj.WordWrap();
            //dpObj.LCSMyImpl();
            //dpObj.CreLCS();
            //dpObj.LargestSubArraySum();
            //dpObj.MinCoinsNeeded();
            //dpObj.EditDistance();
            //dpObj.LIS();

            Trees treeObj = new Trees();
            int[] arrBST = { 1, 2, 3 , 4};
            //treeObj.ConvertArray2BST(arrBST);
            //treeObj.FindLCA();
            //treeObj.BinaryTreeToDLL();
            //treeObj.ReturnHeadNodeOfTree();
            //treeObj.DoesPathExists();
            //treeObj.FindPathForDesiredSum();
            //treeObj.EvalExpressionTree();
            //treeObj.FindCousinOfNode();
            //treeObj.IsBst();
            //treeObj.TernaryTree();
            //treeObj.SatisfyAndProperty();
            //treeObj.LCAMyImpl();
            //treeObj.FindDistancebetweenNodes();
            //treeObj.FindNodeDistFromRoot();
            //treeObj.ConvertTreeToSLL();
            //treeObj.TreeToDLL();
            //treeObj.DisplayRightMostNodes();
            //treeObj.HasDuplicateSubTree();
            //treeObj.KthSmallestInBst();
            //treeObj.MaxSumPathRootToleaf();
            //treeObj.FindMaxSumPath();
            //treeObj.MaxSumPathOf2Leaves();
            //treeObj.LeftView();
            //treeObj.MaxsumRootToLeaf();
            //treeObj.HeightOfTree();
            //treeObj.AreIdentical();
            //treeObj.SubTreeNodeCount();
            //treeObj.BstIterator();
            //treeObj.ZigZag();

            Arrays arrobj = new Arrays();
            char[] inputArr = new char[6] {'(','(',')','(',')', ')'};
            //arrobj.ValidateParanthesis(inputArr);
            char[] paranArr = new char[6];
            //arrobj.CountValidParanthesisCombo(paranArr, 6);
            //arrobj.PrintMatchIndex();
            //arrobj.IsValidBraces();
            //arrobj.FindUnique();
            //arrobj.PlaceHeight();
            //arrobj.IsAnagram();
            //arrobj.FindMatrixSol();
            //arrobj.MaxHeap();
            //arrobj.FindLongestPathInMatrix();
            //arrobj.TrapWater();
            //arrobj.findFriendGrp();
            //arrobj.FibonacciSubset();
            //arrobj.FindLoopInArray();
            //arrobj.FindMinMutationCount();
            //arrobj.PlantFlowers();
            //arrobj.AppendZero();
            //arrobj.FirstMissingPositive();
            //arrobj.SnakeNLadder();
            //arrobj.Histogram();
            arrobj.WaterTrap();
            //arrobj.AnagramIndicesList();
            //arrobj.matchLunches();
            //arrobj.Skyline();
            //arrobj.NQueen();
            //arrobj.CreComparator();
            //arrobj.MaxContiugousSum();
            //arrobj.JobScheduling();
            //arrobj.FindMinOfRotatedSorted();
            //arrobj.ValidNComboOfBraces();
            //arrobj.LargestSumContigousSubArray();
            //arrobj.MaximalRectangleArea();  // TODO

            SLL objSLL = new SLL();
            //objSLL.ReverseSLL();
            //objSLL.ReverseSLL();
            //objSLL.ReverseKNodes();
            //objSLL.IsPalindrome();
            //objSLL.LengthOfLoop();
            //objSLL.Clone();
            //objSLL.ReverseKnodes();
            //objSLL.FindKthNodeFromLast();


            Strings strObj = new Strings();
            //strObj.IsTransformable();
            //strObj.IsWildcardPattern();
            //strObj.atoi();
            //LinkedList linkedListObj = new Lin
            //strObj.ReturnMappedString();
            //strObj.WordBreak(); //TODO

            Integers intObj = new Integers();
            //intObj.IsPalindrome();

            Priorityqueue objPriorityQ = new Priorityqueue(6);
            //objPriorityQ.DoOperations();

            Console.Read();
        }
    }
}
