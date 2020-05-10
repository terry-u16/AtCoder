using AtCoderBeginnerContest167.Algorithms;
using AtCoderBeginnerContest167.Collections;
using AtCoderBeginnerContest167.Questions;
using AtCoderBeginnerContest167.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest167.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int mod = 998244353;
            var (blockCount, colorCount, maxPair) = inputStream.ReadValue<int, int, int>();

            var total = new Modular(0, mod);

            for (int i = 0; i <= maxPair; i++)
            {
                total += Modular.Combination(blockCount - 1, i, mod) * Modular.Pow(new Modular(colorCount - 1, mod), blockCount - i - 1) * new Modular(colorCount, mod);
            }

            yield return total.Value;
        }
    }
}
