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
    /// https://atcoder.jp/contests/abc103/tasks/abc103_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            yield return a.Sum(i => i - 1);
        }
    }
}
