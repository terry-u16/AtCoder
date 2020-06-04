using Yorukatsu056.Questions;
using Yorukatsu056.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu056.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc077/tasks/abc077_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s1 = inputStream.ReadLine();
            var s2 = inputStream.ReadLine();

            for (int i = 0; i < 3; i++)
            {
                if (s1[i] != s2[2 - i])
                {
                    yield return "NO";
                    yield break;
                }
            }

            yield return "YES";
        }
    }
}
