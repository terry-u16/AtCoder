using Yorukatsu046.Questions;
using Yorukatsu046.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu046.Questions
{
    /// <summary>
    /// ABC135 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var monsters = inputStream.ReadIntArray();
            var braverPower = inputStream.ReadIntArray();
            var sum = 0L;

            for (int i = 0; i < braverPower.Length; i++)
            {
                var killed = Math.Min(monsters[i], braverPower[i]);
                braverPower[i] -= killed;
                sum += killed;
                killed = Math.Min(monsters[i + 1], braverPower[i]);
                monsters[i + 1] -= killed;
                sum += killed;
            }

            yield return sum;
        }
    }
}
