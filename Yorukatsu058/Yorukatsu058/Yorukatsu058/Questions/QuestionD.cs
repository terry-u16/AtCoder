using Yorukatsu058.Questions;
using Yorukatsu058.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu058.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();

            if (n > 0)
            {
                for (int d = 1; d < 60; d += 2)
                {
                    if ((n & (1L << d)) > 0)
                    {
                        n += 1L << (d + 1);
                    }
                }

                yield return Convert.ToString(n, 2);
            }
            else if (n < 0)
            {
                n = -n;
                for (int d = 0; d < 60; d += 2)
                {
                    if ((n & (1L << d)) > 0)
                    {
                        n += 1L << (d + 1);
                    }
                }

                yield return Convert.ToString(n, 2);
            }
            else
            {
                yield return "0";
            }
        }
    }
}
