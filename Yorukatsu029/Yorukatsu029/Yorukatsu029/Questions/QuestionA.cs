using Yorukatsu029.Questions;
using Yorukatsu029.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu029.Questions
{
    /// <summary>
    /// ABC130 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nx = inputStream.ReadIntArray();
            var n = nx[0];
            var x = nx[1];
            var l = inputStream.ReadIntArray();

            var totalDistance = 0;
            for (int i = 0; i < l.Length; i++)
            {
                totalDistance += l[i];
                if (totalDistance > x)
                {
                    yield return i + 1;
                    yield break;
                }
            }
            yield return n + 1;
        }
    }
}
