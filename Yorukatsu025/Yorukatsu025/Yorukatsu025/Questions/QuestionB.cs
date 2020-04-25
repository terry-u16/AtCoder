using Yorukatsu025.Questions;
using Yorukatsu025.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu025.Questions
{
    /// <summary>
    /// ABC064 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var colors = inputStream.ReadIntArray().Select(i => i / 400).ToArray(); // 0 ～ 12, 0～7は固定色

            var colorCount = colors.Where(i => i < 8).Distinct().Count();
            var wildColor = colors.Count(i => i >= 8);
            var min = Math.Max(colorCount, 1);
            var max = colorCount + wildColor;
            yield return $"{min} {max}";
        }
    }
}
