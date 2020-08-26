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
    /// https://atcoder.jp/contests/abc032/tasks/abc032_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var k = inputStream.ReadInt();
            var set = new HashSet<string>();

            if (s.Length < k)
            {
                yield return 0;
            }
            else
            {
                for (int i = 0; i <= s.Length - k; i++)
                {
                    set.Add(s.Substring(i, k));
                }

                yield return set.Count;
            }
        }
    }
}
