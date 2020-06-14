using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest170.Algorithms;
using AtCoderBeginnerContest170.Collections;
using AtCoderBeginnerContest170.Extensions;
using AtCoderBeginnerContest170.Numerics;
using AtCoderBeginnerContest170.Questions;

namespace AtCoderBeginnerContest170.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (sum, feet) = inputStream.ReadValue<int, int>();

            for (int tsuru = 0; tsuru <= sum; tsuru++)
            {
                var kame = sum - tsuru;
                if (2 * tsuru + 4 * kame == feet)
                {
                    yield return "Yes";
                    yield break;
                }
            }

            yield return "No";
        }
    }
}
