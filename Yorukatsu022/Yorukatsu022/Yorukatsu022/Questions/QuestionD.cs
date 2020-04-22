using Yorukatsu022.Questions;
using Yorukatsu022.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu022.Questions
{
    /// <summary>
    /// ABC127 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            var a = inputStream.ReadIntArray();

            var cards = new Dictionary<int, int>();

            foreach (var ai in a)
            {
                if (!cards.ContainsKey(ai))
                {
                    cards[ai] = 0;
                }

                cards[ai]++;
            }

            for (int i = 0; i < m; i++)
            {
                var bc = inputStream.ReadIntArray();
                var b = bc[0];
                var c = bc[1];

                if (!cards.ContainsKey(c))
                {
                    cards[c] = 0;
                }

                cards[c] += b;
            }

            long sum = 0;
            foreach (var card in cards.OrderByDescending(p => p.Key))
            {
                var number = card.Key;
                if (card.Value > 0)
                {
                    var take = Math.Min(card.Value, n);
                    sum += (long)number * take;
                    n -= take;

                    if (n == 0)
                    {
                        break;
                    }
                }
            }

            yield return sum;
        }
    }
}
