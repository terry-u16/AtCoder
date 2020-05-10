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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c, k) = inputStream.ReadValue<long, long, long, long>();

            var point = Math.Min(a, k);
            k -= a;
            k -= b;
            if (k > 0)
            {
                point -= Math.Min(c, k);
            }

            yield return point;
        }
    }
}
