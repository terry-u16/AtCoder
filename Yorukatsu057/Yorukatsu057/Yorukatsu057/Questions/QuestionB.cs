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
    /// https://atcoder.jp/contests/abc106/tasks/abc106_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var k = inputStream.ReadLong();
            var oneCount = s.TakeWhile(c => c == '1').Count();

            if (oneCount >= k)
            {
                yield return '1';
            }
            else
            {
                yield return s.SkipWhile(c => c == '1').First();
            }
        }
    }
}
