using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu031.Algorithms;
using Kujikatsu031.Collections;
using Kujikatsu031.Extensions;
using Kujikatsu031.Numerics;
using Kujikatsu031.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu031.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/keyence2020/tasks/keyence2020_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var robots = new Robot[n];

            for (int i = 0; i < n; i++)
            {
                var (x, l) = inputStream.ReadValue<int, int>();
                robots[i] = new Robot(x, l);
            }

            Array.Sort(robots);

            var last = int.MinValue;
            var count = 0;

            foreach (var robot in robots)
            {
                if (robot.Left >= last)
                {
                    count++;
                    last = robot.Right;
                }
            }

            yield return count;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Robot : IComparable<Robot>
        {
            public int Left { get; }
            public int Right { get; }

            public Robot(int x, int arm)
            {
                Left = x - arm;
                Right = x + arm;
            }

            public override string ToString() => $"{nameof(Left)}: {Left}, {nameof(Right)}: {Right}";

            public int CompareTo([AllowNull] Robot other) => Right - other.Right;
        }
    }
}
