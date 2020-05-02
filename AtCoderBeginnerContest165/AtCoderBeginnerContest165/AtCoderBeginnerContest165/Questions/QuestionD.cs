using AtCoderBeginnerContest165.Algorithms;
using AtCoderBeginnerContest165.Collections;
using AtCoderBeginnerContest165.Questions;
using AtCoderBeginnerContest165.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest165.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, n) = inputStream.ReadValue<long, long, long>();

            if (b == 1)
            {
                yield return 0;
                yield break;
            }

            decimal mod = Math.Min(b - 1, n);

            yield return (long)(Math.Floor(a * mod / b) - a * Math.Floor(mod / b));
        }
    }
}
