using Yorukatsu057.Questions;
using Yorukatsu057.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu057.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc125/tasks/abc125_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var values = inputStream.ReadIntArray();
            var costs = inputStream.ReadIntArray();
            var diff = values.Zip(costs, (v, c) => v - c).Where(d => d > 0).Sum();

            yield return diff;
        }
    }
}
