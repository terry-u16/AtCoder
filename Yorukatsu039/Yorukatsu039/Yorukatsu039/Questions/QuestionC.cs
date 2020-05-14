using Yorukatsu039.Questions;
using Yorukatsu039.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu039.Questions
{
    /// <summary>
    /// ABC111 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var v = inputStream.ReadIntArray();
            var oddCounts = Count(0, v).OrderByDescending(p => p.Value).ToArray();
            var evenCounts = Count(1, v).OrderByDescending(p => p.Value).ToArray();

            if (oddCounts[0].Key != evenCounts[0].Key)
            {
                yield return v.Length - (oddCounts[0].Value + evenCounts[0].Value);
            }
            else if (oddCounts[1].Value > evenCounts[1].Value)
            {
                yield return v.Length - (oddCounts[1].Value + evenCounts[0].Value);
            }
            else
            {
                yield return v.Length - (oddCounts[0].Value + evenCounts[1].Value);
            }
        }

        public Dictionary<int, int> Count(int startIndex, int[] array)
        {
            var counts = new Dictionary<int, int>();
            counts[-1] = 0;
            for (int i = startIndex; i < array.Length; i += 2)
            {
                var current = array[i];
                if (counts.ContainsKey(current))
                {
                    counts[current]++;
                }
                else
                {
                    counts[current] = 1;
                }
            }
            return counts;
        }
    }
}
