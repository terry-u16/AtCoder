using Yorukatsu036.Questions;
using Yorukatsu036.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu036.Questions
{
    /// <summary>
    /// ABC091 B
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var counts = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var s = inputStream.ReadLine();
                if (counts.ContainsKey(s))
                {
                    counts[s]++;
                }
                else
                {
                    counts.Add(s, 1);
                }
            }

            var m = inputStream.ReadInt();
            
            for (int i = 0; i < m; i++)
            {
                var s = inputStream.ReadLine();
                if (counts.ContainsKey(s))
                {
                    counts[s]--;
                }
                else
                {
                    counts.Add(s, -1);
                }
            }

            yield return Math.Max(counts.Max(p => p.Value), 0);
        }
    }
}
