using Yorukatsu044.Questions;
using Yorukatsu044.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu044.Questions
{
    /// <summary>
    /// ABC130 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var whxy = inputStream.ReadIntArray();
            long w = whxy[0];
            long h = whxy[1];
            long x = whxy[2];
            long y = whxy[3];

            var half = w * h / 2.0;
            var canDivideArbitrarily = w == x * 2 && h == y * 2;
            yield return $"{half} {(canDivideArbitrarily ? 1 : 0)}";
        }
    }
}
