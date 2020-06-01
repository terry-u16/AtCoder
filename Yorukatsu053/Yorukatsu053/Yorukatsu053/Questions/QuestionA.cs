using Yorukatsu053.Questions;
using Yorukatsu053.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc076/tasks/abc076_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var k = inputStream.ReadInt();

            var current = 1;
            for (int i = 0; i < n; i++)
            {
                if (current < k)
                {
                    current *= 2;
                }
                else
                {
                    current += k;
                }
            }

            yield return current;
        }
    }
}
