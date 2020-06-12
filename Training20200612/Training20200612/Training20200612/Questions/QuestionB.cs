using Training20200612.Questions;
using Training20200612.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200612.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2015-morning-middle/tasks/cf_2015_morning_easy_d
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            var maxLength = 0;
            for (int length = 0; length < s.Length; length++)
            {
                maxLength = Math.Max(maxLength, GetLcs(s.Substring(0, length), s.Substring(length, n - length)));
            }

            yield return n - 2 * maxLength;
        }

        int GetLcs(string s1, string s2)
        {
            var lcs = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        lcs[i + 1, j + 1] = lcs[i, j] + 1;
                    }
                    else
                    {
                        lcs[i + 1, j + 1] = Math.Max(lcs[i, j + 1], lcs[i + 1, j]);
                    }
                }
            }

            return lcs[s1.Length, s2.Length];
        }
    }
}
