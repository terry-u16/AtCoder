using Yorukatsu016.Questions;
using Yorukatsu016.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu016.Questions
{
    /// <summary>
    /// ABC078 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            var pAcc = 1m;
            for (int i = 0; i < m; i++)
            {
                pAcc *= 0.5m;
            }
            var pRej = 1 - pAcc;

            var eachTime = 100 * (n - m) + 1900 * m;

            yield return (int)(pAcc * eachTime / (pAcc * pAcc));
        }
    }
}
