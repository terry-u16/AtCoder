using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200805.Algorithms;
using Training20200805.Collections;
using Training20200805.Extensions;
using Training20200805.Numerics;
using Training20200805.Questions;
using static Training20200805.Algorithms.AlgorithmHelpers;

namespace Training20200805.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc162/tasks/abc162_f
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            if (n <= 3)
            {
                yield return a.Max();
                yield break;
            }

            const long Inf = 1L << 60;
            var maxSkip = n % 2 == 0 ? 1 : 2;
            var max = new long[n + 1, 2, maxSkip + 1].SetAll((i, j, k) => -Inf);    // [index, 1個前に選んだかどうか, スキップ数]
            max[0, 0, 0] = 0;

            for (int i = 0; i < a.Length; i++)
            {
                for (int skip = 0; skip <= maxSkip; skip++)
                {
                    // 前回選んでない
                    // 選ぶ
                    UpdateWhenLarge(ref max[i + 1, 1, skip], max[i, 0, skip] + a[i]);

                    // スキップ
                    if (skip < maxSkip)
                    {
                        UpdateWhenLarge(ref max[i + 1, 0, skip + 1], max[i, 0, skip]);
                    }

                    // 前回選んでる
                    UpdateWhenLarge(ref max[i + 1, 0, skip], max[i, 1, skip]);
                }
            }

            long result = -Inf;
            for (int selected = 0; selected < 2; selected++)
            {
                UpdateWhenLarge(ref result, max[n, selected, maxSkip]);
            }

            yield return result;
        }
    }
}
