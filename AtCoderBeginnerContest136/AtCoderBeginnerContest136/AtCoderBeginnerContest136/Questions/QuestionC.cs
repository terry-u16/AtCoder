using AtCoderBeginnerContest136.Questions;
using AtCoderBeginnerContest136.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest136.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var h = inputStream.ReadIntArray();

            for (int i = 0; i < h.Length - 1; i++)
            {
                if (h[i + 1] > h[i])
                {
                    h[i + 1] -= 1;
                }
                else if (h[i + 1] < h[i])
                {
                    yield return "No";
                    yield break;
                }
            }
            yield return "Yes";
        }
    }
}
