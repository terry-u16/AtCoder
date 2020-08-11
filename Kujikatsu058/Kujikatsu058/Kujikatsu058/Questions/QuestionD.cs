using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu058.Algorithms;
using Kujikatsu058.Collections;
using Kujikatsu058.Extensions;
using Kujikatsu058.Numerics;
using Kujikatsu058.Questions;

namespace Kujikatsu058.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc031/tasks/agc031_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            var counts = new int[26];
            foreach (var c in s)
            {
                counts[c - 'a']++;
            }

            var result = Modular.One;

            foreach (var count in counts)
            {
                result *= count + 1;
            }

            yield return result - 1;
        }
    }
}
