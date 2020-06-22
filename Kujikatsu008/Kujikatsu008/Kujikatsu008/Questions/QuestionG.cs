using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu008.Algorithms;
using Kujikatsu008.Collections;
using Kujikatsu008.Extensions;
using Kujikatsu008.Numerics;
using Kujikatsu008.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu008.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc150/tasks/abc150_f
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();

            for (int k = 0; k < a.Length; k++)
            {
                var aDash = new int[a.Length];
                for (int i = 0; i < aDash.Length; i++)
                {
                    aDash[i] = a[(i + k) % a.Length] ^ b[i];
                }

                if (aDash.All(ai => ai == aDash[0]))
                {
                    yield return $"{k} {aDash[0]}";
                }
            }
        }
    }
}
