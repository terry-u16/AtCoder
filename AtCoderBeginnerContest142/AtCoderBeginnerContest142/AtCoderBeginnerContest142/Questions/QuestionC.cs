using AtCoderBeginnerContest142.Questions;
using AtCoderBeginnerContest142.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest142.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                dictionary.Add(i + 1, a[i]);
            }

            yield return string.Join(" ", dictionary.OrderBy(p => p.Value).Select(p => p.Key));
        }
    }
}
