using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200818.Algorithms;
using Training20200818.Collections;
using Training20200818.Extensions;
using Training20200818.Numerics;
using Training20200818.Questions;

namespace Training20200818.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/cf17-final/tasks/cf17_final_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var counts = new int[3];

            foreach (var c in s)
            {
                counts[c - 'a']++;
            }

            Array.Sort(counts);

            if (counts[2] - counts[0] <= 1)
            {
                yield return "YES";
            }
            else
            {
                yield return "NO";
            }
        }
    }
}
