using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest178.Algorithms;
using AtCoderBeginnerContest178.Collections;
using AtCoderBeginnerContest178.Extensions;
using AtCoderBeginnerContest178.Numerics;
using AtCoderBeginnerContest178.Questions;

namespace AtCoderBeginnerContest178.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.InitializeCombinationTable();
            var s = inputStream.ReadInt();
            var result = Modular.Zero;

            for (int l = 1; l <= s / 3; l++)
            {
                var remain = s - l * 3;
                if (remain >= 0)
                {
                    result += Modular.CombinationWithRepetition(l, remain);
                }
            }

            yield return result;
        }
    }
}
