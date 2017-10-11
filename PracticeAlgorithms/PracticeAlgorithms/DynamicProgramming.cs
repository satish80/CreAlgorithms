using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class DynamicProgramming
    {
        public bool IsSubSetSum(int[] arr, int desiredSum)
        {
            bool[,] dpArr = new bool[desiredSum + 1, arr.Length + 1];

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                dpArr[0, i] = true;
            }

            for (int i = 1; i <= desiredSum; i++)
                dpArr[i, 0] = false;

            for (int i = 1; i <= desiredSum; i++)
            {
                for (int j = 1; j <= arr.Length; j++)
                {
                    dpArr[i, j] = dpArr[i, j - 1];
                    if (i >= arr[j - 1])
                        dpArr[i, j] = dpArr[i, j] ||
                                              dpArr[i - arr[j - 1], j - 1];
                }
            }

            return dpArr[desiredSum, arr.Length];
        }

        public void KnapSack(int[] Val, int[] W, int desiredWeight)
        {
            Console.WriteLine(SolveKnapSackInDP(Val, W, desiredWeight));
        }

        private int SolveKnapSackInDP(int[] Val, int[] W, int desiredWeight)
        {
            int[,] knapsack = new int[Val.Length + 1, desiredWeight + 1];

            for (int i = 0; i <= Val.Length; i++)
            {
                for (int w = 0; w <= desiredWeight; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        knapsack[i, w] = 0;
                    }
                    else if (W[i - 1] <= w)
                    {
                        knapsack[i, w] = Math.Max(Val[i - 1] + knapsack[i - 1, w - W[i - 1]], knapsack[i - 1, w]);
                    }
                    else
                    {
                        knapsack[i, w] = knapsack[i - 1, w];
                    }
                }
            }

            return knapsack[Val.Length, desiredWeight];
        }

        public void HighwayBillboard()
        {
            int[] x = new int[] { 6, 7, 12, 13, 14 };
            int[] revenue = new int[] { 5, 6, 5, 3, 1 };
            int miles = 20;
            int distance = 5;

            Console.WriteLine(SolveHighwayBillboard(x, revenue, miles, distance));
        }

        private int SolveHighwayBillboard(int[] x, int[] revenue, int miles, int distance)
        {
            int[] maxRev = new int[miles];
            int revIdx = 0;

            for (int idx = 1; idx < miles; idx++)
            {
                if (x[revIdx] != idx)
                {
                    maxRev[idx] = maxRev[idx - 1];
                }
                else
                {
                    maxRev[idx] = Math.Max(
                        maxRev[idx - distance - 1] + revenue[revIdx],
                        maxRev[idx - 1]
                        );

                    if (revIdx < revenue.Length - 1)
                    {
                        revIdx++;
                    }
                }
            }

            return maxRev[miles - 1];
        }

        public void FriendsPair()
        {
            Console.WriteLine(SolveFriendsPair(4));
        }

        private int SolveFriendsPair(int n)
        {
            int[] dp = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                if (i <= 2)
                {
                    dp[i] = i;
                }
                else
                {
                    dp[i] = dp[i - 1] + (i - 1) * dp[i - 2];
                }
            }

            return dp[n];
        }

        public void ConsecutiveModulo()
        {
            int[] arr = { 1, 2, 3, 4 };

            SolveConsecutiveModulo(arr, 3);
        }

        private void SolveConsecutiveModulo(int[] arr, int k)
        {
            int len = arr.Length;
            int[,] dp = new int[len, len];

            for (int i = 0; i < len; i++)
            {
                for (int j = i; j < len; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            dp[i, j] = arr[i];
                        }
                        else
                        {
                            dp[i, j] = arr[j] + dp[i, j - 1];
                        }
                    }
                    else
                    {
                        if (j == i)
                        {
                            dp[i, j] = arr[j];
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j] - arr[i - 1];
                        }
                    }

                    if (dp[i, j] % k == 0)
                    {
                        Console.WriteLine("True: {0} ", dp[i, j]);
                    }
                }
            }
        }

        public void MatrixBoundary()
        {
            int[,] arr = new int[3, 3]
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            };

            SolveMatrixBoundary(arr);

        }

        private void SolveMatrixBoundary(int[,] arr)
        {
            int rowBounds = arr.GetLength(0) - 1;
            int colBounds = arr.GetLength(1) - 1;

            for (int i = 0; i <= rowBounds; i++)
            {
                for (int j = 0; j <= colBounds; j++)
                {
                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        arr[i, j] = arr[i, j] + arr[i, j - 1] + arr[i - 1, j] - arr[i - 1, j - 1];
                    }
                    else if (i - 1 >= 0)
                    {
                        arr[i, j] = arr[i, j] + arr[i - 1, j];
                    }
                    else if (j - 1 >= 0)
                    {
                        arr[i, j] = arr[i, j] + arr[i, j - 1];
                    }
                }
            }
        }

        public void MorseCode()
        {
            bool[,] dpArr = new bool[8, 5];
            int dSum = 5;
            int col = 0;
            int sum = 0;

            Console.WriteLine(SolveMorseCode(dSum, 4, col, sum));
        }

        //A = "." and B = "..". Find valid combinations for  "...."
        private int SolveMorseCode(int dSum, int colBounds, int col, int sum)
        {
            int result = 0;

            if (sum == dSum)
            {
                if (col == colBounds)
                {
                    col = 0;
                }

                return 1;
            }
            else
            {
                if (col < colBounds)
                {
                    result += SolveMorseCode(dSum, colBounds, col + 1, sum + 1);
                    result += SolveMorseCode(dSum, colBounds, col + 1, sum + 2);
                }
                else
                {
                    col = 0;
                }
            }
            return result;
        }

        public void Histogram()
        {
            int[] arr = new int[] { 2, 6, 5, 7, 4, 3 };

            SolveHistogram(arr);
        }

        private void SolveHistogram(int[] arr)
        {
            bool[,] dpArr = new bool[arr.Length, arr.Length];

            for (int row = 0; row <= arr.Length - 1; row++)
            {
                for (int col = 0; col <= arr.Length - 1; col++)
                {
                    if (row == 0)
                    {
                        dpArr[row, col] = arr[row] <= arr[col] ? true : false;
                    }
                    else
                    {
                        if (arr[row] <= arr[row - 1])
                        {
                            if (dpArr[row - 1, col] == true)
                            {
                                dpArr[row, col] = true;
                            }
                            else
                            {
                                dpArr[row, col] = arr[row] <= arr[col] ? true : false;
                            }
                        }
                        else
                        {
                            if (dpArr[row - 1, col] == false)
                            {
                                dpArr[row, col] = false;
                            }
                            else
                            {
                                dpArr[row, col] = arr[row] <= arr[col] ? true : false;
                            }
                        }
                    }
                }
            }
        }

        

        public void LongestPalindronomicSubsequence()
        {
            string str = "bacfad";
            Console.WriteLine(LongestPalindromicSubSequenceUtil(str));
        }

        private int LongestPalindromicSubSequenceUtil(string str)
        {
            int strLen = str.Length;
            int[,] arr = new int[strLen, strLen];

            int[,] T = new int[str.Length, str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                T[i, i] = 1;
            }

            for (int l = 2; l <= str.Length; l++)
            {
                for (int i = 0; i < str.Length - l + 1; i++)
                {
                    int j = i + l - 1;
                    if (l == 2 && str[i] == str[j])
                    {
                        T[i, j] = 2;
                    }
                    else if (str[i] == str[j])
                    {
                        T[i, j] = T[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        T[i, j] = Math.Max(T[i + 1, j], T[i, j - 1]);
                    }
                }
            }

            return T[0, str.Length - 1];
        }


        public void LCS()
        {
            string str1 = "ABCDAF";
            string str2 = "ACBCF";
            Console.WriteLine(LCSUtil(str1, str2));
        }

        private int LCSUtil(string str1, string str2)
        {
            int[,] arr = new int[str1.Length +1, str2.Length +1];

            for(int row = 0; row <= str1.Length; row ++)
            {
                for(int col = 0; col <= str2.Length; col++)
                {
                    if(row == 0 || col == 0)
                    {
                        arr[row, col] = 0;
                    }
                    else
                    {
                        if(str1[row-1] == str2[col-1])
                        {
                            arr[row, col] = 1 + arr[row-1, col-1];
                        }
                        else
                        {
                            arr[row, col] = Math.Max(arr[row-1, col], arr[row, col-1]);
                        }
                    }
                }
            }
            return arr[str1.Length, str2.Length];
        }

        public void DecodeCombinations()
        {
            string str = "01";
            Console.WriteLine(DecodeCombinationsUtil(str));
        }

        private int DecodeCombinationsUtil(string str)
        {
            if (str == "")
            {
                return 0;
            }

            if (str.Length == 1)
            {
                if (str == "0")
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            int[] arr = new int[str.Length + 1];

            arr[0] = str.ElementAt(0) > 48 ? 1 : 0;

            for (int idx = 1; idx < str.Length; idx++)
            {
                if (str.ElementAt(idx) < 51 && str.ElementAt(idx) > 48 || str.ElementAt(idx) < 55  
                    && str.ElementAt(idx - 1) < 51 && str.ElementAt(idx) > 48)
                {
                    arr[idx] = arr[idx - 1] + 1;
                }
                else
                {
                    arr[idx] = arr[idx - 1];
                }
            }


            return arr[str.Length - 1];
        }

        public void WordWrap()
        {
            string[] str = new string[4]
            {
                "aaa",
                "bb",
                "cc",
                "ddddd"
            };
            WordWrapUtil(str, 6);
        }

        private int WordWrapUtil(string[] str, int maxPerLine)
        {
            Dictionary<int, KeyValuePair<int, Tuple<int,int>>[]> arr = new Dictionary<int, KeyValuePair<int, Tuple<int, int>>[]>();

            int firstBalance = maxPerLine - str[0].Length -1;
            var tuple1 = new Tuple<int, int>(firstBalance, 27);
            var tuple2 = new Tuple<int, int>(-1, -1);
            var tuple3 = new Tuple<int, int>(-1, -1);
            var tuple4 = new Tuple<int, int>(-1, -1);

            var valuePair = new KeyValuePair<int, Tuple<int, int>>(0, tuple1);
            KeyValuePair <int, Tuple<int, int>>[] valuePairs = new KeyValuePair<int, Tuple<int, int>>[str.Length];

            valuePairs[0] = valuePair;
            valuePair = new KeyValuePair<int, Tuple<int, int>>(1, tuple2);
            valuePairs[1] = valuePair;
            valuePair = new KeyValuePair<int, Tuple<int, int>>(2, tuple3);
            valuePairs[2] = valuePair;
            valuePair = new KeyValuePair<int, Tuple<int, int>>(3, tuple4);
            valuePairs[3] = valuePair;

            arr[0] = valuePairs;

            int rowMin = 0;
            int balance = 0;
            int total = 27;

            for (int row = 1; row < str.Length; row ++)
            {
                bool rowMinAssigned = false;
                var rowPairs = new KeyValuePair<int, Tuple<int, int>>[str.Length];
                arr.Add(row, rowPairs);

                for (int col = 0; col <= row; col ++)
                {
                    var prevRowValuePair = (KeyValuePair < int, Tuple< int, int>>)arr[row - 1].GetValue(col);
                    var prevColTuple = prevRowValuePair.Value;

                    if (prevColTuple == null || prevColTuple.Item1 == -1)
                    {
                        balance = maxPerLine - str[row].Length - 1;
                        var curColTuple = new Tuple<int, int>(balance, Convert.ToInt32(Math.Pow(balance + 1, 3)));
                        var curColKeyValuePair = new KeyValuePair<int, Tuple<int, int>>(col, curColTuple);
                        rowPairs[col] = curColKeyValuePair;
                    }
                    else if (prevColTuple.Item1 == 0)
                    {
                        var curColTuple = new Tuple<int, int>(0, 0);
                        var curColKeyValuePair = new KeyValuePair<int, Tuple<int, int>>(col, curColTuple);
                        rowPairs[col] = curColKeyValuePair;
                    }
                    else if (prevColTuple.Item1 >= str[row].Length)
                    {
                        balance = prevColTuple.Item1 - str[row].Length;
                        var curColTuple = new Tuple<int, int>(balance, Convert.ToInt32(Math.Pow(balance, 3)));
                        var curColKeyValuePair = new KeyValuePair<int, Tuple<int, int>>(col, curColTuple);
                        rowPairs[col] = curColKeyValuePair;
                    }

                    if(!rowMinAssigned)
                    {
                        rowMin = balance;
                        rowMinAssigned = true;
                    }
                    else
                    {
                        rowMin = rowMin >= balance ? balance : rowMin;
                    }
                }

                total += rowMin;
            }
            return total;
        }

        public void LCSMyImpl()
        {
            string str1 = "ABCDGH";
            string str2 = "AEDFHR";
            LCSMyImpl(str1, str2);
        }

        private void LCSMyImpl(string str1, string str2)
        {
            if(str1 == null || str2 == null)
            {
                throw new Exception("Input param can't be null");
            }

            int[,] arr = new int[str1.Length, str2.Length];

            for(int row = 0; row < str1.Length; row ++)
            {
                for(int col = 0; col < str2.Length; col++)
                {
                    if(str1[col] == str2[row])
                    {
                        if (row == 0)
                        {
                            arr[row, col] = 1;
                        }
                        else if(col == 0)
                        {
                            arr[row, col] = arr[row - 1, col] + 1;
                        }
                        else
                        {
                            arr[row, col] = Math.Max(arr[row - 1, col], arr[row , col - 1]) + 1;
                        }

                        Console.WriteLine(str1[row]);
                    }
                    else
                    {
                        if (row == 0)
                        {
                            arr[row, col] = arr[row, col - 1];
                        }
                        else if(row > 0 && col ==0)
                        {
                            arr[row, col] = arr[row - 1, col];
                        }
                        else
                        {
                            arr[row, col] = Math.Max(arr[row - 1, col], arr[row, col - 1]);
                        }
                    }
                }
            }

            Console.WriteLine("creLCS is {0}", arr[str1.Length-1, str2.Length-1]);
        }

        public void LongestPalindromicSubstring()
        {
            Console.WriteLine(LongestPalindromicSubstring("aaabaaaa"));
        }

        private string LongestPalindromicSubstring(string str)
        {
            StringBuilder result = new StringBuilder();
            Tuple<int, int> details = null;
            
            int maxLength = 0;

            if(string.IsNullOrEmpty(str))
            {
                return result.ToString();
            }
            else if(str.Length == 1)
            {
                return str;
            }
            else
            {
                int[,] arr = new int[str.Length, str.Length];

                for(int col = 0; col < str.Length ; col++)
                {
                    arr[col, col] = 1;
                }

                for(int row = str.Length -2; row >= 0; row --)
                {
                    for(int col = str.Length -1; col > row ; col--)
                    {
                        if(str[row] == str[col])
                        {
                            var response = FillMatch(arr, row, ref col, ref maxLength);
                            if(response != null)
                            {
                                details = response;
                            }
                        }
                    }
                }
            }

            if(details!= null)
            {
                int idx = details.Item1;
                int count = details.Item2;
                
                while(count > 0 )
                {
                    result.Append(str[idx--]);
                    count--;
                }
            }
            return result.ToString();
        }

        private Tuple<int,int> FillMatch(int[,] arr, int row, ref int col, ref int maxLength)
        {
            int count = 1;
            int initialCol = col;
            Tuple<int, int> result = null;

            arr[row, col] = 1;
            col -= 1;

            while(col >=0 && (arr[row+1, col] == 1 || arr[row, col] == 1))
            {
                arr[row, col] = 1;
                col--;
                count++;
            }

            if(maxLength < count)
            {
                maxLength = count;
                result = new Tuple<int, int>(initialCol, maxLength);
            }

            return result;
        }

        public void CreLCS()
        {
            string str1 = "AEDFHR";
            string str2 = "ABCDGH";
            Console.WriteLine(CreLCS(str1, str2));
        }

        private int CreLCS(string str1, string str2)
        {
            if(string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                return 0;
            }

            int[,] arr = new int[str1.Length, str2.Length];

            for(int row = 0; row < str1.Length; row++)
            {
                for(int col = 0; col < str2.Length; col ++)
                {
                    if(str1[row] == str2[col])
                    {
                        if(row > 0)
                        {
                            arr[row, col] = arr[row - 1, col] + 1;
                        }
                        else
                        {
                            arr[row, col] = 1;
                        }
                    }
                    else
                    {
                        if (row > 0 && col > 0)
                        {
                            arr[row, col] = Math.Max(arr[row, col-1], arr[row - 1, col]);
                        }
                        else if(row == 0 && col > 0)
                        {
                            arr[row, col] = arr[row, col - 1];
                        }
                    }
                }
            }

            return arr[str1.Length -1 , str2.Length -1];
        }

        public void MinCoinsNeeded()
        {
            int[] arr = new int[] { 7, 2, 3, 6};
            int count = 0;

            Console.WriteLine(MinCoinsNeeded(arr, 13, 0, new Dictionary<string, int>(), ref count));
        }

        private int MinCoinsNeeded(int[] arr, int dSum, int idx, Dictionary<string, int> memo, ref int count)
        {
            string key = arr[idx] + "-" + idx;
            if(dSum == 0)
            {
                memo[key] = count;
                return 1;
            }

            if(dSum < 0 || idx > arr.Length)
            {
                return 0;
            }

            //if(memo.ContainsKey(key))
            {
              //  return memo[key];
            }

            int result = MinCoinsNeeded(arr, dSum - arr[idx], idx, memo, ref count);

            if(count > result)
            {
                count = result;
            }

            if (idx + 1 < arr.Length)
            {
                result = MinCoinsNeeded(arr, dSum - arr[idx + 1], idx + 1, memo, ref count);
            }

            return result;
        }

        //
        public void LargestSubArraySum()
        {
            int[] arr = new int[] {-4, -2, 1, -3 };

            Console.WriteLine(LargestSubArraySum(arr));
        }

        private int LargestSubArraySum(int[] arr)
        {
            int[,] dp = new int[arr.Length, arr.Length];
            int sum = arr[0];
            int row = 1;
            int maxSum = arr[0];
            dp[0, 0] = arr[0];

            for (int idx = 1; idx < arr.Length; idx ++)
            {
                sum += arr[idx];
                dp[0, idx] = sum;

                if(maxSum < sum)
                {
                    maxSum = sum;
                }
            }

            while (row < arr.Length)
            {
                for (int idx = row + 1; idx < arr.Length; idx++)
                {
                    dp[row, idx] = dp[row - 1, idx] - arr[row - 1];

                    if (dp[row, idx] > maxSum)
                    {
                        maxSum = dp[row, idx];
                    }
                }
                row++;
            }

            return maxSum;
        }

        //Longest Increasing Subsequence
        public void LIS()
        {
            int[] arr = new int[] { 7, 25, 23, 0, 24, 50, 4, 60 };

            Console.WriteLine(LIS(arr));
        }

        private int LIS(int[] arr)
        {
            int[] dpArr = new int[arr.Length];

            for(int row= 0; row < arr.Length; row ++)
            {
                dpArr[row] = 1;
            }

            for(int row = 1; row < arr.Length; row ++)
            {
                for(int col = 0; col < row; col ++)
                {
                    if(arr[row] >= arr[col])
                    {
                        dpArr[row] = Math.Max(dpArr[col] +1, dpArr[row]);
                    }
                }
            }

            return dpArr[arr.Length - 1];
        }

        public void EditDistance()
        {
            string str1 = "cat";
            string str2 = "cut";
            Console.WriteLine(EditDistance(str1, str2));
        }

        private int EditDistance(string str1, string str2)
        {
            if(string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                return 0;
            }

            int[,] dpMap = new int[str1.Length + 1, str2.Length + 1];

            for(int row = 1; row <= str1.Length; row ++)
            {
                for(int col = 1; col <= str2.Length; col++)
                {
                    if(str1[row-1] == str2[col-1])
                    {
                        dpMap[row, col] = dpMap[row - 1, col - 1];
                    }
                    else
                    {
                        if (row - 1 > 0 && col-1 > 0)
                        {
                            dpMap[row, col] = 1 + dpMap[row - 1, col - 1];
                        }
                        else if(row-1 == 0 && col-1 > 0)
                        {
                            dpMap[row, col] = 1 + dpMap[row, col - 1];
                        }
                        else
                        {
                            dpMap[row, col] = 1;
                        }
                    }
                }
            }

            return dpMap[str1.Length, str2.Length];
        }
    }
}
