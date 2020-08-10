using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200810.Algorithms;
using Training20200810.Collections;
using Training20200810.Extensions;
using Training20200810.Numerics;
using Training20200810.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Training20200810.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc112/tasks/abc112_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var statements = new Statement[n];
            for (int i = 0; i < statements.Length; i++)
            {
                var (x, y, h) = inputStream.ReadValue<int, int, int>();
                statements[i] = new Statement(x, y, h);
            }

            Array.Sort(statements);

            for (int cx = 0; cx <= 100; cx++)
            {
                for (int cy = 0; cy <= 100; cy++)
                {
                    var height = statements[0].Height + GetManhattan(cx, cy, statements[0].X, statements[0].Y);
                    var ok = true;

                    for (int i = 1; i < statements.Length; i++)
                    {
                        var h = Math.Max(0, height - GetManhattan(cx, cy, statements[i].X, statements[i].Y));
                        ok &= h == statements[i].Height;
                    }

                    if (ok)
                    {
                        yield return $"{cx} {cy} {height}";
                    }
                }
            }
        }

        int GetManhattan(int x1, int y1, int x2, int y2) => Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

        [StructLayout(LayoutKind.Auto)]
        readonly struct Statement : IComparable<Statement>
        {
            public int X { get; }
            public int Y { get; }
            public int Height { get; }

            public Statement(int x, int y, int h)
            {
                X = x;
                Y = y;
                Height = h;
            }


            
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Height)}: {Height}";

            public int CompareTo([AllowNull] Statement other) => other.Height - Height;
        }
    }
}
