using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu029.Algorithms;
using Kujikatsu029.Collections;
using Kujikatsu029.Extensions;
using Kujikatsu029.Numerics;
using Kujikatsu029.Questions;

namespace Kujikatsu029.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2016-quala/tasks/codefestival_2016_qualA_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var k = inputStream.ReadInt();
            var answer = new List<char>();

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];

                var needed = GetCountToA(c);
                if (i == s.Length - 1)
                {
                    answer.Add(Rotate(c, k));
                }
                else if (k >= needed)
                {
                    answer.Add('a');
                    k -= needed;
                }
                else
                {
                    answer.Add(c);
                }
            }

            yield return answer.Join();
        }

        int GetCountToA(char c) => (26 - (c - 'a')) % 26;

        char Rotate(char c, int count) => (char)((c - 'a' + count) % 26 + 'a');
    }
}
