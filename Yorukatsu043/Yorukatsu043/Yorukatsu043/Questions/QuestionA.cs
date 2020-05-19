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
    /// ABC158 C
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            var a = ab[0];
            var b = ab[1];

            for (int i = 0; i <= 10000; i++)
            {
                if (i * 8 / 100 == a && i * 10 / 100 == b)
                {
                    yield return i;
                    yield break;
                }
            }

            yield return -1;
        }
    }
}
