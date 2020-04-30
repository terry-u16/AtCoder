using AtCoderBeginnerContest133.Questions;
using AtCoderBeginnerContest133.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest133.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var lr = inputStream.ReadIntArray();
            var l = lr[0];
            var r = lr[1];

            var diff = r - l;

            l = l % 2019;
            r = l + Math.Min(diff, 2019);

            var min = int.MaxValue;
            for (int i = l; i < r; i++)
            {
                for (int j = i + 1; j <= r; j++)
                {
                    min = Math.Min(min, (i * j) % 2019);
                }
            }

            yield return min;
        }
    }
}
