using AtCoderBeginnerContest162.Algorithms;
using AtCoderBeginnerContest162.Collections;
using AtCoderBeginnerContest162.Questions;
using AtCoderBeginnerContest162.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest162.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                {
                    sum += i;
                }
            }

            yield return sum;
        }
    }
}
