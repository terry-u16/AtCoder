using Yorukatsu045.Questions;
using Yorukatsu045.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu045.Questions
{
    /// <summary>
    /// ABC134 C
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = new List<int>();
            var sorted = new List<int>();
            for (int i = 0; i < n; i++)
            {
                var input = inputStream.ReadInt();
                a.Add(input);
                sorted.Add(input);
            }

            sorted.Sort();
            var last = sorted[sorted.Count - 1];
            var secondLast = sorted[sorted.Count - 2];

            for (int i = 0; i < n; i++)
            {
                if (a[i] != last)
                {
                    yield return last;
                }
                else
                {
                    yield return secondLast;
                }
            }
        }
    }
}
