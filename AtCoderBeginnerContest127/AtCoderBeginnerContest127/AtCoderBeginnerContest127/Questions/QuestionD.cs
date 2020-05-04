using AtCoderBeginnerContest127.Questions;
using AtCoderBeginnerContest127.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest127.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var cards = nm[0];
            var rewriteCount = nm[1];
            var a = inputStream.ReadIntArray();
            var count = new Dictionary<int, int>();

            foreach (var card in a)
            {
                if (count.ContainsKey(card))
                {
                    count[card]++;
                }
                else
                {
                    count.Add(card, 1);
                }
            }

            for (int i = 0; i < rewriteCount; i++)
            {
                var bc = inputStream.ReadIntArray();

                if (count.ContainsKey(bc[1]))
                {
                    count[bc[1]] += bc[0];
                }
                else
                {
                    count.Add(bc[1], bc[0]);
                }

            }

            long available = cards;
            long sum = 0;

            foreach (var pair in count.OrderByDescending(p => p.Key))
            {
                long take = Math.Min(pair.Value, available);
                sum += pair.Key * take;
                available -= take;
                if (available == 0)
                {
                    break;
                }
            }

            yield return sum;
        }

    }
}
