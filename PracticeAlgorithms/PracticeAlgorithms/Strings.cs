using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithms
{
    public class Strings
    {
        public void IsTransformable()
        {
            List<string> TransMap = new List<string>();
            TransMap.Add("DIT");
            TransMap.Add("DOT");
            TransMap.Add("CAT");
            TransMap.Add("CUT");
            TransMap.Add("COT");
            TransMap.Add("CAN");
            TransMap.Add("FAN");
            TransMap.Add("MAN");
            TransMap.Add("FAT");

            Console.WriteLine("The given list is transformable: " + IsTransformable(TransMap, "DIT", "FAN"));
        }

        public bool IsTransformable(List<string> TransMap, string start, string end)
        {
            bool result = false;
            Queue<string> bfsMap = new Queue<string>();
            bfsMap.Enqueue(start);
            TransMap.Remove(start);
            string cur = start;

            while(bfsMap.Count >0)
            {
                cur = bfsMap.Dequeue();

                for (int idx = 0; idx < TransMap.Count; idx ++)
                {
                    if (OneEditDistance(cur, end))
                    {
                        return true;
                    }
                    else if (OneEditDistance(cur, TransMap[idx]))
                    {
                        bfsMap.Enqueue(TransMap[idx]);
                        TransMap.RemoveAt(idx);
                    }
                }
            }

            return result;
        }

        private bool OneEditDistance(string original, string dest)
        {
            int diff = 0;
            for (int idx = 0; idx < original.Length; idx++)
            {
                if(diff > 1)
                {
                    return false;
                }

                if(original[idx]!= dest[idx])
                {                    
                    diff++;
                }                
            }
            return diff == 1 ? true : false;
        }

        public void IsWildcardPattern()
        {
            Console.WriteLine(IsWilCardPatternUtil("abefcdgiescdfimde", "ab*cd?i*de"));
        }

        private bool IsWilCardPatternUtil(string input, string pattern)
        {
            int iIdx = 0;
            int pIdx = 0;

            while(iIdx < input.Length && pIdx < pattern.Length)
            {
                switch(pattern[pIdx])
                {
                    case '?':
                        {
                            iIdx++;
                            pIdx++;
                            break;
                        }
                    case '*':
                        {
                            Validate(input, pattern, ref iIdx, ref pIdx);
                            break;
                        }
                    default:
                        {
                            if(input[iIdx] != pattern[pIdx])
                            {
                                return false;
                            }
                            iIdx++;
                            pIdx++;
                            break;
                        }
                }
            }

            if (iIdx == input.Length && pIdx == pattern.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Validate(string input, string pattern, ref int iIdx, ref int pIdx)
        {
            if(pIdx == pattern.Length -1 )
            {
                while(iIdx < input.Length )
                {
                    iIdx++;
                }
                pIdx++;
                return;
            }
            else
            {
                pIdx++;
                while(pIdx < pattern.Length && pattern[pIdx]== '*')
                {
                    pIdx++;
                }

                while(input[iIdx] != pattern[pIdx])
                {
                    iIdx++;
                }
                pIdx++;
                iIdx++;
            }
        }

        public void atoi()
        {
            Console.WriteLine(atoi("1230", 10));
        }

        private string atoi(string num, int baseNum)
        {
            switch(baseNum)
            {
                case 10:
                    {
                        int res = 0;
                        int digit = 1;
                        int curNum = 0;

                        for(int idx = num.Length - 1; idx >=0; idx --)
                        {
                            curNum = num[idx] - 48;
                            res += digit * curNum;
                            digit *= 10;
                        }

                        return res.ToString();
                    }

            }
            return string.Empty;
        }

        public void ReturnMappedString()
        {
            //TrieNode root = new TrieNode();

            //TrieNode node = new TrieNode("T");
            //node.Value = "x";

            Console.WriteLine(ReturnMappedString("TANUAA"));
        }

        private string ReturnMappedString(string s)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("T", "x");
            dict.Add("NU", "g");
            dict.Add("TH", "y");
            dict.Add("A", "z");
            dict.Add("AA", "u");
            dict.Add("H", "l");

            int start = 0;
            int foundLength = 1;
            string res = string.Empty;

            while(start < s.Length)
            {
                while(dict.ContainsKey(s.Substring(start, foundLength)))
                {
                    if(start >=0)
                    {
                        start--;
                        foundLength++;
                    }
                }

                if (foundLength > 1)
                {
                    res = dict[s.Substring(start + 1, foundLength - 1)] + res;
                }
                else
                {
                    res = dict[s.Substring(start, foundLength )] + res;
                }
                foundLength = 1;
            }

            return res;
        }

        public void WordBreak()
        {
            HashSet<string> dict = new HashSet<string>();
            dict.Add("Leet"); 
            dict.Add("Code");
            string str = "LeetCode";

            Console.WriteLine(WordBreak(str, dict));
        }

        private bool WordBreak(string s, HashSet<string> dict)
        {
            bool[] f = new bool[s.Length + 1];
            f[0] = true;

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dict.Contains(s.Substring(j, i)))
                    {
                        f[i] = true;
                        i = 1;
                        break;
                    }
                }
            }
            return f[s.Length];

        }
    }
}
