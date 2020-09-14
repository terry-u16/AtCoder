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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c, d) = inputStream.ReadValue<long, long, long, long>();

            var max = long.MinValue;

            if ((a <= 0 && 0 <= b) || (c <= 0 && 0 <= d))
            {
                max = 0;
            }

            max = Math.Max(max, a * c);
            max = Math.Max(max, b * c);
            max = Math.Max(max, a * d);
            max = Math.Max(max, b * d);

            yield return max;
        }
    }
}
