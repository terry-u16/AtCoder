using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200628.Algorithms;
using Training20200628.Collections;
using Training20200628.Extensions;
using Training20200628.Numerics;
using Training20200628.Questions;

namespace Training20200628.Questions
{
    /// <summary>
    /// http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=DPL_5_C&lang=jp
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            Modular.InitializeCombinationTable();

            var count = Modular.Zero;
            for (int empty = 0; empty < k; empty++)
            {
                var sign = (empty & 1) == 0 ? 1 : -1;
                count += sign * Modular.Combination(k, empty) * Modular.Pow(k - empty, n);
            }

            yield return count.Value;
        }
    }
}
