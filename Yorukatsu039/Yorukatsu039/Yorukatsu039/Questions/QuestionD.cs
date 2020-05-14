using Yorukatsu039.Questions;
using Yorukatsu039.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu039.Questions
{
    /// <summary>
    /// ARC100 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] -= i;
            }
            Array.Sort(a);
            yield return a.Sum(i => Math.Abs(i - a[a.Length / 2]));
        }
    }
}
