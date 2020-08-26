using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ForciaVirtualContest014.Algorithms;
using ForciaVirtualContest014.Collections;
using ForciaVirtualContest014.Extensions;
using ForciaVirtualContest014.Numerics;
using ForciaVirtualContest014.Questions;

namespace ForciaVirtualContest014.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc151/tasks/abc151_e
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            Array.Sort(a);

            var sum = Modular.Zero;
            Modular.InitializeCombinationTable();

            for (int i = 0; i <= a.Length - k; i++)
            {
                sum += -a[i] * Modular.Combination(a.Length - i - 1, k - 1);
            }

            for (int i = k - 1; i < a.Length; i++)
            {
                sum += a[i] * Modular.Combination(i, k - 1);
            }

            yield return sum;
        }
    }
}
