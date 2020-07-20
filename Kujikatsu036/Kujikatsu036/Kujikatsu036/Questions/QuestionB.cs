using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu036.Algorithms;
using Kujikatsu036.Collections;
using Kujikatsu036.Extensions;
using Kujikatsu036.Numerics;
using Kujikatsu036.Questions;

namespace Kujikatsu036.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc109/tasks/abc109_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var spokens = new HashSet<string>();
            var word = inputStream.ReadLine();
            spokens.Add(word);
            var last = word[^1];

            for (int i = 1; i < n; i++)
            {
                word = inputStream.ReadLine();
                if (!spokens.Add(word) || last != word[0])
                {
                    yield return "No";
                    yield break;
                }
                last = word[^1];
            }

            yield return "Yes";
        }
    }
}
