using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200627.Algorithms;
using Training20200627.Collections;
using Training20200627.Extensions;
using Training20200627.Numerics;
using Training20200627.Questions;

namespace Training20200627.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc037/tasks/arc037_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadLongArray();
            var b = inputStream.ReadLongArray();
            Array.Sort(a);
            Array.Sort(b);

            var result = SearchExtensions.BoundaryBinarySearch(t =>
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    count += SearchExtensions.BoundaryBinarySearch(j => a[i] * b[j] <= t, -1, b.Length) + 1;
                }
                return count < k;
            }, 0, 1_000_000_000_000_000_001);
            yield return result + 1;
        }
    }
}
