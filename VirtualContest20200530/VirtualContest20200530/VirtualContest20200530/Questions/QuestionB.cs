using VirtualContest20200530.Questions;
using VirtualContest20200530.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VirtualContest20200530.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dwacon2017-prelims/tasks/dwango2017qual_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var counts = new int[4];

            for (int i = 0; i < n; i++)
            {
                counts[inputStream.ReadInt() - 1]++;
            }

            var total = 0;
            total += counts[3];
            total += counts[2];
            counts[0] -= Math.Min(counts[0], counts[2]);

            if (counts[1] % 2 == 0)
            {
                total += counts[1] / 2;
            }
            else
            {
                total += (counts[1] + 1) / 2;
                counts[0] -= Math.Min(counts[0], 2);
            }

            total += (counts[0] + 3) / 4;

            yield return total;
        }
    }
}
