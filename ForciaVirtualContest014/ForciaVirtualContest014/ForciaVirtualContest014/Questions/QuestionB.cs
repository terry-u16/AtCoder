using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ForciaVirtualContest014.Algorithms;
using ForciaVirtualContest014.Collections;
using ForciaVirtualContest014.Extensions;
using ForciaVirtualContest014.Numerics;
using ForciaVirtualContest014.Questions;

namespace ForciaVirtualContest014.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc097/tasks/arc097_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var k = inputStream.ReadInt();
            var set = new SortedSet<string>(StringComparer.Ordinal);

            for (int length = 1; length <= Math.Min(s.Length, k); length++)
            {
                for (int shift = 0; shift <= s.Length - length; shift++)
                {
                    set.Add(s.Substring(shift, length));
                }
            }

            yield return set.Skip(k - 1).First();
        }
    }
}
