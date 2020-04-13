using AtCoderBeginnerContest154.Questions;
using AtCoderBeginnerContest154.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest154.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            Array.Sort(a);

            for (int i = 0; i < n - 1; i++)
            {
                if (a[i] == a[i + 1])
                {
                    yield return "NO";
                    yield break;
                }
            }
            yield return "YES";
        }
    }
}
