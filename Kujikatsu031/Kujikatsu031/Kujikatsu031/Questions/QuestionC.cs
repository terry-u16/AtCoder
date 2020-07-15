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

namespace Kujikatsu031.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/jsc2019-qual/tasks/jsc2019_qual_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            var bit = new BinaryIndexedTree(2001);

            var count = Modular.Zero;
            foreach (var ai in a)
            {
                count += bit.Sum((ai + 1)..);
                bit.AddAt(ai, 1);
            }

            count *= k;

            foreach (var ai in a)
            {
                count += bit.Sum((ai + 1)..) * new Modular(k) * new Modular(k - 1) / new Modular(2);
            }

            yield return count;
        }
    }
}
