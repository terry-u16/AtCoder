using Asakatsu20200503.Questions;
using Asakatsu20200503.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Asakatsu20200503.Questions
{
    /// <summary>
    /// ABC094 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var n = a.Max();
            var r = a[0];
            foreach (var ai in a)
            {
                if (GetDistance(n, ai) >= GetDistance(n, r) && n != ai)
                {
                    r = ai;
                }
            }

            yield return $"{n} {r}";
        }

        int GetDistance(int n, int r) => Math.Min(n - r, r);
    }
}
