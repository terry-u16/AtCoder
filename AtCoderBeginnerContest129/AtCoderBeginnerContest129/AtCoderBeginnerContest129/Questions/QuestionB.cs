using AtCoderBeginnerContest129.Questions;
using AtCoderBeginnerContest129.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest129.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var weights = inputStream.ReadIntArray();

            var sum = weights.Sum();
            var partialSum = 0;
            var min = int.MaxValue;

            foreach (var weight in weights)
            {
                partialSum += weight;
                min = Math.Min(Math.Abs(sum - 2 * partialSum), min);
            }

            yield return min;
        }
    }
}
