using Yorukatsu050.Questions;
using Yorukatsu050.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc156/tasks/abc156_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nr = inputStream.ReadIntArray();
            var n = nr[0];
            var rating = nr[1];

            if (n >= 10)
            {
                yield return rating;
            }
            else
            {
                yield return rating + 100 * (10 - n);
            }
        }
    }
}
