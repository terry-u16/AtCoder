using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu059.Algorithms;
using Kujikatsu059.Collections;
using Kujikatsu059.Extensions;
using Kujikatsu059.Numerics;
using Kujikatsu059.Questions;

namespace Kujikatsu059.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc088/tasks/arc088_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var charCounts = CountChars(s);
            if (!CanBePalindrome(charCounts))
            {
                yield return -1;
                yield break;    
            }

            var palindrome = GetPalindrome(s, charCounts);
            var charIndices = Enumerable.Repeat(0, 26).Select(_ => new Queue<int>()).ToArray();
            var cursors = new int[26];

            for (int i = 0; i < palindrome.Length; i++)
            {
                charIndices[s[i] - 'a'].Enqueue(i);
            }

            long result = 0;

            for (int i = 0; i < palindrome.Length; i++)
            {
                var c = palindrome[i] - 'a';
                var initial = charIndices[c].Dequeue();

                if (initial - i > 0)
                {
                    result += initial - i;
                }
            }

            yield return result;
        }

        int[] CountChars(string s)
        {
            var counts = new int[26];
            foreach (var c in s)
            {
                counts[c - 'a']++;
            }
            return counts;
        }

        bool CanBePalindrome(int[] counts) => counts.Count(c => c % 2 == 1) <= 1;

        string GetPalindrome(string s, int[] charCounts)
        {
            var builder = new StringBuilder(s.Length / 2);
            var popped = new int[26];
            foreach (var c in s.Reverse())
            {
                var cIndex = c - 'a';
                if (popped[cIndex] < charCounts[cIndex] / 2)
                {
                    popped[cIndex]++;
                    builder.Append(c);
                }
            }

            var reversed = builder.ToString().Reverse().Join();

            if (s.Length % 2 != 0)
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (charCounts[c - 'a'] % 2 == 1)
                    {
                        builder.Append(c);
                        break;
                    }
                }
            }

            return builder.ToString() + reversed;
        }
    }
}
