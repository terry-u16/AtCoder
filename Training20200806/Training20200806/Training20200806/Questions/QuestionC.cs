using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200806.Algorithms;
using Training20200806.Collections;
using Training20200806.Extensions;
using Training20200806.Numerics;
using Training20200806.Questions;
using static Training20200806.Algorithms.AlgorithmHelpers;

namespace Training20200806.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/yahoo-procon2019-qual/tasks/yahoo_procon2019_qual_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ears = inputStream.ReadInt();
            var needed = new long[ears];
            for (int i = 0; i < needed.Length; i++)
            {
                needed[i] = inputStream.ReadLong();
            }

            const long Inf = 1L << 60;
            var operations = new long[ears + 1, 4].SetAll((i, j) => Inf);
            // スタートから左、右、左で折り返していくことを考える
            operations[0, 0] = 0;   // 左
            operations[0, 1] = 0;   // 右
            operations[0, 2] = 0;   // 左
            operations[0, 3] = 0;   // 終わった
            long prefixSum = 0;

            for (int i = 0; i < needed.Length; i++)
            {
                UpdateWhenSmall(ref operations[i + 1, 0], operations[i, 0] + EvenRoundTrip(needed[i]));
                UpdateWhenSmall(ref operations[i + 1, 1], operations[i, 0] + OddRoundTrip(needed[i]));
                UpdateWhenSmall(ref operations[i + 1, 2], operations[i, 0] + EvenRoundTrip(needed[i]));
                UpdateWhenSmall(ref operations[i + 1, 3], operations[i, 0]);

                UpdateWhenSmall(ref operations[i + 1, 1], operations[i, 1] + OddRoundTrip(needed[i]));
                UpdateWhenSmall(ref operations[i + 1, 2], operations[i, 1] + EvenRoundTrip(needed[i]));
                UpdateWhenSmall(ref operations[i + 1, 3], operations[i, 1]);

                UpdateWhenSmall(ref operations[i + 1, 2], operations[i, 2] + EvenRoundTrip(needed[i]));
                UpdateWhenSmall(ref operations[i + 1, 3], operations[i, 2] + EvenRoundTrip(needed[i]));

                UpdateWhenSmall(ref operations[i + 1, 3], operations[i, 3] + needed[i]);

                // 新規参入
                prefixSum += needed[i];
                UpdateWhenSmall(ref operations[i + 1, 0], prefixSum);
            }

            long min = long.MaxValue;
            for (int i = 0; i < 4; i++)
            {
                UpdateWhenSmall(ref min, operations[ears, i]);
            }

            yield return min;
        }

        int EvenRoundTrip(long needed)
        {
            if (needed == 0)
            {
                return 2;
            }
            else if (needed % 2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        int OddRoundTrip(long needed) => needed % 2 == 1 ? 0 : 1;
    }
}
