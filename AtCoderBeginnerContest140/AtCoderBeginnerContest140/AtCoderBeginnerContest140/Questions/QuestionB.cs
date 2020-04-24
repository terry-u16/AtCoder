using AtCoderBeginnerContest140.Questions;
using AtCoderBeginnerContest140.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest140.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var b = inputStream.ReadIntArray();
            var c = inputStream.ReadIntArray();

            var sum = 0;
            var previous = int.MaxValue;
            foreach (var dish in a)
            {
                sum += b[dish];
                if (previous == dish - 1)
                {
                    sum += c[previous];
                }
                previous = dish;
            }

            yield return sum;
        }
    }
}
