using Yorukatsu019.Questions;
using Yorukatsu019.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu019.Questions
{
    /// <summary>
    /// ABC137 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var count = new Dictionary<string, long>();

            for (int i = 0; i < n; i++)
            {
                var temp = inputStream.ReadLine().ToCharArray();
                Array.Sort(temp);
                var s = string.Concat(temp);

                if (count.ContainsKey(s))
                {
                    count[s]++;
                }
                else
                {
                    count.Add(s, 1);
                }
            }

            // nP2
            yield return count.Sum(p => p.Value * (p.Value - 1) / 2);
        }
    }
}
