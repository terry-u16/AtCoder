using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest171.Algorithms;
using AtCoderBeginnerContest171.Collections;
using AtCoderBeginnerContest171.Extensions;
using AtCoderBeginnerContest171.Numerics;
using AtCoderBeginnerContest171.Questions;

namespace AtCoderBeginnerContest171.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            var sum = Modular.Zero;
            Modular.InitializeCombinationTable(2500000);

            for (int taken = 0; taken <= k; taken++)
            {
                sum += Modular.CombinationWithRepetition(taken + 1, s.Length - 1) * Modular.Pow(25, taken) * Modular.Pow(26, k - taken);
            }

            yield return sum.Value;
        }
    }
}
