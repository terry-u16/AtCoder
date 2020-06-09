using Training20200609.Questions;
using Training20200609.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200609.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc017/tasks/agc017_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nabcd = inputStream.ReadLongArray();
            var n = nabcd[0] - 1;
            var diff = Math.Abs(nabcd[1] - nabcd[2]);
            var c = nabcd[3];
            var d = nabcd[4];
            var midDoubled = c + d;
            var width = d - c;

            if (n % 2 == 0)
            {
                for (int i = 0; i * 2 <= n; i++)
                {
                    var small = midDoubled * i - width * n / 2;
                    var large = midDoubled * i + width * n / 2;

                    if (small <= diff && diff <= large)
                    {
                        yield return "YES";
                        yield break;
                    }
                }
            }
            else
            {
                var targetSmall = new long[] { -diff + c, diff + c };
                var targetLarge = new long[] { -diff + d, diff + d };

                for (int i = 0; i * 2 <= n; i++)
                {
                    var small = midDoubled * i - width * (n - 1) / 2;
                    var large = midDoubled * i + width * (n - 1) / 2;

                    for (int j = 0; j < 2; j++)
                    {
                        if ((targetSmall[j] <= small && small <= targetLarge[j]) || (targetSmall[j] <= large && large <= targetLarge[j]) || 
                            (small <= targetSmall[j] && targetSmall[j] <= large))
                        {
                            yield return "YES";
                            yield break;
                        }
                    }
                }
            }

            yield return "NO";
        }


    }
}
