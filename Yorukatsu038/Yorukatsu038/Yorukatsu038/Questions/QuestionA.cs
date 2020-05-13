using Yorukatsu038.Questions;
using Yorukatsu038.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu038.Questions
{
    /// <summary>
    /// ABC103 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = new LinkedList<char>(inputStream.ReadLine());
            var t = inputStream.ReadLine();

            for (int i = 0; i < t.Length; i++)
            {
                if (s.Zip(t, (a, b) => new { a, b }).All(p => p.a == p.b))
                {
                    yield return "Yes";
                    yield break;
                }
                s.AddLast(s.First.Value);
                s.RemoveFirst();
            }
            yield return "No";
        }
    }
}
