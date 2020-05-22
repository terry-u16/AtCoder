using Yorukatsu046.Questions;
using Yorukatsu046.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu046.Questions
{
    /// <summary>
    /// ABC154 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var st = inputStream.ReadLine().Split(' ').ToArray();
            var ab = inputStream.ReadIntArray();
            var u = inputStream.ReadLine();

            if (st[0] == u)
            {
                ab[0]--;
            }
            else
            {
                ab[1]--;
            }

            yield return $"{ab[0]} {ab[1]}";
        }
    }
}
