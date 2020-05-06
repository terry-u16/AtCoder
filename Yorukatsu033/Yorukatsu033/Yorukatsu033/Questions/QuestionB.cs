using Yorukatsu033.Questions;
using Yorukatsu033.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu033.Questions
{
    /// <summary>
    /// ABC065 B
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = inputStream.ReadInt() - 1;
            }

            var current = 0;
            var count = 0;
            var pushed = new HashSet<int>();
            pushed.Add(current);

            while (current != 1)
            {
                current = a[current];
                if (pushed.Contains(current))
                {
                    yield return -1;
                    yield break;
                }

                pushed.Add(current);
                count++;
            }

            yield return count;
        }
    }
}
