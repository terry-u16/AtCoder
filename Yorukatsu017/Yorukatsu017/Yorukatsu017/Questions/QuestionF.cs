using Yorukatsu017.Questions;
using Yorukatsu017.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu017.Questions
{
    /// <summary>
    /// ABC149 E
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            var a = inputStream.ReadIntArray();

            Array.Sort(a);
            Array.Reverse(a);   // 降順

            var lowerN = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i * i <= m)
                {
                    lowerN = i;
                }
                else
                {
                    break;
                }
            }

            // lowerN人目まで。一人当たり2*lowerN回握手
            var happiness = a.Take(lowerN).Sum(i => i * 2 * lowerN);

            // 残り握手回数
            var rest = m - lowerN * lowerN;

            for (int i = 0; i < rest; i++)
            {
                happiness += a[i / 2] + a[lowerN];
            }

            yield return happiness;
        }
    }
}
