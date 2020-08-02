using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest174.Algorithms;
using AtCoderBeginnerContest174.Collections;
using AtCoderBeginnerContest174.Extensions;
using AtCoderBeginnerContest174.Numerics;
using AtCoderBeginnerContest174.Questions;

namespace AtCoderBeginnerContest174.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, d) = inputStream.ReadValue<int, long>();

            var count = 0;
            var squared = d * d;

            for (int i = 0; i < n; i++)
            {
                var (x, y) = inputStream.ReadValue<long, long>();
                if (x * x + y * y <= squared)
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
