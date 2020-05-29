using Yorukatsu052.Questions;
using Yorukatsu052.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu052.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc060/tasks/abc060_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();
            var a = abc[0];
            var b = abc[1];
            var c = abc[2];

            var mod = a % b;
            for (int i = 0; i <= b; i++)
            {
                if (mod * i % b == c)
                {
                    yield return "YES";
                    yield break;
                }
            }

            yield return "NO";
        }
    }
}
