using Yorukatsu022.Questions;
using Yorukatsu022.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu022.Questions
{
    /// <summary>
    /// ABC060 B
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();
            var a = abc[0];
            var b = abc[1];
            var c = abc[2];

            for (int i = 1; i <= b; i++)
            {
                if ((a * i) % b == c)
                {
                    yield return "YES";
                    yield break;
                }
            }

            yield return "NO";
        }
    }
}
