using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using AtCoderRegularContest107.Algorithms;
using AtCoderRegularContest107.Collections;
using AtCoderRegularContest107.Numerics;
using AtCoderRegularContest107.Questions;
using ModInt = AtCoderRegularContest107.Numerics.StaticModInt<AtCoderRegularContest107.Numerics.Mod998244353>;

namespace AtCoderRegularContest107.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var threshold = io.ReadInt();
            var a = new int[n, n];
            var combinaton = new ModCombination<Mod998244353>(100);

            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    a[row, column] = io.ReadInt();
                }
            }

            var rowUf = new UnionFind(n);
            var colUf = new UnionFind(n);

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    var ok = true;
                    for (int column = 0; column < n; column++)
                    {
                        ok &= a[i, column] + a[j, column] <= threshold;
                    }

                    if (ok)
                    {
                        colUf.Unite(i, j);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    var ok = true;
                    for (int row = 0; row < n; row++)
                    {
                        ok &= a[row, i] + a[row, j] <= threshold;
                    }

                    if (ok)
                    {
                        rowUf.Unite(i, j);
                    }
                }
            }

            var result = ModInt.One;

            foreach (var g in colUf.GetAllGroups())
            {
                result *= combinaton.Factorial(g.Length);
            }

            foreach (var g in rowUf.GetAllGroups())
            {
                result *= combinaton.Factorial(g.Length);
            }

            io.WriteLine(result);
        }
    }
}
