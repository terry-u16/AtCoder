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
    /// https://atcoder.jp/contests/abc141/tasks/abc141_e
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var max = 0;

            for (int start = 0; start < s.Length; start++)
            {
                max = Math.Max(max, GetMaxLength(s, start));
            }

            yield return max;
        }

        int GetMaxLength(string s, int start)
        {
            var subString = s.AsSpan()[start..];
            var zAlgo = ZAlgorithm.SearchAll(subString);
            var length = 0;

            for (int i = 1; i < zAlgo[0]; i++)
            {
                length = Math.Max(length, Math.Min(i, zAlgo[i]));
            }

            return length;
        }
    }
}
