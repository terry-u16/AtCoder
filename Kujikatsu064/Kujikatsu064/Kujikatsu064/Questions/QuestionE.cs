using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu064.Algorithms;
using Kujikatsu064.Collections;
using Kujikatsu064.Extensions;
using Kujikatsu064.Numerics;
using Kujikatsu064.Questions;

namespace Kujikatsu064.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc119/tasks/abc119_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (shrineCount, templeCount, queries) = inputStream.ReadValue<int, int, int>();
            var shrines = new long[shrineCount + 2];
            var temples = new long[templeCount + 2];
            const long Inf = 1L << 60;
            shrines[0] = -Inf;
            shrines[^1] = Inf;
            temples[0] = -Inf;
            temples[^1] = Inf;

            for (int i = 0; i < shrineCount; i++)
            {
                shrines[i + 1] = inputStream.ReadLong();
            }
            for (int i = 0; i < templeCount; i++)
            {
                temples[i + 1] = inputStream.ReadLong();
            }

            for (int q = 0; q < queries; q++)
            {
                var x = inputStream.ReadLong();
                var min = long.MaxValue;

                var toLeftShrine = x - shrines[SearchExtensions.GetLessEqualIndex(shrines, x)];
                var toLeftTemple = x - temples[SearchExtensions.GetLessEqualIndex(temples, x)];
                var toRightShrine = shrines[SearchExtensions.GetGreaterEqualIndex(shrines, x)] - x;
                var toRightTemple = temples[SearchExtensions.GetGreaterEqualIndex(temples, x)] - x;

                min = Math.Min(min, Math.Max(toLeftShrine, toLeftTemple));
                min = Math.Min(min, Math.Max(toRightShrine, toRightTemple));
                min = Math.Min(min, toLeftShrine * 2 + toRightTemple);
                min = Math.Min(min, toLeftShrine + toRightTemple * 2);
                min = Math.Min(min, toLeftTemple * 2 + toRightShrine);
                min = Math.Min(min, toLeftTemple + toRightShrine * 2);

                yield return min;
            }
        }
    }
}
