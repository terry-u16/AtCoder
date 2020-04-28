using AtCoderBeginnerContest135.Questions;
using AtCoderBeginnerContest135.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest135.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();

            long totalMonsterCount = 0L;
            for (int city = 0; city < b.Length; city++)
            {
                if (a[city] > 0)
                {
                    var monsters = Math.Min(a[city], b[city]);
                    a[city] -= monsters;
                    b[city] -= monsters;
                    totalMonsterCount += monsters;
                }

                if (a[city + 1] > 0)
                {
                    var monsters = Math.Min(a[city + 1], b[city]);
                    a[city + 1] -= monsters;
                    b[city] -= monsters;
                    totalMonsterCount += monsters;
                }
            }

            yield return totalMonsterCount;
        }
    }
}
