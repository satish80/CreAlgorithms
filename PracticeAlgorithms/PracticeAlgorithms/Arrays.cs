using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class Arrays
    {
        public bool ValidateParanthesis(char[] arr)
        {
            bool result = false;
            if (arr.Length == 0)
            {
                return true;
            }
            else if (arr[0] == ')' || arr.Length % 2 != 0)
            {
                return false;
            }
            else
            {
                Stack<char> paranStk = new Stack<char>();
                int idx = 0;

                while (idx < arr.Length)
                {
                    if (arr[idx] == '(')
                    {
                        paranStk.Push('(');
                    }
                    else
                    {
                        if (paranStk.Count > 0)
                        {
                            paranStk.Pop();
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                    idx++;
                }
                result = paranStk.Count == 0 && idx == arr.Length ? true : false;
            }
            return result;
        }


        public void CountValidParanthesisCombo(char[] arr, int arrlength)
        {
            int count = 0;
            CountParanCombo(arr, arrlength, 0, ref count);
            Console.WriteLine("Count of valid paran is {0}", count);
        }

        private void CountParanCombo(char[] arr, int length, int pos, ref int count)
        {
            if (pos > length - 1)
            {
                bool result = ValidateParanthesis(arr);
                count = result == true ? count + 1 : count;
                return;
            }
            else
            {
                arr[pos] = '(';

                CountParanCombo(arr, length, pos + 1, ref count);

                arr[pos] = ')';

                CountParanCombo(arr, length, pos + 1, ref count);
            }
        }

        public void FindMatrixSol()
        {
            char[,] arr = new char[3, 3]
            {
                { 'B','R', 'E' },
                {'B', 'B', 'R' },
                {'R', 'B', 'E' }
            };

            Console.WriteLine(FindMazeSol(arr, 0, 0));
        }

        private bool FindMazeSol(char[,] arr, int x, int y)
        {
            if (x > arr.GetUpperBound(0) || y > arr.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                if (arr[x, y] == 'E')
                {
                    return true;
                }
                else if (arr[x, y] == 'R')
                {
                    return false;
                }
                else
                {
                    return FindMazeSol(arr, x, y + 1) ||
                        FindMazeSol(arr, x + 1, y) ||
                        FindMazeSol(arr, x, y - 1) ||
                        FindMazeSol(arr, x - 1, y);
                }
            }
        }

        public void MaxHeap()
        {
            int[] arr = new int[] { 5, 12, 64, 1, 37, 90, 91, 97 };
            MaxHeap(arr);

        }

        private void MaxHeap(int[] arr)
        {
            int curIdx = arr.Length / 2 - 1;
            int left;
            int right;
            int temp;

            while (curIdx >= 0)
            {
                left = (curIdx + 1) * 2 - 1;
                right = (curIdx + 1) * 2;

                if (left <= arr.Length - 1)
                {
                    if (arr[curIdx] < arr[left])
                    {
                        temp = arr[curIdx];
                        arr[curIdx] = arr[left];
                        arr[left] = temp;
                    }
                }

                if (right <= arr.Length - 1)
                {
                    if (arr[curIdx] < arr[right])
                    {
                        temp = arr[curIdx];
                        arr[curIdx] = arr[right];
                        arr[right] = temp;
                    }
                }

                curIdx--;
            }
        }

        public void PrintMatchIndex()
        {
            HashSet<string> map = new HashSet<string>();
            map.Add("foo");
            map.Add("bar");

            string str = "foobarxyfoobara";

            PrintMatchIdx(map, str);

        }

        private void PrintMatchIdx(HashSet<string> givenMap, string str)
        {
            HashSet<string> map = new HashSet<string>(givenMap);

            int curIdx = 0;
            for (int idx = 0; idx <= str.Length - 1; idx++)
            {
                curIdx = idx;
                if (SatisfyRule(map, str, ref idx))
                {
                    Console.WriteLine("At index {0}", curIdx);
                }
                map = new HashSet<string>(givenMap);
            }
        }

        private bool SatisfyRule(HashSet<string> map, string str, ref int idx)
        {
            int wordLen = map.First().Length;
            int matchLen = wordLen * map.Count;
            int count = 0;

            while (count <= matchLen - 1)
            {
                string temp = str.Substring(idx, wordLen);

                if (map.Contains(temp))
                {
                    map.Remove(temp);
                    count += wordLen;
                    idx += wordLen;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public void FindLongestPathInMatrix()
        {
            int[,] arr = new int[3, 3]
            {
                { 3, 2, 1},
                { 4, 5, 6},
                { 5, 6, 7}
            };

            int[,] dpArr = new int[arr.GetLongLength(0), arr.GetLongLength(1)];
            int result = 0;

            for (int row = 0; row <= arr.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= arr.GetUpperBound(1); col++)
                {
                    SolveLongestPathInMatrix(arr, row, col, arr[row, col], dpArr);

                    result = Math.Max(result, dpArr[row, col]);
                }
            }

            Console.WriteLine(result);
        }

        private int SolveLongestPathInMatrix(int[,] arr, int row, int col, int prev, int[,] dpArr)
        {
            if (row < 0 || col < 0 || row > arr.GetUpperBound(0) || col > arr.GetUpperBound(1))
            {
                return 0;
            }

            if (dpArr[row, col] > 0)
            {
                return dpArr[row, col];
            }

            if (col < arr.GetUpperBound(1) && arr[row, col] + 1 == arr[row, col + 1])
            {
                dpArr[row, col] = 1 + SolveLongestPathInMatrix(arr, row, col + 1, arr[row, col], dpArr);
                return dpArr[row, col];
            }

            if (row < arr.GetUpperBound(0) && arr[row, col] + 1 == arr[row + 1, col])
            {
                return dpArr[row, col] = 1 + SolveLongestPathInMatrix(arr, row + 1, col, arr[row, col], dpArr);
            }

            if (col > 0 && arr[row, col] + 1 == arr[row, col - 1])
            {
                return dpArr[row, col] = 1 + SolveLongestPathInMatrix(arr, row, col - 1, arr[row, col], dpArr);
            }

            if (row > 0 && arr[row, col] + 1 == arr[row - 1, col])
            {
                return dpArr[row, col] = 1 + SolveLongestPathInMatrix(arr, row - 1, col, arr[row, col], dpArr);
            }

            return dpArr[row, col] = 1;
        }

        public void TrapWater()
        {
            int[] arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            Console.WriteLine(SolveTrapWater(arr));
        }

        public int SolveTrapWater(int[] arr)
        {
            int idx = 0;

            List<int> trpList = new List<int>();
            int trapCount = 0;

            int leftIdx = 0;
            int rightIdx = 1;
            idx = 1;

            while (idx <= arr.Length - 1)
            {
                if (arr[idx] >= arr[leftIdx])
                {
                    if (trpList.Count > 0)
                    {
                        trapCount += FindTrapWater(arr, trpList, leftIdx, rightIdx);
                        trpList.Clear();
                    }

                    leftIdx = rightIdx = idx;
                }
                else
                {
                    rightIdx = idx;
                    trpList.Add(arr[idx]);
                }

                idx++;
            }

            while (trpList.Count > 0)
            {
                trapCount += TrapEndMarker(arr, trpList, ref leftIdx, ref rightIdx);
            }

            return trapCount;
        }

        private int FindTrapWater(int[] arr, List<int> trpList, int leftIdx, int rightIdx)
        {
            int trapCount = 0;
            int top = arr[leftIdx];

            foreach (int trp in trpList)
            {
                trapCount += top - trp;
            }

            return trapCount;
        }

        private int TrapEndMarker(int[] arr, List<int> trpList, ref int leftIdx, ref int rightIdx)
        {
            leftIdx++;
            int idx = 1;
            int trapCount = 0;
            List<int> endList = new List<int>();

            while (idx < trpList.Count && leftIdx < arr.Length - 1)
            {
                if (trpList[idx] >= arr[leftIdx])
                {
                    trapCount += FindTrapWater(arr, endList, leftIdx, rightIdx);
                    trpList.RemoveRange(0, idx + 1);
                    endList.Clear();

                    if (idx <= trpList.Count)
                    {
                        leftIdx++;
                    }
                }
                else
                {
                    endList.Add(trpList[idx]);
                    rightIdx = idx;
                }

                idx++;
            }

            trpList.Clear();
            return trapCount;
        }


        public void findFriendGrp()
        {
            int[,] friendsMap = new int[3, 3]
            {
                {1, 1, 0},
                {1, 1,  0},
                {0, 0, 1}
            };

            Console.WriteLine(FriendsGrp(friendsMap));
        }

        private int FriendsGrp(int[,] friendsMap)
        {
            List<HashSet<int>> set = new List<HashSet<int>>();

            for (int row = 0; row <= friendsMap.GetUpperBound(0); row++)
            {
                HashSet<int> existingGrp = null;
                for (int col = row; col <= friendsMap.GetUpperBound(1); col++)
                {
                    bool newGrp = true;
                    bool exFriend = true;

                    if (friendsMap[row, col] == 1)
                    {
                        foreach (HashSet<int> grp in set)
                        {
                            if (row == col)
                            {
                                if (grp.Contains(col))
                                {
                                    newGrp = false;
                                    existingGrp = grp;
                                    break;
                                }
                            }
                            else
                            {
                                if (grp.Contains(col))
                                {
                                    exFriend = false;
                                    newGrp = false;
                                    break;
                                }
                            }
                        }

                        if (newGrp || (row == 0 && col == 0))
                        {
                            var newGroup = new HashSet<int>();
                            newGroup.Add(col);
                            set.Add(newGroup);
                            existingGrp = newGroup;
                        }
                        else if (exFriend && existingGrp != null)
                        {
                            existingGrp.Add(col);
                            exFriend = false;
                        }
                    }
                }
            }

            return set.Count;
        }

        public void IsValidBraces()
        {
            string str = "{[()]";

            Console.WriteLine(IsValidBrace(str));
        }

        private bool IsValidBrace(string str)
        {
            if (str.Length % 2 != 0)
            {
                return false;
            }

            Stack<char> stk = new Stack<char>();
            int idx = 0;

            while (!iSClosingBrace(str[idx]))
            {
                stk.Push(str[idx++]);
            }

            while (stk.Count > 0)
            {
                if (str[idx++] != GetClosingBrace(stk.Pop()))
                {
                    return false;
                }
            }

            return true;
        }

        private char GetClosingBrace(char openingBrace)
        {
            switch (openingBrace)
            {
                case '{':
                    {
                        return '}';
                    }
                case '(':
                    {
                        return ')';
                    }
                case '[':
                    {
                        return ']';
                    }
                default:
                    {
                        throw new Exception("Not a valid brace");
                    }
            }
        }

        private bool iSClosingBrace(char brace)
        {
            if (brace == '{' || brace == '[' || brace == '(')
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void FibonacciSubset()
        {
            int[] arr = { 0, 2, 8, 5, 2, 1, 4, 13, 23 };
            FibonacciSubsetUtil(arr);
        }

        private void FibonacciSubsetUtil(int[] arr)
        {
            HashSet<int> fibo = new HashSet<int>();

            int idx = 0;

            while (idx < arr.Length)
            {
                if (fibo.Count == 0 || arr[idx] > fibo.Last())
                {
                    bool fiboPresent = FindOrAddFibo(arr, arr[idx], fibo);

                    if (fiboPresent)
                    {
                        Console.WriteLine(arr[idx]);
                    }
                }
                else
                {
                    if (fibo.Contains(arr[idx]))
                    {
                        Console.WriteLine(arr[idx]);
                    }
                }

                idx++;
            }
        }

        private bool FindOrAddFibo(int[] arr, int num, HashSet<int> fibo)
        {
            if (num == 0 || num == 1)
            {
                return true;
            }

            if (fibo.Count == 0)
            {
                fibo.Add(1);
                fibo.Add(2);
            }

            int prevFibo = fibo.ElementAt(fibo.Count - 2);
            int lastFibo = fibo.ElementAt(fibo.Count - 1);

            while (lastFibo <= num)
            {
                int temp = lastFibo;

                lastFibo = prevFibo + lastFibo;
                prevFibo = temp;
                fibo.Add(lastFibo);

                if (lastFibo == num)
                {
                    return true;
                }
            }
            return false;
        }

        public void FindLoopInArray()
        {
            int[] arr = new int[] { 1, 1, 3 };
            Console.WriteLine(FindLoopInArrayUtil(arr));
        }

        private bool FindLoopInArrayUtil(int[] arr)
        {
            HashSet<int> hash = new HashSet<int>();

            int curIdx = 0;

            while (curIdx <= arr.Length - 1)
            {
                if (hash.Contains(curIdx))
                {
                    return true;
                }
                else
                {
                    hash.Add(curIdx);
                    curIdx += arr[curIdx];

                    if (curIdx > arr.Length - 1 && curIdx % (arr.Length - 1) > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void FindMinMutationCount()
        {
            string start = "AACCGGTT";
            string end = "AAACGGTA";
            HashSet<string> hash = new HashSet<string>();
            hash.Add("AACCGGTA");
            hash.Add("AACCGCTA");
            hash.Add("AAACGGTA");

            //string start = "ABCD";
            //string end = "ACBD";
            //HashSet<string> hash = new HashSet<string>();
            //hash.Add("ABDD");
            //hash.Add("ACDD");
            //hash.Add("BCDD");
            //hash.Add("ABBD");
            //hash.Add("ACBD");

            Console.WriteLine(MinMutationCountUtil(start, end, hash));
        }

        private int MinMutationCountUtil(string start, string end, HashSet<string> hash)
        {
            Dictionary<int, List<string>> rowCount = new Dictionary<int, List<string>>();
            int endCount = -1;
            int row = 0; int diff = 0; int endRow = -1;

            foreach (string strHash in hash)
            {
                diff = 0;
                for (int col = 0; col < strHash.Length; col++)
                {
                    if (start[col] != strHash[col])
                    {
                        diff += 1;
                    }
                }

                if (strHash == end)
                {
                    endCount = diff;
                    endRow = row;
                }

                if (rowCount.ContainsKey(diff))
                {
                    rowCount[diff].Add(strHash);
                }
                else
                {
                    var list = new List<string>();
                    list.Add(strHash);
                    rowCount.Add(diff, list);
                }
            }

            HashSet<string> visited = new HashSet<string>();
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();

            return MinEditDist(1, 0, visited, rowCount, start, end, 0);
        }

        private int MinEditDist(int curLevel, int prevLevel, HashSet<string> visited, Dictionary<int, List<string>> dict,
            string cur, string end, int dist)
        {
            int result = int.MaxValue;
            int Editdist = 0;
            bool isPath = false;

            //if(visited.Contains(cur))
            //{
            //    return 0;
            //}

            visited.Add(cur);

            if (end == cur)
            {
                return dist + 1;
            }
            else if (curLevel > dict.Count)
            {
                return 0;
            }
            else
            {
                for (int level = curLevel; level <= dict.Count; level++)
                {
                    foreach (string str in dict[level])
                    {
                        if (OneEditDistance(cur, str))
                        {
                            cur = str;
                            Editdist = MinEditDist(level + 1, level, visited, dict, cur, end, dist + 1);
                            isPath = true;
                        }
                    }

                    if (!isPath && level - prevLevel > 1)
                    {
                        return 0;
                    }

                    if (level + 1 <= dict.Count)
                    {
                        Editdist = MinEditDist(level + 1, level, visited, dict, cur, end, dist + 1);
                    }

                    if (Editdist < result)
                    {
                        result = Editdist;
                    }
                }
            }

            return result;
        }

        private bool OneEditDistance(string start, string end)
        {
            int count = 0;
            int min = start.Length > end.Length ? end.Length : start.Length;
            int idx = 0;
            while (idx < min)
            {
                if (start[idx] != end[idx])
                {
                    count++;

                    if (count > 1)
                    {
                        return false;
                    }
                }
                idx++;
            }
            return true;
        }

        public void PlantFlowers()
        {
            int[] arr = new int[] { 0, 0, 1, 0, 0 };
            Console.WriteLine(PlantFlowersUtil(arr, 1));
        }

        private bool PlantFlowersUtil(int[] arr, int noOfflowers)
        {
            int ctr = 0;

            if (arr.Length == 0)
            {
                if (arr[0] == 0 && noOfflowers == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            while (ctr < arr.Length && noOfflowers > 0)
            {
                if (arr[ctr] == 1)
                {
                    ctr += 2;
                    continue;
                }

                if (ctr + 1 < arr.Length)
                {
                    if (arr[ctr] == 0 && arr[ctr + 1] == 0)
                    {
                        arr[ctr] = 1;
                        ctr += 2;
                        noOfflowers--;
                    }
                    else
                    {
                        ctr++;
                    }
                }
                else if (ctr == arr.Length - 1 && arr[ctr] == 0)
                {
                    arr[ctr] = 1;
                    noOfflowers--;
                    ctr++;
                }
                else
                {
                    break;
                }
            }

            return noOfflowers == 0 ? true : false;
        }

        public void FindUnique()
        {
            int[] arr = new int[] { 0, 0, 1, 1, 2, 2, 4, 5, 5 };
            Console.WriteLine(FindUniqueUtil(arr, 0, arr.Length - 1));
        }

        private int FindUniqueUtil(int[] arr, int start, int end)
        {
            int res = -1;

            if (Math.Abs(start - end) == 2)
            {
                if (arr[start] == arr[start + 1])
                {
                    return arr[end];
                }
                else
                {
                    return arr[start];
                }
            }

            int mid = (start + end) / 2;

            if (res == -1)
            {
                if (arr[mid] == arr[mid + 1])
                {
                    if ((end - mid + 1) % 2 != 0)
                    {
                        start = mid + 2;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
                else if (arr[mid] == arr[mid - 1])
                {
                    if ((mid - start + 1) % 2 != 0)
                    {
                        end = mid - 2;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }

                res = FindUniqueUtil(arr, start, end);
            }

            return res;
        }

        public void PlaceHeight()
        {
            var valuePair1 = new KeyValuePair<int, int>(5, 0);
            var valuePair2 = new KeyValuePair<int, int>(4, 3);
            var valuePair3 = new KeyValuePair<int, int>(7, 0);
            var valuePair4 = new KeyValuePair<int, int>(6, 1);
            var valuePair5 = new KeyValuePair<int, int>(7, 1);

            var input = new List<KeyValuePair<int, int>>();
            input.Add(valuePair1);
            input.Add(valuePair2);
            input.Add(valuePair3);
            input.Add(valuePair4);
            input.Add(valuePair5);

            PlaceHeightUtil(input);
        }

        private void PlaceHeightUtil(List<KeyValuePair<int, int>> input)
        {
            var output = new Dictionary<int, List<KeyValuePair<int, int>>>();

            input.Sort(Comparer);

            HeightUtil heightStruct = new HeightUtil(-1, -1, 0);
            int idx = 0;

            while (input.Count > 0)
            {
                while (idx < input.Count)
                {
                    int key = input[idx].Key;
                    int value = input[idx].Value;

                    if (SatisfyHeightRule(heightStruct, key, value, output))
                    {
                        if (key < heightStruct.Short || heightStruct.Short == -1)
                        {
                            heightStruct.Short = key;
                        }

                        if (key > heightStruct.Tall || heightStruct.Tall == -1)
                        {
                            heightStruct.Tall = key;
                        }

                        heightStruct.Size += 1;
                        if (output.ContainsKey(key))
                        {
                            output[key].Add(input[idx]);
                        }
                        else
                        {
                            var newList = new List<KeyValuePair<int, int>>();
                            newList.Add(input[idx]);
                            output[key] = newList;

                        }

                        input.RemoveAt(idx);
                        idx = 0;
                    }
                    else
                    {
                        idx++;
                    }
                }
            }
        }

        private int Comparer(KeyValuePair<int, int> a, KeyValuePair<int, int> b)
        {
            return a.Key.CompareTo(b.Key);
        }

        public bool SatisfyHeightRule(HeightUtil heightStruct, int inputKey, int inputValue,
            Dictionary<int, List<KeyValuePair<int, int>>> output)
        {
            int ctr = 0;
            if (inputValue > 0)
            {
                foreach (int key in output.Keys)
                {
                    if (key >= inputKey)
                    {
                        foreach (KeyValuePair<int, int> valuePair in output[key])
                        {
                            inputValue--;
                        }
                        ctr++;
                    }
                }
            }

            if (inputValue > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void IsAnagram()
        {
            string str1 = "abcd";
            string str2 = "abce";
            Console.WriteLine(AreAnagrams(str1, str2));
        }

        private bool AreAnagrams(string str1, string str2)
        {
            int[] arr1 = new int[26];
            int[] arr2 = new int[26];

            if (str1.Length != str2.Length)
            {
                return false;
            }

            int offset = 'a';
            int value = -1;
            for (int idx = 0; idx < str1.Length; idx++)
            {
                //arr[idx] = 
                value = str1[idx] - offset;
                arr1[value]++;

                value = str2[idx] - offset;
                arr2[value]++;
            }

            for (int idx = 0; idx < 26; idx++)
            {
                if (arr1[idx] != arr2[idx])
                {
                    return false;
                }
            }
            return true;
        }

        public void AppendZero()
        {
            int[] arr = new int[] { 0 };
            AppendZeroUtil(arr);
        }

        private void AppendZeroUtil(int[] arr)
        {
            int cur = 0;
            int spot = 0;
            int count = 0;

            while (spot < arr.Length - count)
            {
                if (arr[cur] == 0)
                {
                    count++;
                    cur++;
                    continue;
                }
                else
                {
                    arr[spot++] = arr[cur++];
                }
            }

            for (int idx = spot; idx < arr.Length; idx++)
            {
                arr[idx] = 0;
            }
        }

        //Wrong Solution proposed in LeetCode. Do not refer
        public void FirstMissingPositive()
        {
            int[] arr = new int[] { 11, 9, 12, };
            Console.WriteLine(firstMissingPositive(arr));
        }

        private int firstMissingPositive(int[] A)
        {
            int i = 0;
            while (i < A.Length)
            {
                if (A[i] == i + 1 || A[i] <= 0 || A[i] > A.Length)
                {
                    i++;
                }
                else if (A[A[i] - 1] != A[i])
                {
                    swap(A, i, A[i] - 1);
                }
                else
                {
                    i++;
                }
            }

            i = 0;

            while (i < A.Length && A[i] == i + 1)
            {
                i++;
            }

            return i + 1;
        }

        private void swap(int[] A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        public void SnakeNLadder()
        {
            int[] moves = new int[] { 1, 1, 1, 1, 1, 1, 8, 1, 1 };

            Console.WriteLine(SnakeNLadder(moves));
        }

        private int SnakeNLadder(int[] moves)
        {
            bool[] Visited = new bool[moves.Length + 2];
            Queue<SnakeEntry> queue = new Queue<SnakeEntry>();

            var entry = new SnakeEntry()
            {
                Vertex = 0,
                Distance = 0
            };

            queue.Enqueue(entry);
            Visited[0] = true;
            while (queue.Count > 0)
            {
                entry = queue.Dequeue();
                int Vertex = entry.Vertex;

                if (Vertex == moves.Length - 1)
                {
                    break;
                }

                for (int idx = Vertex + 1; idx <= Vertex + 6 && idx < moves.Length; idx++)
                {
                    if (!Visited[idx])
                    {
                        Visited[idx] = true;
                        var newEntry = new SnakeEntry();
                        newEntry.Distance = entry.Distance + 1;

                        if (moves[idx - 1] == 1)
                        {
                            newEntry.Vertex = idx + 1;
                            queue.Enqueue(newEntry);
                        }
                        else if (moves[idx - 1] > 1)
                        {
                            newEntry.Vertex = moves[idx - 1];
                            queue.Enqueue(newEntry);
                        }
                    }
                }
            }

            return entry.Distance;
        }

        public void Histogram()
        {
            int[] hist = new int[] { 6, 2, 5, 4, 5, 1, 6 };

            Console.WriteLine(Histogram(hist));
        }

        private int Histogram(int[] hist)
        {
            int n = hist.Length;

            Stack<int> s = new Stack<int>();

            int max_area = 0; // Initalize max area
            int tp;  // To store top of stack
            int area_with_top; // To store area with top bar as the smallest bar

            // Run through all bars of given histogram
            int i = 0;
            while (i < n)
            {
                // If this bar is higher than the bar on top stack, push it to stack
                if (s.Count == 0 || hist[s.Peek()] <= hist[i])
                    s.Push(i++);

                // If this bar is lower than top of stack, then calculate area of rectangle 
                // with stack top as the smallest (or minimum height) bar. 'i' is 
                // 'right index' for the top and element before top in stack is 'left index'
                else
                {
                    tp = s.Pop();  // store the top index

                    // Calculate the area with hist[tp] stack as smallest bar
                    area_with_top = hist[tp] * (s.Count == 0 ? i : i - s.Peek() - 1);

                    // update max area, if needed
                    if (max_area < area_with_top)
                        max_area = area_with_top;
                }
            }

            // Now pop the remaining bars from stack and calculate area with every
            // popped bar as the smallest bar
            while (s.Count > 0)
            {
                tp = s.Pop();
                area_with_top = hist[tp] * (s.Count == 0 ? i : i - s.Peek() - 1);

                if (max_area < area_with_top)
                    max_area = area_with_top;
            }

            return max_area;

        }

        public void WaterTrap()
        {
            int[] arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Console.WriteLine(WaterTrapUtil(arr));
        }

        private int WaterTrapUtil(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            int res = 0;
            int[] left = new int[arr.Length];
            int[] right = new int[arr.Length];

            for (int idx = 1; idx < arr.Length; idx++)
            {
                left[idx] = Math.Max(left[idx - 1], arr[idx]);
            }

            right[arr.Length - 1] = arr[arr.Length - 1];

            for (int idx = arr.Length - 2; idx >= 0; idx--)
            {
                right[idx] = Math.Max(right[idx + 1], arr[idx]);
            }

            for (int idx = 0; idx < arr.Length; idx++)
            {
                res += Math.Min(right[idx], left[idx]) - arr[idx];
            }

            return res;

        }

        public void AnagramIndicesList()
        {
            string str1 = "hayeneledac";
            string str2 = "needle";
           var result =  getAnagramIndices(str1, str2);
        }

        public List<int> getAnagramIndices(string haystack, string needle)
        {
            List<int> indicesList = new List<int>();

            if (string.IsNullOrEmpty(haystack) || string.IsNullOrEmpty(needle))
            {
                return indicesList;
            }

            if (haystack.Length < needle.Length)
            {
                return indicesList;
            }

            int idx = 0;
            int[] needleCount = new int[256];

            while (idx < needle.Length)
            {
                needleCount[needle[idx]] += 1;
                idx++;
            }

            idx = 0;
            while (idx < haystack.Length)
            {
                if (idx + needle.Length > haystack.Length)
                {
                    break;
                }

                if (AreAnagrams(haystack, idx, needle.Length, needleCount))
                {
                    indicesList.Add(idx);
                }
                idx++;
            }

            return indicesList;
        }

        private bool AreAnagrams(string givenString, int idx, int length, int[] lookupString)
        {

            int count = 0;
            int curIdx = idx;

            int[] givenStringCount = new int[256];

            while (count < length && curIdx < givenString.Length)
            {
                givenStringCount[givenString[curIdx]] += 1;
                curIdx++;
                count++;
            }

            count = 0;

            while (count < length && idx < givenString.Length)
            {
                if (givenStringCount[givenString[idx]] != lookupString[givenString[idx]])
                {
                    return false;
                }

                idx++;
                count++;
            }
            return true;
        }

        public string[,] matchLunches()
        {
            string[,] str = new string[3, 2]
            {
                { "John", "Italian"},
                {"Pal", "Indian" },
                {"Murugan", "*" }
            };
            

            return str;
        }

        //public string[,] matchLunches(string[,] lunchMenuPairs,
        //                                    string[,] teamCuisinePreference)
        //{

        //    if (lunchMenuPairs == null || teamCuisinePreference == null)
        //    {
        //        return null;
        //    }

        //    int memberIdx = 0;
        //    int optionIdx = 0;

        //    string[,] result = new string[teamCuisinePreference.Length, lunchMenuPairs.Length];

        //    //for (int member = 0; member < teamCuisinePreference.GetUpperBound(2); member++)
        //    {
        //        //FillCuisineOptions(teamCuisinePreference[member, 0], lunchMenuPairs, result);
        //    }

        //}

        //private void FillCuisineOptions(string foodOption, string[,] lunchMenuPairs, string[,] result)
        //{
        //    int memberIdx = 0;
        //    int optionIdx = 0;

        //    foreach(string food in lunchMenuPairs[foodOption])
        //    {

        //    }
        //}

        public void Skyline()
        {
            int[,] Buildings = new int[6, 3]
            {
                {1, 3, 4 },
                {3, 4, 4},
                {2, 6, 2},
                {8, 11, 4 },
                {7, 9, 3 },
                {10, 11, 2}
            };

            List<BuildingPoints> buildingPoints = new List<BuildingPoints>();
            for(int rowIdx = 0; rowIdx <= Buildings.GetUpperBound(0); rowIdx++)
            {
                var buildingPointStart =  new BuildingPoints();
                buildingPointStart.X = Buildings[rowIdx, 0];
                buildingPointStart.IsStart = true;
                buildingPointStart.Height = Buildings[rowIdx, 2];
                buildingPoints.Add(buildingPointStart);

                var buildingPointEnd = new BuildingPoints();
                buildingPointEnd = new BuildingPoints();
                buildingPointEnd.X = Buildings[rowIdx, 1];
                buildingPointEnd.IsStart = false;
                buildingPointEnd.Height = Buildings[rowIdx, 2];
                buildingPoints.Add(buildingPointEnd);
            }

            buildingPoints.Sort();
        }

        public void NQueen()
        {
            int[,] arr = new int[4, 4];

            int count = 0;

            Console.WriteLine(NQueenUtil(arr, 0, 0, 3, ref count));
        }

        private bool NQueenUtil(int[,] arr, int row, int col, int N, 
            ref int count)
        {
            bool result = false;
            if(arr.GetUpperBound(0) != arr.GetUpperBound(1))
            {
                return false;
            }

            if(arr == null)
            {
                return false;
            }

            if(count == N)
            {
                return true;
            }

            for(int rowIdx = row; rowIdx < arr.GetUpperBound(0); rowIdx ++)
            {
                for(int colIdx = col; colIdx < arr.GetUpperBound(1); colIdx ++)
                {
                    result =  PlaceQueen(arr, rowIdx, colIdx, N, ref count);
                }
            }

            return result;
        }

        private bool PlaceQueen(int[,] arr, int row, int col, int N, ref int count)
        {
            if(SatisfyRule(arr, row, col))
            {
                arr[row, col] = 1;
                count++;
                return true;
            }
            return false;
        }

        private bool SatisfyRule(int[,] arr, int row, int col)
        {
            int tRow = row;
            int tCol = col;

            while(tRow < arr.GetUpperBound(0) && 
                tCol < arr.GetUpperBound(1))
            {
                if(arr[tRow++, tCol++] == 1)
                {
                    return false;
                }
            }

            tRow = row;
            tCol = col;

            while (tRow >= 0 &&
                tCol >= 0)
            {
                if (arr[tRow--, tCol--] == 1)
                {
                    return false;
                }
            }

            tRow = 0;

            while(tRow < arr.GetUpperBound(0))
            {
                if(arr[tRow++, col] == 1)
                {
                    return false;
                }
            }

            tCol = 0;

            while(tCol < arr.GetUpperBound(1))
            {
                if(arr[row, tCol ++] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        public void MaxContiugousSum()
        {
            int[] arr = new int[] { -2, 1 };

            Console.WriteLine(MaxContigousSum(arr));
        }

        private int MaxContigousSum(int[] arr)
        {
            if(arr.Length == 0)
            {
                return 0;
            }

            int max = arr[0];
            int sum = arr[0];

            int idx = 1;

            while(idx < arr.Length)
            {

                if(sum + arr[idx] > 0)
                {
                    if(sum < 0)
                    {
                        sum = 0;
                    }
                    sum += arr[idx];
                }
                else
                {
                    sum = arr[idx];
                }

                if (max < sum)
                {
                    max = sum;
                }

                idx ++;
            }

            return max;
        }

        public void SplitArrays()
        {

        }

        //private bool SplitArrays(int[] arr)
        //{
        //    Dictionary<int, int> map = new Dictionary<int, int>();
        //    List<List<int>> list = new List<List<int>>();
        //    int[] temp = new int[3];
        //    int curIdx = 0;
        //    int tIdx = 0;

        //    for(int idx = 0; idx < arr.Length; idx ++)
        //    {
        //        //curIdx = map[list.Count];
        //        var last = list[list.Count];

        //        if (tIdx < 2 && arr[idx] - temp[tIdx] == 1)
        //        {
        //            temp[tIdx++] = arr[idx];
        //        }
        //        else
        //        {
        //            if (tIdx == 2)
        //            {
        //                var newList = new List<int>();
        //                newList.AddRange(temp);
        //                list.Add(newList);
        //                temp = new int[3];
        //                tIdx = 0;
        //                //map.Add(list.Count - 1, );

        //            }
        //        }
        //        if (last.Count < 3 && last[last.Count] - arr[idx] == 1)
        //        {
        //            last.Add(arr[idx]);
        //        }
                
        //    }
        //}

        public void JobScheduling()
        {
            var job1 = new Job(1, 3, 5);
            var job2 = new Job(2, 5, 6);
            var job3 = new Job(4, 6, 5);
            var job4 = new Job(6, 7, 4);
            var job5 = new Job(5, 8, 11);
            var job6 = new Job(7, 9, 2);

            var jobs = new Job[6] { job5, job2, job3, job4, job1, job6 };
            Array.Sort(jobs, new JobComparator());

            Console.WriteLine(JobSchedulingUtil(jobs));
        }

        private int JobSchedulingUtil(Job[] jobs)
        {
            if(jobs == null)
            {
                return 0;
            }

            int[] jobProfit = new int[jobs.Length];
            jobProfit[0] = jobs[0].Profit;

            for(int i= 1; i < jobs.Length; i ++)
            {
                jobProfit[i] = Math.Max(jobs[i].Profit, jobProfit[i-1]);
                //jobProfit[i] = jobs[i].Profit;

                for(int j = i-1; j >=0; j --)
                {
                    if(jobs[j].End <= jobs[i].Start)
                    {
                        jobProfit[i] = Math.Max(jobProfit[i], jobs[i].Profit + jobProfit[j]);
                        break;
                    }
                }
            }

            return jobProfit[jobs.Length-1];
        }


        public void CreComparator()
        {
            var interval1 = new Intervals(0, 30);
            var interval2 = new Intervals(5, 10);
            var interval3 = new Intervals(15, 20);

            var list = new List<Intervals>();
            list.Add(interval3);
            list.Add(interval2);
            list.Add(interval1);

            list.Sort(new IntervalComparator());
        }

        public void FindMinOfRotatedSorted()
        {
            int[] nums = new int[] { 3, 3, 1, 3};

            Console.WriteLine(FindMinUtil(nums, 0, nums.Length-1));
        }

        private int FindMinUtil(int[] nums, int start, int end)
        {
            if (start == end || Math.Abs(start - end) == 1)
            {
                return nums[start] > nums[end] ? nums[end] : nums[start];
            }

            int mid = (start + end) / 2;

            if (nums[start] > nums[mid])
            {
                end = mid;
            }
            else if (mid + 1 < (nums.Length - 1) && nums[mid] > nums[end])
            {
                start = mid;
            }
            else
            {
                int res1 = FindMinUtil(nums, start, mid);
                
                int res2 = FindMinUtil(nums, mid, end);

                return Math.Min(res1, res2);
                //if (nums[mid] == nums[start] && nums[mid] == nums[end])
                //{
                //    if (nums[mid] < nums[mid - 1])
                //    {
                //        end = mid;
                //    }
                //    else
                //    {
                //        start = mid;
                //    }
                //}
                //else if (nums[mid] <= nums[end])
                //{
                //    end = mid;
                //}
                //else
                //{
                //    start = mid;
                //}
            }

            return FindMinUtil(nums, start, end);
        }

        public void LargestSumContigousSubArray()
        {
            int[] arr = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };

            Console.WriteLine(LargestSumContigousSubArray(arr));
        }

        private int LargestSumContigousSubArray(int[] arr)
        {
            int max = Int32.MinValue;

            int sum = max;

            for (int idx = 0; idx < arr.Length; idx++)
            {
                if(arr[idx] + sum > max)
                {
                    sum += arr[idx];
                    max = sum;
                }
                else if (arr[idx] > max)
                {
                    max = arr[idx];
                    sum = arr[idx];
                   
                }
                else if (arr[idx] + sum >= 1)
                {
                    sum += arr[idx];
                }
                else
                {
                    sum = arr[idx];
                }
            }

            return max;
        }

        public void ValidNComboOfBraces()
        {
           var result = ValidNComboOfBracesUtil(3, 0, new char[6], new List<List<char>>());
            foreach (List<char> ch in result)
            {
                ch.ForEach((c)=> {
                    Console.WriteLine(c);
                });
                Console.WriteLine("------------------------");
            }
        }

        private List<List<char>> ValidNComboOfBracesUtil(int n, int idx, char[] arr, List<List<char>> result)
        {
            if(idx >= arr.Length)
            {
                return result;
            }

            if(idx == n * 2 -1)
            {
                //if (IsVaidBracePosition(n, idx, arr))
                {
                    var list = new List<char>();
                    list.AddRange(arr);
                    result.Add(list);
                }
            }

            char temp = arr[idx];

            arr[idx] = '(';
            if(IsVaidBracePosition(n, idx, arr))
            {
                ValidNComboOfBracesUtil(n, idx + 1, arr, result);
            }
            

            arr[idx] = ')';

            if (IsVaidBracePosition(n, idx, arr))
            {
                ValidNComboOfBracesUtil(n, idx + 1, arr, result);
            }
            

            return result;
        }

        private bool IsVaidBracePosition(int n, int idx, char[] arr)
        {
            int openCount = 0;

            for(int i = 0; i <= idx; i++)
            {
                if(openCount < 0)
                {
                    return false;
                }

                if (arr[i] == '(')
                {
                    openCount++;
                }
                else if(arr[i] == ')')
                {
                    openCount--;
                }
            }

            if(openCount > n || idx == n *2 -1 && openCount > 0)
            {
                return false;
            }

            return true;
        }

        public void MaximalRectangleArea()
        {
            int[,] matrix = new int[4, 4]
            {
                {1, 0, 0, 1},
                {0, 1, 1, 1},
                {1, 1, 1, 1},
                {0, 1, 1, 1}
            };

            Console.WriteLine(MaximalRectangleArea(matrix));
        }

        public int MaximalRectangleArea(int[,] matrix)
        {
            if (matrix == null || matrix.GetUpperBound(0) == 0 || matrix.GetUpperBound(1) == 0)
                return 0;
            int cLen = matrix.GetUpperBound(1);    // column length
            int rLen = matrix.GetUpperBound(0);       // row length
                                            // height array 
            int[] h = new int[cLen + 1];
            h[cLen] = 0;
            int max = 0;
            Stack<int> s = new Stack<int>();

            for (int row = 0; row <= rLen; row++)
            {
                for (int col = 0; col <= cLen; col++)
                {
                    if (col < cLen)
                    {
                        if (matrix[row, col] == 1)
                        {
                            h[col] += 1;
                        }
                        else
                        {
                            h[col] = 0;
                        }
                    }

                    if (s.Count == 0 || h[s.Peek()] <= h[col])
                    {
                        s.Push(col);
                        continue;
                    }
                    else
                    {
                        while (s.Count > 0 && h[col] < h[s.Peek()])
                        {
                            int top = s.Pop();
                            int area = h[top] * (s.Count == 0 ? col : (col - s.Peek() - 1));
                            if (area > max)
                            {
                                max = area;
                            }
                        }
                        //s.Push(col);
                    }
                }

                while (s.Count > 0)
                {
                    int top = s.Pop();
                    int area = h[top] * (s.Count == 0 ? h.Length : (h.Length - s.Peek() - 1));
                    if (area > max)
                    {
                        max = area;
                    }
                }
            }
            return max;
        }

        //public void WaterTrap()
        //{
        //    int[] arr = new int[12] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

        //    Console.WriteLine(WaterTrap(arr, 12));
        //}

        //private int WaterTrap(int[] A, int n)
        //{
        //    int left = 0; int right = n - 1;
        //    int res = 0;
        //    int maxleft = 0, maxright = 0;
        //    while (left <= right)
        //    {
        //        if (A[left] <= A[right])
        //        {
        //            if (A[left] >= maxleft) maxleft = A[left];
        //            else res += maxleft - A[left];
        //            left++;
        //        }
        //        else {
        //            if (A[right] >= maxright) maxright = A[right];
        //            else res += maxright - A[right];
        //            right--;
        //        }
        //    }
        //    return res;
        //}

    }

    public class JobComparator : IComparer<Job>
    {
        public int Compare(Job x, Job y)
        {
            if(x.End <= y.End)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    public class Job
    {
        public int Start;
        public int End;
        public int Profit;

        public Job(int Start, int End, int Profit)
        {
            this.Start = Start;
            this.End = End;
            this.Profit = Profit;
        }
    }

    public class BuildingPoints : IComparable<BuildingPoints>
    {
        public int X;
        public bool IsStart;
        public int Height;

        public int CompareTo(BuildingPoints other)
        {
            if(this.X != other.X)
            {
                return this.X > other.X ? 1 : -1;
            }
            else
            {
                return Math.Abs((this.IsStart ? -this.Height : this.Height) -
                    (other.IsStart ? -other.Height : other.Height));
            }
        }
    }

    public class Priorityqueue
    {
        int[] arr = null;
        int idx = 1;
        List<int> list = new List<int>();

        public Priorityqueue(int countItems)
        {
            arr = new int[countItems + 1];
            
        }

        public void DoOperations()
        {
            InsertItem(4);
            InsertItem(6);
            InsertItem(3);
            InsertItem(5);
            InsertItem(1);
            InsertItem(7);
            GetMaxItem();
            RemoveItem();
            RemoveItem(3);
            GetMaxItem();
            RemoveItem();
            GetMaxItem();
            RemoveItem();
            GetMaxItem();
            RemoveItem();
            GetMaxItem();
            RemoveItem();
            GetMaxItem();
        }

        public void InsertItem(int item)
        {
            if(idx == 1)
            {
                arr[idx++] = item;
            }
            else
            {
                ValidateAndInsert(idx, item);
                idx++;
                
            }
        }

        private void ValidateAndInsert(int idx, int item)
        {
            arr[idx] = item;
            HeapifyBottomUp(idx);
        }

        private void HeapifyBottomUp(int idx)
        {
            int parentIdx = Math.Abs(idx / 2);

            if (parentIdx > 0 && arr[idx] > arr[parentIdx])
            {
                int temp = arr[idx];
                arr[idx] = arr[parentIdx];
                arr[parentIdx] = temp;
                HeapifyBottomUp(parentIdx);
            }
        }

        private void HeapifyTopDown(int idx)
        {
            int leftChildIdx = idx * 2;
            int rightChildIdx = leftChildIdx + 1;

            if(leftChildIdx < this.idx && rightChildIdx < this.idx)
            {
                int maxIdx = arr[leftChildIdx] > arr[rightChildIdx] 
                    ? leftChildIdx : rightChildIdx;

                if(arr[idx] < arr[maxIdx])
                {
                    int temp = arr[idx];
                    arr[idx] = arr[maxIdx];
                    arr[maxIdx] = temp;
                    HeapifyTopDown(maxIdx);
                }
            }
            else if(leftChildIdx < this.idx)
            {
                int maxIdx = leftChildIdx;

                if (arr[idx] < arr[maxIdx])
                {
                    int temp = arr[idx];
                    arr[idx] = arr[maxIdx];
                    arr[maxIdx] = temp;
                    HeapifyTopDown(maxIdx);
                }
            }
        }

        public void RemoveItem()
        {
            arr[1] = arr[--this.idx];
            HeapifyTopDown(1);
        }

        public void RemoveItem(int value)
        {
            for (int i = 1; i <= idx; i++)
            {
                if(arr[i] == value)
                {
                    arr[i] = arr[--this.idx];
                    HeapifyTopDown(i);
                    break;
                }
            }
        }

        public int GetMaxItem()
        {
            if (idx > 1)
            {
                Console.WriteLine(arr[1]);
                return arr[1];
            }
            else
            {
                throw new Exception("No more elements to pop");
            }
        }
    }

    public class IntervalComparator : IComparer<Intervals>
    {
        public int Compare(Intervals x, Intervals y)
        {
            return x.Start - y.Start;
        }
    }

    public class Intervals
    {
        public int Start;
        public int End;

        public Intervals(int Start, int End)
        {
            this.Start = Start;
            this.End = End;
        }
    }

    public struct SnakeEntry
    {
        public int Vertex;
        public int Distance;
    }

    public struct HeightUtil
    {
        public int Short;
        public int Tall;
        public int Size;

        public HeightUtil(int Short, int Tall, int Size)
        {
            this.Short = Short;
            this.Tall = Tall;
            this.Size = Size;
        }

        public void LargestmatchingWordInDictionary()
        {

        }

        private string LargestMatchingWordinDictionary(HashSet<string> dict, string str)
        {
            string result = string.Empty;

            if(dict.Count == 0 || string.IsNullOrEmpty(str))
            {
                return result;
            }

            foreach(string word in dict)
            {

            }

            return result;
        }

        //private bool IsSubsequence(string word, string str)
        //{

        //}
    }
}
