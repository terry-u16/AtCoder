using Yorukatsu043.Questions;
using Yorukatsu043.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu043.Questions
{
    /// <summary>
    /// ARC093 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = new[] { 0 }.Concat(inputStream.ReadIntArray()).Concat(new[] { 0 }).ToArray();

            var sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += Math.Abs(a[i + 1] - a[i]);
            }

            for (int i = 1; i <= n; i++)
            {
                yield return sum - (Math.Abs(a[i + 1] - a[i]) + Math.Abs(a[i] - a[i - 1])) + Math.Abs(a[i + 1] - a[i - 1]);
            }
        }
    }
}
