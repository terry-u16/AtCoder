using Yorukatsu051.Questions;
using Yorukatsu051.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu051.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc048/tasks/abc048_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abx = inputStream.ReadLongArray();
            var a = abx[0];
            var b = abx[1];
            var x = abx[2];

            if (a == 0)
            {
                if (b == 0)
                {
                    yield return 1;
                }
                else
                {
                    yield return b / x + 1;
                }
            }
            else
            {
                yield return b / x - (a - 1) / x;
            }
        }
    }
}
