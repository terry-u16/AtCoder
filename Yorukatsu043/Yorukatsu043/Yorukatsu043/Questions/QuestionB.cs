using Yorukatsu043.Questions;
using Yorukatsu043.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu043.Questions
{
    /// <summary>
    /// ABC136 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var h = inputStream.ReadIntArray();

            h[0]--;

            for (int i = 1; i < h.Length; i++)
            {
                if (h[i] > h[i - 1])
                {
                    h[i]--;
                }
                else if (h[i] < h[i - 1])
                {
                    yield return "No";
                    yield break;
                }
            }

            yield return "Yes";
        }
    }
}
