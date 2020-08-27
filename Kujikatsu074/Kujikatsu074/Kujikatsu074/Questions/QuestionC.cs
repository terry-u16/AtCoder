using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu074.Algorithms;
using Kujikatsu074.Collections;
using Kujikatsu074.Extensions;
using Kujikatsu074.Numerics;
using Kujikatsu074.Questions;

namespace Kujikatsu074.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc035/tasks/agc035_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var hats = inputStream.ReadIntArray();

            var before = hats[0];
            var current = 0;

            var counts = new Counter<int>();

            foreach (var hat in hats.Skip(1))
            {
                counts[hat]++;
            }

            var ok = false;
            foreach (var (value, _) in counts)
            {
                current = value;
                var next = before ^ current;

                if ((value != next && counts[next] >= 1) || counts[next] >= 2)
                {
                    ok = true;
                    counts[current]--;
                    break;
                }
            }

            if (!ok)
            {
                yield return "No";
                yield break;
            }

            for (int i = 2; i < hats.Length; i++)
            {
                var next = before ^ current;
                if (counts[next] > 0)
                {
                    before = current;
                    current = next;
                    counts[next]--;
                }
                else
                {
                    yield return "No";
                    yield break;
                }
            }

            if ((before ^ current) == hats[0])
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }
    }
}
