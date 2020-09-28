using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu102.Algorithms;
using Kujikatsu102.Collections;
using Kujikatsu102.Numerics;
using Kujikatsu102.Questions;

namespace Kujikatsu102.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc093/tasks/arc093_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var result = Enumerable.Repeat(0, 100)
                                   .Select(_ => Enumerable.Repeat('.', 50).Concat(Enumerable.Repeat('#', 50)).ToArray())
                                   .ToArray();
            var whites = io.ReadInt() - 1;
            var blacks = io.ReadInt() - 1;

            for (int i = 0; blacks > 0; i += 2)
            {
                var row = i / 50 * 2;
                var column = i % 50;
                result[row][column] = '#';
                blacks--;
            }

            for (int i = 0; whites > 0; i += 2)
            {
                var row = i / 50 * 2;
                var column = 51 + i % 50;
                result[row][column] = '.';
                whites--;
            }

            io.WriteLine("100 100");

            foreach (var s in result)
            {
                io.WriteLine(string.Concat(s));
            }
        }
    }
}
