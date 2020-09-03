using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu20200830.Algorithms;
using Kujikatsu20200830.Collections;
using Kujikatsu20200830.Extensions;
using Kujikatsu20200830.Numerics;
using Kujikatsu20200830.Questions;

namespace Kujikatsu20200830.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc028/tasks/abc028_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();

            var candidates = new List<int>();

            for (int i = 0; i < abc.Length; i++)
            {
                for (int j = i + 1; j < abc.Length; j++)
                {
                    for (int k = j + 1; k < abc.Length; k++)
                    {
                        candidates.Add(abc[i] + abc[j] + abc[k]);
                    }
                }
            }

            candidates.Sort((a, b) => b - a);

            yield return candidates[2];
        }
    }
}
