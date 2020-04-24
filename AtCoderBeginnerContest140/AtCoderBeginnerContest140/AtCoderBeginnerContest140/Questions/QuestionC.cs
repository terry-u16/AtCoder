using AtCoderBeginnerContest140.Questions;
using AtCoderBeginnerContest140.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest140.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            int n = inputStream.ReadInt();
            var b = inputStream.ReadIntArray();

            var sum = b[0];
            for (int i = 1; i < b.Length; i++)
            {
                sum += Math.Min(b[i - 1], b[i]);
            }
            sum += b[b.Length - 1];

            yield return sum;
        }
    }
}
