using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Asakatsu20200810.Algorithms;
using Asakatsu20200810.Collections;
using Asakatsu20200810.Extensions;
using Asakatsu20200810.Numerics;
using Asakatsu20200810.Questions;

namespace Asakatsu20200810.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc051/tasks/arc051_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (xc, yc, r) = inputStream.ReadValue<int, int, int>();
            var (x1, y1, x2, y2) = inputStream.ReadValue<int, int, int, int>();

            var red = (xc - r) < x1 || (xc + r) > x2 || (yc - r) < y1 || (yc + r) > y2;
            var blue = !Contained(x1, y1, xc, yc, r) || !Contained(x2, y1, xc, yc, r) || !Contained(x1, y2, xc, yc, r) || !Contained(x2, y2, xc, yc, r);

            yield return red ? "YES" : "NO";
            yield return blue ? "YES" : "NO";
        }

        bool Contained(int x, int y, int xc, int yc, int r) => (x - xc) * (x - xc) + (y - yc) * (y - yc) <= r * r;
    }
}
