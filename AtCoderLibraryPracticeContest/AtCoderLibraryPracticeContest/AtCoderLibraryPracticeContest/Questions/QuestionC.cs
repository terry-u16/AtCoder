using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderLibraryPracticeContest.Extensions;
using AtCoderLibraryPracticeContest.Questions;
using System.Diagnostics;
using AtCoder;
using AtCoder.Internal;
using System.Runtime.Intrinsics.X86;
using System.Numerics;

namespace AtCoderLibraryPracticeContest.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (n, m, a, b) = inputStream.ReadValue<long, long, long, long>();
                yield return Math.FloorSum(n, m, a, b);
            }
        }

        public static partial class Math
        {
            /// <summary>
            /// sum_{i=0}^{<paramref name="n"/>-1} floor(<paramref name="a"/>*i+<paramref name="b"/>/<paramref name="m"/>) を返します。
            /// </summary>
            /// <remarks>
            /// <para>制約: 0≤<paramref name="n"/>, <paramref name="m"/>≤10^9, 0≤<paramref name="a"/>, <paramref name="b"/>&lt;<paramref name="m"/></para>
            /// <para>計算量: O(log(n+m+a+b))</para>
            /// </remarks>
            /// <returns></returns>
            public static long FloorSum(long n, long m, long a, long b)
            {
                long ans = 0;
                while (true)
                {
                    if (a >= m)
                    {
                        ans += (n - 1) * n * (a / m) / 2;
                        a %= m;
                    }
                    if (b >= m)
                    {
                        ans += n * (b / m);
                        b %= m;
                    }

                    long yMax = (a * n + b) / m;
                    long xMax = yMax * m - b;
                    if (yMax == 0) return ans;
                    ans += (n - (xMax + a - 1) / a) * yMax;
                    (n, m, a, b) = (yMax, a, m, (a - xMax % a) % a);
                }
            }
        }
    }
}
