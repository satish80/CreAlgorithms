using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class RecursionConcepts
    {
        public void FindExponent(int num, int pow)
        {
            Console.WriteLine(RecurseExponent(num, pow));
        }

        private int RecurseExponent(int num, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }
            else
            {
                return num * RecurseExponent(num, pow - 1);
            }
        }

        public void ReverseStack(Stack<int> stack)
        {
            RecurseStack(stack);
            Console.Read();
        }

        private void RecurseStack(Stack<int> stack)
        {
            int value = 0;

            if(stack.Count != 0)
            {
                Console.WriteLine(stack.Peek());
                value = stack.Pop();
                RecurseStack(stack);
                stack.Push(value);
            }            
        }
        public Stack<int> RecurseSortStack(Stack<int> stack)
        {
            sortStack(stack);
            return stack;
        }

        void sortStack(Stack<int> s)
        {
            // If stack is not empty
            if (s.Count > 0)
            {
                // Remove the top item
                int x = s.Pop();

                // Sort remaining stack
                sortStack(s);

                // Push the top item back in sorted stack
                sortedInsert(s, x);
            }
        }

        void sortedInsert(Stack<int> s, int x)
        {
            // Base case: Either stack is empty or newly inserted
            // item is greater than top (more than all existing)
            if (s.Count == 0 || x > s.Peek())
            {
                s.Push(x);
                return;
            }

            // If top is greater, remove the top item and recur
            int temp = s.Pop();
            sortedInsert(s, x);

            // Put back the top item removed earlier
            s.Push(temp);
        }

        public void Permutation()
        {
            char[] arr = { 'a', 'b', 'c' };
            Permute(arr, 0, 3);
        }

        private void Permute(char[] arr, int k, int n)
        {
            if (k == n)
            {
                for (int idx = 0; idx < n; idx++)
                {
                    Console.WriteLine(arr[idx]);
                }
            }
            else
            {
                for(int i= k; i< n; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Permute(arr, k + 1, n);
                    Swap(ref arr[i], ref arr[k]);
                }
            }
        }

        private void Swap(ref char a, ref char b)
        {
            char temp = b;
            b = a;
            a = temp;
        }

        public void Combination()
        {            
            int[] rep = new int[3];
            RecurseCombination(rep, 0, 3);
        }

        private void RecurseCombination(int[] rep, int k, int n)
        {
            if(k == n)
            {
                PrintCombination(rep);
                return;
            }
            rep[k] = 0;
            RecurseCombination(rep, k + 1, n);
            rep[k] = 1;
            RecurseCombination(rep, k + 1, n);
        }

        void PrintCombination(int[] rep)
        {
            char[] arr = { 'a', 'b', 'c' };

            for(int idx =0; idx < rep.Length; idx ++)
            {
                if(rep[idx] == 1)
                {
                    Console.WriteLine(arr[idx]);
                }
            }
            Console.WriteLine("-----------------------------");
        }


        public void Knapsack(int[] Val, int[] W, int desiredWeight)
        {
            Console.WriteLine(SolveKnapSack(Val, W, 0, 0, desiredWeight, 0));
        }

        private int SolveKnapSack(int[] Val, int[] W, int wIdx, int SumOfWeight, int desiredWeight, int Profit)
        {            
            if(SumOfWeight == desiredWeight)
            {
                return Profit;
            }
            if (SumOfWeight > desiredWeight || wIdx == W.Length)
            {
                return 0;
            }
            else
            {
                return Math.Max(SolveKnapSack(Val, W, wIdx, SumOfWeight + W[wIdx], desiredWeight, Profit + Val[wIdx]), 
                    SolveKnapSack(Val, W, wIdx +1, SumOfWeight + W[wIdx +1], desiredWeight, Profit + Val[wIdx +1]));
            }
        }

        public void SolveCoinChange(int[] arr, int l, int desiredSum)
        {
            int count = 0;
            CoinChange(arr, 0, 0, desiredSum, ref count);
            Console.WriteLine("No of coin change {0}", count);
        }

        private bool CoinChange(int[] arr, int l, int sum, int desiredSum, ref int count)
        {            
            if(sum== desiredSum)
            {
                count++;
                return true;
            }
            else if (l >= arr.Length - 1)
            {
                return false;
            }
            else
            {
                return CoinChange(arr, l + 1, sum + arr[l], desiredSum, ref count) || 
                         CoinChange(arr, l + 1, sum, desiredSum, ref count);
            }
        }

        public void PermutationUnderConstraints()
        {
            Console.WriteLine(findPermutationUnderConstraints(3, 1, 2));
        }

        // n is total number of characters.
        // bCount and cCount are counts of 'b'
        // and 'c' respectively.
        private int findPermutationUnderConstraints(int n, int bCount, int cCount)
        {
            // Base cases
            if (bCount < 0 || cCount < 0) return 0;
            if (n == 0) return 1;
            if (bCount == 0 && cCount == 0) return 1;

            // Three cases, we choose, a or b or c
            // In all three cases n decreases by 1.
            int res = findPermutationUnderConstraints(n - 1, bCount, cCount -1);
            res += findPermutationUnderConstraints(n - 1, bCount, cCount);
            res += findPermutationUnderConstraints(n - 1, bCount - 1, cCount);

            return res;
        }

        public void GoldMine()
        {
            int[,] mine = new int[,]
            {
                { 1, 3, 1, 5 },
                { 2, 2, 4, 1},
                { 5, 0, 2, 3},
                { 0, 6, 1, 2 }
            };

            int max = 0;
            int row = 0;

            for(int idx = 0; idx < mine.GetLength(0) -1;  idx++)
            {
                if(mine[idx,0] > max)
                {
                    row = idx;
                    max = mine[idx,0];
                }
            }

            Console.WriteLine(findGoldMine(mine, row, 0, max, ref max));
        }

        private int findGoldMine(int[,] mine, int row, int col, int val, ref int max)
        {
            int right = 0;
            int right_up = 0;
            int right_down = 0;

            if(row < 0 || col < 0)
            {
                return 0;
            }

            if(max < val)
            {
                max = val;
            }            

            if ((row + 1 <= mine.GetLength(0) - 1) && (col + 1 <= mine.GetLength(1) - 1))
            {
                right_down = findGoldMine(mine, row + 1, col + 1, val + mine[row + 1, col + 1], ref max);
            }

            if (col >= 1 && (col + 1 < mine.GetLength(1) -1))
            {
                right = findGoldMine(mine, row  , col + 1, val + mine[row , col + 1], ref max);
            }

            if (row > 0 && col + 1 <= mine.GetLength(1) - 1)
            {
                right_up = findGoldMine(mine, row - 1, col + 1, val + mine[row - 1, col + 1], ref max);
            }

            int maxSoFar =  Math.Max(right, right_up);
            maxSoFar = Math.Max(maxSoFar, right_down);

            return maxSoFar;
        }

        //
        //https://www.youtube.com/watch?v=rVPuzFYlfYE
        //
        public void TowerOfHanoi()
        {
            SolvetowerOfHanoi(3, 'A', 'B', 'C');
        }

        private void SolvetowerOfHanoi(int n, char source, char aux, char dest)
        {
            if(n == 1)
            {
                Console.WriteLine("From  {0} -> to {1}", source, dest);
            }

            else
            {
                SolvetowerOfHanoi(n - 1, 'A', 'C', 'B');
                SolvetowerOfHanoi(1, 'A', 'B', 'C');
                SolvetowerOfHanoi(n - 1, 'B', 'A', 'C');
            }
        }

        public void FindMedianOfSortedArrays()
        {
            int[] arr1 = {1, 3, 5, 6};
            int[] arr2 = {2, 4};
            int start1 = 0, start2 = 0;
            int end1 = arr1.Length - 1;
            int end2 = arr2.Length - 1;

            Console.WriteLine(SolveMedianOfSortedArrays(arr1, arr2, start1, end1, start2, end2));
        }

        private double SolveMedianOfSortedArrays(int[] arr1, int[] arr2, int start1, int end1, int start2, int end2)
        {
            int median1 = 0, median2 = 0;

            if (Math.Abs(start1 - end1) == 0 && Math.Abs(start2 - end2) == 0)
            {
                return arr1[start1] == arr2[start2] ? arr1[start1] : (arr1[start1] + arr2[start2]) / 2;
            }
            else if (Math.Abs(start1 - end1) == 1 && Math.Abs(start2 - end2) == 0)
            {
                return ((arr1[start1] + arr1[end1] / 2) + arr2[start2]) / 2;
            }
            else if (Math.Abs(start1 - end1) == 0 && Math.Abs(start2 - end2) == 1)
            {
                return ((arr2[start2] + arr2[end2] / 2) + arr1[start1]) / 2;
            }
            else if (Math.Abs(start1 - end1) == 1 && Math.Abs(start2 - end2) == 1)
            {
                return ((arr2[start2] + arr2[end2] / 2) + (arr1[start1] + arr1[end1]) /2) / 2;
            }
            else
            {
                median2 = Math.Abs((start2 + end2) / 2);
                median1 = Math.Abs((start1 + end1) / 2);
            }

            if (arr1[median1] <= arr2[median2])
            {
                start1 = median1;
                end2 = median2;
            }
            else
            {
                end1 = median1;
                start2 = median2;
            }

            return SolveMedianOfSortedArrays(arr1, arr2, start1, end1, start2, end2);
        }

        //double findMedianSortedArrays(int[] A, int m, int[] B, int n)
        //{
        //    if (m > n) return findMedianSortedArrays(B, n, A, m);
        //    int minidx = 0, maxidx = m, i = 0, j = 0, num1 = 0, mid = (m + n + 1) >> 1, num2;
        //    while (minidx <= maxidx)
        //    {
        //        i = (minidx + maxidx) >> 1;
        //        j = mid - i;
        //        if (i < m && j > 0 && B[j - 1] > A[i]) minidx = i + 1;
        //        else if (i > 0 && j < n && B[j] < A[i - 1]) maxidx = i - 1;
        //        else
        //        {
        //            if (i == 0) num1 = B[j - 1];
        //            else if (j == 0) num1 = A[i - 1];
        //            else num1 = Math.Max(A[i - 1], B[j - 1]);
        //            break;
        //        }
        //    }
        //    if (((m + n) & 1)) return num1;
        //    if (i == m) num2 = B[j];
        //    else if (j == n) num2 = A[i];
        //    else num2 = Math.Min(A[i], B[j]);
        //    return (num1 + num2) / 2;
        //}

        public void FindIslands()
        {
            int[,] arr = new int[5, 5]
            {
                { 1, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 1 }
            };

            Console.WriteLine(SolveFindIslands(arr));
        }

        private int SolveFindIslands(int[,] arr)
        {
            int rowBounds = arr.GetUpperBound(0);
            int colBounds = arr.GetUpperBound(1);
            int isLandCount = 0;

            for (int row = 0; row <= arr.GetUpperBound(0); row ++)
            {
                for(int col = 0; col <= arr.GetUpperBound(1); col++)
                {
                    if (arr[row, col] == 1)
                    {
                        Console.WriteLine("row: {0} col: {0}", row, col);
                        FindIslandsUtil(arr,  row,  col, rowBounds, colBounds);
                        isLandCount++;
                    }
                }
            }

            return isLandCount;
        }

        private void FindIslandsUtil(int[,] arr, int row, int col, int rowBounds, int colBounds)
        {
            if (row > rowBounds || col > colBounds || col < 0)
            {
                return;
            }

            if (arr[row,col] != 1)
            {
                return;
            }
            else
            {
                arr[row, col] = 2;

                FindIslandsUtil(arr, row, col +1, rowBounds, colBounds);
                FindIslandsUtil(arr, row +1, col, rowBounds, colBounds);
                FindIslandsUtil(arr, row +1, col - 1, rowBounds, colBounds);                
            }
        }

        public void SolveCoinChange()
        {
            int[] coins = {10};

            int result = CoinChangeUtil(coins, 10);

            Console.WriteLine("There are  {0} solutions ", result);
        }

        private int CoinChangeUtil(int[] coins, int desiredSum)
        {
            int count = CoinChange(coins, desiredSum, 0, 0);

            return count;
        }


        private int CoinChange(int[] coins, int desiredSum, int idx, int sum)
        {
            int count = 0;
            if (idx > coins.Length - 1 || sum > desiredSum)
            { 
                return 0;
            }

            if (sum == desiredSum)
            {               
                return 1;
            }
            else
            {
                count += CoinChange(coins, desiredSum, idx, sum + coins[idx]);
                if (idx + 1 < coins.Length)
                {
                    count += CoinChange(coins, desiredSum, idx + 1, sum );
                }
            }

            return count;
        }

        public void FindKthElementSortedArray()
        {
            int[] arr1 = new int[]{2, 3, 6, 7, 11 };
            int[] arr2 = new int[] {8, 9, 18, 20 };

            int k = 6;
            int result = KthElementUtil(arr1, arr2, 0, 5, 0, 4, k - 1);
            Console.WriteLine(result);
        }

        private static int KthElementUtil(int[] arr1, int[] arr2, int start1, int end1,
                            int start2, int end2, int k)
        {
            int mid1 = Math.Abs(end1 - start1) / 2;
            int mid2 = Math.Abs(end2 - start2) / 2;

            if (start1 == end1)
            {
                return arr2[start2 + k];
            }

            if (start2 == end2)
            {
                return arr1[start1 + k];
            }

            if (mid1 + mid2 < k)
            {
                if (arr1[start1 + mid1] < arr2[start2 + mid2])
                {
                    return KthElementUtil(arr1, arr2, start1 + mid1 + 1, end1, start2, end2, k - mid1 - 1);
                }
                else
                {
                    return KthElementUtil(arr1, arr2, start1, end1, start2 + mid2 + 1, end2, k - mid2 - 1);
                }
            }
            else
            {
                if (arr1[start1 + mid1] < arr2[start2 + mid2])
                {
                    return KthElementUtil(arr1, arr2, start1, end1, start2, start2 + mid2, k);
                }
                else
                {
                    return KthElementUtil(arr1, arr2, start1, start1 + mid1, start2, end2, k);
                }
            }
        }

        public void PhoneDialpad()
        {
            int[] arr = new int[] {1, 2, 3};
            Dictionary<int, HashSet<char>> mapList = new Dictionary<int, HashSet<char>>();

            HashSet<char> set1 = new HashSet<char>();
            set1.Add('A');
            set1.Add('B');
            set1.Add('C');

            HashSet<char> set2 = new HashSet<char>();
            set2.Add('D');
            set2.Add('E');
            set2.Add('F');

            HashSet<char> set3 = new HashSet<char>();
            set3.Add('G');
            set3.Add('H');
            set3.Add('I');

            HashSet<char> set4 = new HashSet<char>();
            set4.Add('J');
            set4.Add('K');
            set4.Add('L');

            HashSet<char> set5 = new HashSet<char>();
            set5.Add('M');
            set5.Add('N');
            set5.Add('O');

            HashSet<char> set6 = new HashSet<char>();
            set6.Add('P');
            set6.Add('Q');
            set6.Add('R');

            HashSet<char> set7 = new HashSet<char>();
            set7.Add('S');
            set7.Add('T');
            set7.Add('U');

            HashSet<char> set8 = new HashSet<char>();
            set8.Add('V');
            set8.Add('W');
            set8.Add('X');

            HashSet<char> set9 = new HashSet<char>();
            set9.Add('Y');
            set9.Add('Z');
            set9.Add('#');

            mapList.Add(1, set1);
            mapList.Add(2, set2);
            mapList.Add(3, set3);
            mapList.Add(4, set4);
            mapList.Add(5, set5);
            mapList.Add(6, set6);
            mapList.Add(7, set7);
            mapList.Add(8, set8);
            mapList.Add(9, set9);

            PhoneDialPadUtil(arr, mapList, 1, string.Empty);
        }

        private void PhoneDialPadUtil(int[] arr, Dictionary<int, HashSet<char>> mapList, int num, string str)
        {
            
            for(int idx = 0; idx < 3; idx++)
            {
                if(num == 3)
                {
                    Console.WriteLine(string.Concat(str, mapList[num].ElementAt(idx)));
                }
                else
                {
                    PhoneDialPadUtil(arr, mapList, num +1, str + mapList[num].ElementAt(idx));
                }
            }
        }

        //Give A = 1, B = 2, C=3, print the valid combinations for 123
        public void FindCombination()
        {
            string str = "123";
        }

        private void FindcomboUtil(string str, int curIdx, HashSet<string> hashSet, string newStr, Dictionary<int, char> dict)
        {
            if(hashSet.Contains(newStr))
            {
                return;
            }

            if(curIdx +1 < str.Length)
            {
                if (10 * curIdx + (curIdx + 1) <= 26)
                {
                    newStr = FindMap(str, curIdx, curIdx + 1, dict);
                    curIdx += 1;
                    FindcomboUtil(str, curIdx, hashSet, newStr, dict);
                }
                else
                {
                    curIdx += 1;
                }
            }

            if(curIdx +2 < str.Length)
            {
                if (10 * curIdx + (curIdx + 1) <= 26)
                {
                    newStr = FindMap(str, curIdx, curIdx + 1, dict);
                    curIdx += 2;
                    FindcomboUtil(str, curIdx, hashSet, newStr, dict);
                }
                else
                {
                    curIdx += 2;
                }
            }

            return;
        }

        private string FindMap(string str, int idx1, int idx2, Dictionary<int, char> dict)
        {
            StringBuilder newStr = new StringBuilder();

            int curIdx = 0;

            while(curIdx < str.Length)
            {
                if (curIdx == idx1)
                {
                    int value1 = Convert.ToInt32(str[idx1]);
                    int value2 = Convert.ToInt32(str[idx2]);
                    int newIdx = 10 * value1 + value2;
                    newStr.Append(dict[newIdx]);
                    curIdx += 2;
                }
                else
                {
                    newStr.Append(dict[curIdx]);
                    curIdx++;
                }
            }
            return newStr.ToString();
        }

        //Give A = 1, B = 2, C=3, print the valid combinations for 123
        public void CountCombinations()
        {
            string str = "12345678";
            Console.WriteLine(CountComboUtil(str));
        }

        private int CountComboUtil(string str)
        {
            int count = 0;

            if(str.Length == 0 || str.Length == 1)
            {
                return 1;
            }

            if(str.ElementAt(str.Length-1) > 48)
            {
                count = CountComboUtil(str.Substring(0, str.Length - 1));
            }

            if (str.ElementAt(str.Length - 2) < 51  && str.ElementAt(str.Length - 2) < 51 && str.ElementAt(str.Length - 1) < 55)
            {
                count += CountComboUtil(str.Substring(0, str.Length - 2));
            }

            return count;
        }

        public void TugOfWar()
        {
            int[] arr = new int[] {2, 5, 7 , 6 };
            int minSum = int.MaxValue;
            int[] left = new int[arr.Length / 2];

            TugOfWarUtil(arr, 0, left, 0, ref minSum);
            Console.WriteLine(minSum);
        }

        private int TugOfWarUtil(int[] arr, int cur, int[] left, int ctr, ref int minSum)
        {
            int result = Int32.MaxValue;

            if(ctr == arr.Length /2)
            {
                result = GetDiff(left, arr);
                return result;
            }
            else
            {
                for(int idx = cur; idx < arr.Length; idx ++)
                {
                    left[ctr] = idx;

                    if (idx + 1 < arr.Length)
                    {
                        result = Math.Min(TugOfWarUtil(arr, idx , left, ctr + 1, ref minSum), 
                            TugOfWarUtil(arr, idx + 1, left, ctr + 1, ref minSum));
                    }

                    if(result < minSum)
                    {
                        minSum = result;
                    }
                }
            }

            return result;
        }

        private int GetDiff(int[] left, int[] arr)
        {
            int leftSum = 0;
            int rightSum = 0;
            int leftCtr = 0;

            for(int idx = 0; idx < arr.Length; idx ++)
            {
                if(leftCtr < left.Length && left[leftCtr] == idx)
                {
                    leftSum += arr[idx];
                    leftCtr++;
                }
                else
                {
                    rightSum += arr[idx];
                }
            }

            return Math.Abs(leftSum - rightSum);
        }

        public void DiffWaysToCompute()
        {
            string str = "2*3-4*5";
            var result = DiffWaysToCompute(str);

            //var result = CreDiffWaysToCompute(str, 0, 0, str.Length -1);
        }

        List<int> DiffWaysToCompute(string input)
        {
            List<int> result = new List<int>();
            int size = input.Count();
            for (int i = 0; i < size; i++)
            {
                char cur = input[i];
                if (cur == '+' || cur == '-' || cur == '*')
                {
                    // Split input string into two parts and solve them recursively
                    List<int> result1 = DiffWaysToCompute(input.Substring(0, i));
                    List<int> result2 = DiffWaysToCompute(input.Substring(i + 1));
                    foreach(int n1 in result1)
                    {
                        foreach(int n2 in result2)
                        {
                            if (cur == '+')
                                result.Add(n1 + n2);
                            else if (cur == '-')
                                result.Add(n1 - n2);
                            else
                                result.Add(n1 * n2);
                        }
                    }
                }
            }

            // if the input string contains only number
            if (! result.Any())
                result.Add(Convert.ToInt32(input));
            return result;
        }

        private List<int> CreDiffWaysToCompute(string input, int cur, int start, int end)
        {
            var result = new List<int>();

            if(start > input.Length || end < 0)
            {
                return null;
            }

            if(start != 0 && cur != 0 && (start - cur < 2))
            {
                result.Add(Operation(input, cur, start));
                return result;
            }
            else if(start != 0 && cur != 0  && (cur - end < 2))
            {
                result.Add(Operation(input, end, cur));
                return result;
            }

            if (start + 2 < input.Length)
            {
                CreDiffWaysToCompute(input, start, start + 2, end - 1);
            }

            if (start + 2 < input.Length)
            {
                CreDiffWaysToCompute(input, end, start, start + 2);
            }

            return result;
        }

        private int Operation(string str, int start, int end)
        {
            switch(str[start+1])
            {
                case '+':
                    {
                        return start + end;
                    };

                case '-':
                    {
                        return start - end;
                    };
            }

            return 0;
        }

        public void CalcMedianOfsortedArrays()
        {
            int[] arr1 = new int[] {1, 2, 3 };
            int[] arr2 = new int[] { 1 , 4, 5};
            Console.WriteLine(Median(arr1, arr2));
        }

        public double Median(int[] arr1, int[] arr2)
        {
            int low1 = 0;
            int high1 = arr1.Length - 1;

            int low2 = 0;
            int high2 = arr2.Length - 1;
            

            while (true)
            {
                if (high1 == low1)
                {
                    return (arr1[low1] + arr2[low2]) / 2;
                }

                if (high1 - low1 == 1)
                {
                    return (double)(Math.Max(arr1[low1], arr2[low2]) + Math.Min(arr1[high1], arr2[high2])) / 2;
                }

                double med1 = getMedian(arr1, low1, high1);
                double med2 = getMedian(arr2, low1, high2);
                if (med1 <= med2)
                {
                    if ((high1 - low1 + 1) % 2 == 0)
                    {
                        low1 = (high1 + low1) / 2;
                        high2 = (high2 + low2) / 2 + 1;
                    }
                    else
                    {
                        low1 = (low1 + high1) / 2;
                        high2 = (low2 + high2) / 2;
                    }
                }
                else
                {
                    if ((high1 - low1 + 1) % 2 == 0)
                    {
                        low2 = (high2 + low2) / 2;
                        high1 = (high1 + low1) / 2 + 1;
                    }
                    else
                    {
                        low2 = (low2 + high2) / 2;
                        high1 = (low1 + high1) / 2;
                    }
                }
            }
        }

        private double getMedian(int[] arr, int low, int high)
        {
            int len = high - low + 1;
            if (len % 2 == 0)
            {
                return (arr[low + len / 2] + arr[low + len / 2 - 1]) / 2;
            }
            else
            {
                return arr[low + len / 2];
            }
        }

        public void SubsetSum()
        {
            int[] arr = new int[] {0,-1, 2, -3, 1 };
            SubsetSum(arr, 0, 0, 0, new int[4]);
        }

        private void SubsetSum(int[] arr, int k, int idx, int sum, int[] map)
        {
            if(idx > arr.Length -1 || k >3)
            {
                return;
            }

            map[k] = arr[idx];

            if(k == 3)
            {
                if(sum == 0)
                {
                    for(int i=0;i<=map.Length -1; i++)
                    {
                        Console.WriteLine(map[i]);
                    }
                    Console.WriteLine("----------------");
                }
                return;
            }

            SubsetSum(arr, k + 1, idx + 1 , sum + arr[idx], map);
            SubsetSum(arr, k + 1, idx + 1, sum, map );
        }

        public void MaxSubSequence()
        {
            int[] arr = new int[] { -10, 11, 10, -10, 2, 3, -6, 1 };
            int max = 0;
            MaxSubsequenceUtil(arr, -1, 0, ref max);
            Console.WriteLine(max);
        }

        private int MaxSubsequenceUtil(int[] arr, int idx, int sum, ref int max)
        {
            if(idx > arr.Length -1)
            {
                return 0;
            }

            int res = 0;

            if(max < sum)
            {
                max = sum;
            }

            if (idx + 1 < arr.Length)
            {
                res = MaxSubsequenceUtil(arr, idx + 1, sum + arr[idx + 1], ref max);
            }

            Math.Max(max, MaxSubsequenceUtil(arr, idx + 1, sum, ref max));

            return res;
        }
    }
}