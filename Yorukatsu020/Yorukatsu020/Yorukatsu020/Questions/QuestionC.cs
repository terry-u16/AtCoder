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
    /// ABC086 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];

            var a = inputStream.ReadIntArray();

            var balls = new Dictionary<int, int>();

            foreach (var ai in a)
            {
                if (balls.ContainsKey(ai))
                {
                    balls[ai]++;
                }
                else
                {
                    balls.Add(ai, 1);
                }
            }

            var various = balls.Count;
            if (various <= k)
            {
                yield return 0;
            }
            else
            {
                var orderedBalls = balls.OrderBy(b => b.Value).ToArray();
                yield return orderedBalls.Take(various - k).Sum(b => b.Value);
            }
        }
    }
}
