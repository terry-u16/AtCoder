using Yorukatsu055.Questions;
using Yorukatsu055.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu055.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc067/tasks/abc067_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            if (CanDivideBy3(ab[0]) || CanDivideBy3(ab[1]) || CanDivideBy3(ab[0] + ab[1]))
            {
                yield return "Possible";
            }
            else
            {
                yield return "Impossible";
            }
        }

        bool CanDivideBy3(int n) => n % 3 == 0;
    }
}
