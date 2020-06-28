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
            Modular.InitializeCombinationTable(1_000_000);
            var (n, m) = inputStream.ReadValue<int, int>();
            var count = Modular.Zero;

            for (int duplicated = 0; duplicated <= n; duplicated++)
            {
                var sign = (duplicated & 1) == 0 ? 1 : -1;
                count += sign * Modular.Combination(n, duplicated) * Modular.Permutation(m, duplicated) * Modular.Pow(Modular.Permutation(m - duplicated, n - duplicated), 2);
            }

            yield return count.Value;
        }
    }
}
