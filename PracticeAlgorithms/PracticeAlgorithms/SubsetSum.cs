using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class SubsetSum
    {
        public void subsetSums(int[] arr, int l, int r,
                int sum = 0)
        {
            // Print current subset
            if (l > r)
            {
                Console.WriteLine(sum);
                return;
            }

            // Subset including arr[l]
            subsetSums(arr, l + 1, r, sum + arr[l]);

            // Subset excluding arr[l]
            subsetSums(arr, l + 1, r, sum);
        }


        public bool CheckSubSetSumExists(int[] arr, int l, int r, int desiredSum)
        {
            return IsSubsetSum(arr, l, r, desiredSum, 0);
        }

        private bool IsSubsetSum(int[] arr, int l, int r, int desiredSum, int sum)
        {
            if (sum == desiredSum)
            {
                return true;
            }
            else if(l > r)
            {
                return false;
            }
            else
            {
                return IsSubsetSum(arr, l + 1, r, desiredSum, sum + arr[l]) ||
                    IsSubsetSum(arr, l + 1, r, desiredSum, sum);
            }
        }


        public void PrintSequenceMatchingNumber()
        {
            SolveSequenceMatchingnumber(4);
        }

        
        private void SolveSequenceMatchingnumber(int desiredSum)
        {
            int[,] dpArr = new int[2^desiredSum , desiredSum];
            int sum = 0;
            int ctr = 1;
            int level = 1;

            for(int row = 0; row < (2^desiredSum); row++)
            {
                sum = 0;
                if (row == 0 && sum < desiredSum)
                {
                    for (int col = 0; col < desiredSum; col++)
                    {
                        if (row == 0 && sum < desiredSum)
                        {
                            dpArr[row, col] = ctr;
                            sum += dpArr[row, col];
                        }
                    }

                    level++;
                }
                else
                {
                    bool result = FillRow(dpArr, row, desiredSum, level);
                    if (!result)
                    {
                        if (level < desiredSum)
                        {
                            level++;
                        }
                        break;
                    }
                }
            }
        }


        private bool FillRow(int[,] dpArr, int row, int desiredSum, int level)
        {
            int sum = 0;
            int col = 0;

            if(dpArr[row, 0] == desiredSum)
            {
                return false;
            }

            int ctr = 0;

            dpArr[row, col] = level;

            col++;

            while (sum < desiredSum || col < desiredSum)
            {
                ctr = dpArr[row - 1, col] + 1  <= level && dpArr[row - 1, col] + 1 < desiredSum ? dpArr[row - 1, col] + 1 : 0;

                if (sum + dpArr[row - 1, col] + 1 < desiredSum)
                {
                    dpArr[row, col] = ctr;
                    sum += dpArr[row, col];
                    col++;
                }
                else
                {
                    break;
                }
            }

            return true;
        }
    }
}
