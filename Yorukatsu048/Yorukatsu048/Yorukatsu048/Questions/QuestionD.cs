using Yorukatsu048.Questions;
using Yorukatsu048.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu048.Questions
{
    /// <summary>
    /// ABC160 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nxy = inputStream.ReadIntArray();
            var n = nxy[0];
            var x = nxy[1] - 1;
            var y = nxy[2] - 1;

            var count = new int[n];
            for (int i = 0; i + 1 < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    var normal = j - i;
                    var shortCut = Math.Abs(x - i) + 1 + Math.Abs(j - y);
                    count[Math.Min(normal, shortCut)]++;
                }
            }

            for (int i = 1; i <= n - 1; i++)
            {
                yield return count[i];
            }
        }
    }
}
