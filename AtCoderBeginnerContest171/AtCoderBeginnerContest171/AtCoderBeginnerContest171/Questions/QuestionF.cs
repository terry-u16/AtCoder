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
            Modular.InitializeCombinationTable(2500000);
            var count = Modular.Pow(26, k + s.Length) - Modular.CombinationWithRepetition(s.Length, k + s.Length) * Modular.Pow(26, k);
            yield return count.Value;
        }
    }
}
