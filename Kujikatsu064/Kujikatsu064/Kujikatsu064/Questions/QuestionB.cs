using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu064.Algorithms;
using Kujikatsu064.Collections;
using Kujikatsu064.Extensions;
using Kujikatsu064.Numerics;
using Kujikatsu064.Questions;

namespace Kujikatsu064.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc089/tasks/abc089_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var arares = inputStream.ReadLine().Split(' ').Select(s => s[0]);
            var set = new HashSet<char>();

            foreach (var arare in arares)
            {
                set.Add(arare);
            }

            yield return set.Count == 3 ? "Three" : "Four";
        }
    }
}
