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
    /// https://atcoder.jp/contests/abc132/tasks/abc132_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine().ToList();
            s.Sort();
            yield return s[0] == s[1] && s[1] != s[2] && s[2] == s[3] ? "Yes" : "No";
        }
    }
}
