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
    /// https://atcoder.jp/contests/joi2012ho/tasks/joi2012ho3
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, endTime, hanabiTime) = inputStream.ReadValue<int, int, int>();
            var yomises = new Yomise[n];
            for (int i = 0; i < yomises.Length; i++)
            {
                var (f, t) = inputStream.ReadValue<int, int>();
                yomises[i] = new Yomise(f, t);
            }

            var maxFun = new int[yomises.Length + 1, endTime + 1];

            for (int i = 0; i < yomises.Length; i++)
            {
                for (int t = 0; t <= endTime; t++)
                {
                    if (t > 0)
                    {
                        UpdateWhenLarge(ref maxFun[i, t], maxFun[i, t - 1]);
                    }

                    var nextTime = t + yomises[i].Time;
                    var nextFun = maxFun[i, t] + yomises[i].Fun;

                    UpdateWhenLarge(ref maxFun[i + 1, t], maxFun[i, t]);

                    if (nextTime <= endTime && (t >= hanabiTime || nextTime <= hanabiTime))
                    {
                        UpdateWhenLarge(ref maxFun[i + 1, nextTime], nextFun);
                    }
                }
            }

            yield return maxFun[yomises.Length, endTime];
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Yomise
        {
            public int Fun { get; }
            public int Time { get; }

            public Yomise(int fun, int time)
            {
                Fun = fun;
                Time = time;
            }

            public void Deconstruct(out int fun, out int time) => (fun, time) = (Fun, Time);
            public override string ToString() => $"{nameof(Fun)}: {Fun}, {nameof(Time)}: {Time}";
        }
    }
}
