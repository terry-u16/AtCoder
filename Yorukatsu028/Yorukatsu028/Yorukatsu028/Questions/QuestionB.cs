using Yorukatsu028.Questions;
using Yorukatsu028.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu028.Questions
{
    /// <summary>
    /// ARC073 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nt = inputStream.ReadIntArray();
            var n = nt[0];
            var duration = nt[1];
            var times = inputStream.ReadIntArray();

            long totalTime = 0;

            totalTime += duration;
            for (int i = 1; i < times.Length; i++)
            {
                var last = times[i] - times[i - 1];
                if (last < duration)
                {
                    totalTime += last;
                }
                else
                {
                    totalTime += duration;
                }
            }

            yield return totalTime;
        }
    }
}
