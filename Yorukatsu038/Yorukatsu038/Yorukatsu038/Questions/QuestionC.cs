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
    /// ABC133 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var lr = inputStream.ReadIntArray();
            var l = lr[0];
            var r = lr[1];

            var min = long.MaxValue;
            for (long i = l; i < Math.Min(l + 2019, r); i++)
            {
                for (long j = i + 1; j <= Math.Min(l + 2019, r); j++)
                {
                    min = Math.Min(min, (i * j) % 2019);
                }
            }

            yield return min;
        }
    }
}
