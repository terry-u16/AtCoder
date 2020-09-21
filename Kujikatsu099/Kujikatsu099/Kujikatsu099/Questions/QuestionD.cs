using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu099.Algorithms;
using Kujikatsu099.Collections;
using Kujikatsu099.Numerics;
using Kujikatsu099.Questions;

namespace Kujikatsu099.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc112/tasks/abc112_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var infos = new Info[n];

            for (int i = 0; i < infos.Length; i++)
            {
                infos[i] = new Info(io.ReadInt(), io.ReadInt(), io.ReadInt());
            }

            for (int row = 0; row <= 100; row++)
            {
                for (int column = 0; column <= 100; column++)
                {
                    var first = infos.First(i => i.H > 0);
                    var h = first.GetDistanceTo(row, column) + first.H;
                    var ok = true;

                    foreach (var info in infos)
                    {
                        if (Math.Max(h - info.GetDistanceTo(row, column), 0) != info.H)
                        {
                            ok = false;
                            break;
                        }
                    }

                    if (ok)
                    {
                        io.WriteLine($"{row} {column} {h}");
                        return;
                    }
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Info
        {
            public int Row { get; }
            public int Column { get; }
            public int H { get; }

            public Info(int row, int column, int h)
            {
                Row = row;
                Column = column;
                H = h;
            }

            public int GetDistanceTo(int row, int column) => Math.Abs(row - Row) + Math.Abs(column - Column);
            public override string ToString() => $"{nameof(Row)}: {Row}, {nameof(Column)}: {Column}";
        }
    }
}