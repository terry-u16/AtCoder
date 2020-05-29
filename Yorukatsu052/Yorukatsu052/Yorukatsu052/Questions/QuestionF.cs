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
    /// https://atcoder.jp/contests/arc088/tasks/arc088_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            if (s.Length == 1)
            {
                yield return 1;
                yield break;
            }

            int fromLeft;
            for (fromLeft = (s.Length - 1) / 2; fromLeft + 1 < s.Length; fromLeft++)
            {
                if (s[fromLeft] != s[fromLeft + 1])
                {
                    break;
                }
            }

            int fromRight;
            for (fromRight = (s.Length - 1) / 2; fromRight + 1 < s.Length; fromRight++)
            {
                if (s[s.Length - fromRight - 1] != s[s.Length - fromRight - 2])
                {
                    break;
                }
            }

            yield return Math.Min(fromLeft + 1, fromRight + 1);
        }
    }
}
