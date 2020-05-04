using Yorukatsu031.Questions;
using Yorukatsu031.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu031.Questions
{
    /// <summary>
    /// ABC072 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var dictionary = new Dictionary<int, int>();
            foreach (var ai in a)
            {
                if (dictionary.ContainsKey(ai))
                {
                    dictionary[ai]++;
                }
                else
                {
                    dictionary.Add(ai, 1);
                }
            }

            var max = 0;
            for (int x = 0; x <= 100000; x++)
            {
                var count = 0;
                for (int delta = -1; delta <= 1; delta++)
                {
                    int currentCount;
                    dictionary.TryGetValue(x + delta, out currentCount);
                    count += currentCount;
                }
                max = Math.Max(max, count);
            }

            yield return max;
        }
    }
}
