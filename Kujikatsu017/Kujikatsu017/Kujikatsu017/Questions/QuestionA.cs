using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu017.Algorithms;
using Kujikatsu017.Collections;
using Kujikatsu017.Extensions;
using Kujikatsu017.Numerics;
using Kujikatsu017.Questions;

namespace Kujikatsu017.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc164/tasks/abc164_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                set.Add(inputStream.ReadLine());
            }
            yield return set.Count;
        }
    }
}
