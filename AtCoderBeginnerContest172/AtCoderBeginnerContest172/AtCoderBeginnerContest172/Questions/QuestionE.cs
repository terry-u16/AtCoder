using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest172.Algorithms;
using AtCoderBeginnerContest172.Collections;
using AtCoderBeginnerContest172.Extensions;
using AtCoderBeginnerContest172.Numerics;
using AtCoderBeginnerContest172.Questions;

namespace AtCoderBeginnerContest172.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.InitializeCombinationTable(2_000_000);
            var (n, m) = inputStream.ReadValue<int, int>();
            var countA = Modular.Permutation(m, n);
            var countB = Modular.Zero;

            for (int duplicated = Math.Max(0, 2 * n - m); duplicated <= n; duplicated++)
            {
                countB += Modular.Permutation(n, duplicated) * Modular.Permutation(m - duplicated, n - duplicated);
            }

            yield return (countA * countB).Value;
        }
    }
}
