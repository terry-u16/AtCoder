using Yorukatsu029.Questions;
using Yorukatsu029.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu029.Questions
{
    /// <summary>
    /// ABC135 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var monsterCounts = inputStream.ReadLongArray();
            var bravePower = inputStream.ReadLongArray();

            long totalCount = 0;
            for (int i = 0; i < n; i++)
            {
                long count1 = Math.Min(monsterCounts[i], bravePower[i]);
                bravePower[i] -= count1;
                long count2 = Math.Min(monsterCounts[i + 1], bravePower[i]);
                monsterCounts[i + 1] -= count2;
                totalCount += count1 + count2;
            }

            yield return totalCount;
        }
    }
}
