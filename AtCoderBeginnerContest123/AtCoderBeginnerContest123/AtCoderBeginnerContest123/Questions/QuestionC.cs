using AtCoderBeginnerContest123.Questions;
using AtCoderBeginnerContest123.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest123.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var people = inputStream.ReadLong();
            var capacities = new long[5];

            for (int i = 0; i < 5; i++)
            {
                capacities[i] = inputStream.ReadLong();
            }

            var neckCapacity = capacities.Min();

            yield return Math.Ceiling((decimal)people / neckCapacity) + 4;
        }
    }
}
