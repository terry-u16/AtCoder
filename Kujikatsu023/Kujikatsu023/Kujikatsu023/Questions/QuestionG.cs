using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu023.Algorithms;
using Kujikatsu023.Collections;
using Kujikatsu023.Extensions;
using Kujikatsu023.Numerics;
using Kujikatsu023.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu023.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/m-solutions2019/tasks/m_solutions2019_e
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        const int Mod = 1000003;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = Mod;

            var queries = inputStream.ReadInt();

            for (int q = 0; q < queries; q++)
            {
                var (x, d, n) = inputStream.ReadValue<int, int, int>();
                if (d == 0)
                {
                    yield return Modular.Pow(x, n).Value;
                }
                else if (x == 0)
                {
                    yield return 0;
                }
                else
                {
                    var p = new Modular(x) / new Modular(d);
                    if (p.Value + n - 1 > Mod)
                    {
                        yield return 0;
                    }
                    else
                    {
                        var normalized = Modular.Permutation(n + p.Value - 1, n);
                        var pow = Modular.Pow(d, n);
                        yield return (normalized * pow).Value;
                    }
                }
            }
        }
    }
}
