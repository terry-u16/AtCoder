using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu039.Algorithms;
using Kujikatsu039.Collections;
using Kujikatsu039.Extensions;
using Kujikatsu039.Numerics;
using Kujikatsu039.Questions;
using System.Numerics;

namespace Kujikatsu039.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc151/tasks/abc151_f
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        const double eps = 1e-9;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var points = new Complex[inputStream.ReadInt()];
            for (int i = 0; i < points.Length; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                points[i] = new Complex(x, y);
            }

            var cxl = 0.0;
            var cxr = 1000.0;
            while (cxr - cxl > eps)
            {
                var mid1 = cxl + (cxr - cxl) / 3;
                var mid2 = cxl + (cxr - cxl) * 2 / 3;

                if (GetMaxDistance(mid1, points) <= GetMaxDistance(mid2, points))
                {
                    cxr = mid2;
                }
                else
                {
                    cxl = mid1;
                }
            }

            var centerX = (cxl + cxr) / 2;
            yield return GetMaxDistance(centerX, points);
        }

        double GetMaxDistance(double x, Complex[] points)
        {
            var cyl = 0.0;
            var cyr = 1000.0;
            while (cyr - cyl > eps)
            {
                var mid1 = cyl + (cyr - cyl) / 3;
                var mid2 = cyl + (cyr - cyl) * 2 / 3;

                if (GetMaxDistance(new Complex(x, mid1), points) <= GetMaxDistance(new Complex(x, mid2), points))
                {
                    cyr = mid2;
                }
                else
                {
                    cyl = mid1;
                }
            }
            var y = (cyr + cyl) / 2;
            return GetMaxDistance(new Complex(x, y), points);
        }

        double GetMaxDistance(Complex center, Complex[] points)
        {
            double max = 0;
            foreach (var point in points)
            {
                max = Math.Max(max, (point - center).Magnitude);
            }
            return max;
        }
    }
}
