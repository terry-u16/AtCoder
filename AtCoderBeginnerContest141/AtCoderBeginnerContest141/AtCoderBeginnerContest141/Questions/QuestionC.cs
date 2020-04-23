using AtCoderBeginnerContest141.Questions;
using AtCoderBeginnerContest141.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest141.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nkq = inputStream.ReadIntArray();
            var n = nkq[0];
            var k = nkq[1];
            var q = nkq[2];

            var points = new int[n];

            for (int i = 0; i < q; i++)
            {
                var a = inputStream.ReadInt() - 1;
                points[a]++;
            }

            var ifAllLose = k - q;
            foreach (var point in points)
            {
                if (point + ifAllLose > 0)
                {
                    yield return "Yes";
                }
                else
                {
                    yield return "No";
                }
            }
        }
    }
}
