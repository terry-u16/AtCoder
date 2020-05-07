using Yorukatsu034.Questions;
using Yorukatsu034.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu034.Questions
{
    /// <summary>
    /// ABC098 B
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            yield return Enumerable.Range(1, s.Length - 1).Max(i =>
            {
                var x = s.Substring(0, i);
                var y = s.Substring(i);
                var xChars = new HashSet<char>(x);
                var yChars = new HashSet<char>(y);
                xChars.IntersectWith(yChars);
                return xChars.Count;
            });
        }
    }
}
