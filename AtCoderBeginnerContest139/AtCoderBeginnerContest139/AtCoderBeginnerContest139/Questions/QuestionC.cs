using AtCoderBeginnerContest139.Questions;
using AtCoderBeginnerContest139.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest139.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var h = inputStream.ReadIntArray();

            var steps = 0;
            var maxSteps = 0;

            for (int i = 0; i < h.Length - 1; i++)
            {
                if (h[i] >= h[i + 1])
                {
                    maxSteps = Math.Max(maxSteps, ++steps);
                }
                else
                {
                    steps = 0;
                }
            }

            yield return maxSteps;
        }
    }
}
