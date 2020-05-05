using Yorukatsu032.Questions;
using Yorukatsu032.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu032.Questions
{
    /// <summary>
    /// ABC080 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var opens = new bool[n][];
            var profits = new long[n][];

            for (int i = 0; i < n; i++)
            {
                opens[i] = inputStream.ReadIntArray().Select(j => j == 1).ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                profits[i] = inputStream.ReadLongArray();
            }

            var totalProfits = new long[1 << 10];

            for (int openFlag = 1; openFlag < 1 << 10; openFlag++)
            {
                var profit = 0L;
                for (int store = 0; store < n; store++)
                {
                    var openCount = 0;
                    for (int time = 0; time < 10; time++)
                    {
                        if (((1 << time) & openFlag) > 0)
                        {
                            if (opens[store][time])
                            {
                                openCount++;
                            }
                        }
                    }
                    profit += profits[store][openCount];
                }
                totalProfits[openFlag] = profit;
            }

            yield return totalProfits.Skip(1).Max();
        }
    }
}
