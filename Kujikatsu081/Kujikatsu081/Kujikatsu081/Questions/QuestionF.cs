using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu081.Algorithms;
using Kujikatsu081.Collections;
using Kujikatsu081.Extensions;
using Kujikatsu081.Numerics;
using Kujikatsu081.Questions;

namespace Kujikatsu081.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc165/tasks/abc165_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (players, arenas) = inputStream.ReadValue<int, int>();
            if (players % 2 == 1)
            {
                for (int i = 0; i < arenas; i++)
                {
                    yield return $"{i + 1} {players - i}";
                }
            }
            else
            {
                for (int i = 0; i < Math.Min(arenas, players / 4); i++)
                {
                    yield return $"{i + 1} {players - i}";
                }
                for (int i = players / 4; i < arenas; i++)
                {
                    yield return $"{i + 1} {players - i - 1}";
                }
            }
        }
    }
}
