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
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (x, n) = inputStream.ReadValue<int, int>();

            if (n == 0)
            {
                yield return x;
                yield break;
            }

            var p = inputStream.ReadIntArray();

            var minAbs = int.MaxValue;
            var min = -1;
            for (int i = 0; i <= 101; i++)
            {
                var abs = Math.Abs(x - i);
                if (!p.Contains(i) && abs < minAbs)
                {
                    minAbs = abs;
                    min = i;
                }
            }

            yield return min;
        }
    }
}
