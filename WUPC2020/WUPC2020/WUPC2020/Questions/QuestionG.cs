using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WUPC2020.Extensions;
using WUPC2020.Questions;

namespace WUPC2020.Questions
{
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var input = inputStream.ReadIntArray();
            var n = input[0];
            var rest = input[1];
            var timeLimit = input[2];

            var trainings = new Training[n];

            for (int i = 0; i < trainings.Length; i++)
            {
                var tp = inputStream.ReadIntArray();
                trainings[i] = new Training(tp[0], tp[1]);
            }

            var current = new long[timeLimit + 1];
            var next = new long[timeLimit + 1];

            for (int i = 0; i < trainings.Length; i++)
            {
                for (int t = 0; t < current.Length; t++)
                {
                    var nextTime = t + trainings[i].Time;
                    if (nextTime < current.Length)
                    {
                        ChangeMax(ref next[nextTime], current[t] + trainings[i].Kinniku);
                    }
                    else
                    {
                        break;
                    }
                }

                Swap(ref current, ref next);
                Array.Copy(current, next, current.Length);
            }

            var max = long.MinValue;
            ChangeMax(ref max, current.Max());

            var minTime = 0;
            timeLimit -= rest;

            while (minTime < timeLimit)
            {
                var currentMinTime = int.MaxValue;
                for (int i = 0; i < trainings.Length; i++)
                {
                    var neededTime = trainings[i].Time;
                    for (int t = timeLimit - neededTime; t >= minTime; t--)
                    {
                        var powerUp = current[t] + trainings[i].Kinniku;
                        var nextTime = t + neededTime;
                        if (powerUp > current[nextTime])
                        {
                            current[nextTime] = powerUp;
                            ChangeMin(ref currentMinTime, nextTime);
                        }
                    }
                }

                for (int i = currentMinTime; i <= timeLimit; i++)
                {
                    ChangeMax(ref max, current[i]);
                }

                minTime = currentMinTime;
                timeLimit -= rest;
            }

            yield return max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void ChangeMax(ref long a, long b)
        {
            if (a < b)
            {
                a = b;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void ChangeMin(ref int a, int b)
        {
            if (a > b)
            {
                a = b;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        struct Training
        {
            public readonly int Time;
            public readonly int Kinniku;

            public Training(int time, int kinniku)
            {
                Time = time;
                Kinniku = kinniku;
            }

            public override string ToString()
            {
                return string.Format("Time:{0}, Kinniku:{1}", Time, Kinniku);
            }
        }
    }
}
