using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu045.Algorithms;
using Kujikatsu045.Collections;
using Kujikatsu045.Extensions;
using Kujikatsu045.Numerics;
using Kujikatsu045.Questions;

namespace Kujikatsu045.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc022/tasks/agc022_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            if (s == "zyxwvutsrqponmlkjihgfedcba")
            {
                yield return -1;
                yield break;
            }
            else if (s.Length < 26)
            {
                var used = new bool[26];
                foreach (var c in s)
                {
                    used[c - 'a'] = true;
                }

                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (!used[c - 'a'])
                    {
                        yield return s + c;
                        yield break;
                    }
                }
            }
            else
            {
                var used = new bool[26];
                used[s[^1] - 'a'] = true;
                for (int i = s.Length - 2; i >= 0; i--)
                {
                    used[s[i] - 'a'] = true;
                    if (s[i] < s[i + 1])
                    {
                        char append = '_';
                        for (int c = s[i] - 'a' + 1; c < used.Length; c++)
                        {
                            if (used[c])
                            {
                                append = (char)(c + 'a');
                                break;
                            }
                        }
                        yield return s.Substring(0, i) + append;
                        yield break;
                    }
                }
            }
        }
    }
}
