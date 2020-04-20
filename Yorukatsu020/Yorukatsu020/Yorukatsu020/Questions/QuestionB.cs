using Yorukatsu020.Questions;
using Yorukatsu020.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu020.Questions
{
    /// <summary>
    /// ABC100 B
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var dn = inputStream.ReadLongArray();
            var d = dn[0];
            var n = dn[1];

            if (n == 100)
            {
                switch (d)
                {
                    case 0:
                        yield return 101;
                        yield break;
                    case 1:
                        yield return 10100;
                        yield break;
                    case 2:
                        yield return 1010000;
                        yield break;
                    default:
                        break;
                }
            }
            else
            {
                var number = n;

                for (int i = 0; i < d; i++)
                {
                    number *= 100;
                }

                yield return number;
            }
        }
    }
}
