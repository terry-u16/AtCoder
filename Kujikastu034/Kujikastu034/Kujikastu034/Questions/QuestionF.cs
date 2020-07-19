using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikastu034.Algorithms;
using Kujikastu034.Collections;
using Kujikastu034.Extensions;
using Kujikastu034.Numerics;
using Kujikastu034.Questions;

namespace Kujikastu034.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc140/tasks/abc140_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var p = inputStream.ReadIntArray();
            var indices = new int[n];
            long sum = 0;

            for (int i = 0; i < p.Length; i++)
            {
                indices[p[i] - 1] = i + 1;
            }

            var bit = new BinaryIndexedTree(n + 2);
            bit[0] += 2;
            bit[n + 1] += 2;

            for (int pi = n; pi > 0; pi--)
            {
                var index = indices[pi - 1];

                var left = bit.Sum(..index);
                var right = bit.Sum((index + 1)..);

                var left2 = bit.GetLowerBound(left - 1) + 1;
                var left1 = bit.GetLowerBound(left) + 1;
                var right1 = bit.GetLowerBound(left + 1);
                var right2 = bit.GetLowerBound(left + 2);

                sum += (long)(left1 - left2) * (right1 - index) * pi;
                sum += (long)(index - left1 + 1) * (right2 - right1) * pi;
                bit[index]++;
            }

            yield return sum;
        }
    }
}
