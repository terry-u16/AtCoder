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

namespace Training20200805.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc063/tasks/arc075_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (monsters, a, b) = inputStream.ReadValue<int, long, long>();
            var hps = new long[monsters];
            for (int i = 0; i < hps.Length; i++)
            {
                hps[i] = inputStream.ReadInt();
            }

            yield return SearchExtensions.BoundaryBinarySearch(count => CanKill(hps, a, b, count), 1L << 32, 0);
        }

        bool CanKill(long[] hps, long a, long b, long bombCount)
        {
            var baseDamage = b * bombCount;
            var extraDamage = a - b;
            long count = 0;
            foreach (var hp in hps)
            {
                var remain = hp - baseDamage;
                if (remain > 0)
                {
                    count += (remain + extraDamage - 1) / extraDamage;
                }
            }
            return count <= bombCount;
        }
    }
}
