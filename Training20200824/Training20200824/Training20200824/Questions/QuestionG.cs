using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200824.Algorithms;
using Training20200824.Collections;
using Training20200824.Extensions;
using Training20200824.Numerics;
using Training20200824.Questions;
using static Training20200824.Algorithms.AlgorithmHelpers;

namespace Training20200824.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc141/tasks/abc141_e
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            var max = 0;
            for (int start = 0; start < s.Length; start++)
            {
                var zAlgo = ZAlgorithm.SearchAll(s.AsSpan().Slice(start));

                for (int i = 0; i < zAlgo.Length; i++)
                {
                    max = Math.Max(max, Math.Min(i, zAlgo[i]));
                }
            }

            yield return max;
        }
    }
}
