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

namespace Kujikatsu008.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc045/tasks/abc045_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = Enumerable.Range(0, 3).Select(_ => new Queue<int>()).ToArray();
            for (int i = 0; i < 3; i++)
            {
                s[i] = new Queue<int>(inputStream.ReadLine().Select(c => c - 'a'));
            }

            var next = 0;
            while (s[next].Count > 0)
            {
                next = s[next].Dequeue();
            }

            yield return (char)(next + 'A');
        }
    }
}
