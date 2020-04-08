using AtcoderBeginnerContest160.Questions;
using AtcoderBeginnerContest160.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtcoderBeginnerContest160.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var kn = inputStream.ReadIntArray();
            var k = kn[0];
            var n = kn[1];
            var a = inputStream.ReadIntArray();
            var distances = new int[n];

            for (int i = 0; i < distances.Length - 1; i++)
            {
                distances[i] = a[i + 1] - a[i];
            }

            distances[distances.Length - 1] = k + a[0] - a[a.Length - 1];

            yield return k - distances.Max(i => i);
        }
    }
}
