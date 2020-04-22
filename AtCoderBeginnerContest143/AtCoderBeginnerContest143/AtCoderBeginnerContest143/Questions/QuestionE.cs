using AtCoderBeginnerContest143.Questions;
using AtCoderBeginnerContest143.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest143.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nml = inputStream.ReadIntArray();
            var n = nml[0];
            var m = nml[1];
            var l = nml[2];

            const int sugoiDekaiKazu = int.MaxValue >> 1;

            var distances = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        distances[i, j] = sugoiDekaiKazu;
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                var abc = inputStream.ReadIntArray();
                var a = abc[0] - 1;
                var b = abc[1] - 1;
                var c = abc[2];

                distances[a, b] = c;
                distances[b, a] = c;
            }
            WarshalFloyd(distances);

            var refuelCounts = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    refuelCounts[i, j] = distances[i, j] <= l ? 1 : sugoiDekaiKazu;
                }
            }
            WarshalFloyd(refuelCounts);

            var q = inputStream.ReadInt();
            for (int i = 0; i < q; i++)
            {
                var st = inputStream.ReadIntArray();
                var s = st[0] - 1;
                var t = st[1] - 1;

                var refuel = refuelCounts[s, t];

                if (refuel < sugoiDekaiKazu)
                {
                    yield return refuel - 1;    // タンク1回分なら補給不要
                }
                else
                {
                    yield return -1;
                }
            }
        }

        private void WarshalFloyd(int[,] distances)
        {
            var n = distances.GetLength(0);
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        distances[i, j] = Math.Min(distances[i, j], distances[i, k] + distances[k, j]);
                    }
                }
            }
        }
    }
}
