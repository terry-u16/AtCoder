using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200706.Algorithms;
using Training20200706.Collections;
using Training20200706.Extensions;
using Training20200706.Numerics;
using Training20200706.Questions;

namespace Training20200706.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<int, int>();
            var p = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                p[i] = inputStream.ReadInt();
            }

            var doublePoints = new int[p.Length * p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    doublePoints[i * p.Length + j] = p[i] + p[j];
                }
            }

            Array.Sort(doublePoints);

            int maxPoint = 0;
            for (int i = 0; i < doublePoints.Length; i++)
            {
                if (doublePoints[i] > m)
                {
                    break;
                }

                var first = doublePoints[i];
                var second = doublePoints[SearchExtensions.GetLessEqualIndex(doublePoints, m - first)];
                var total = first + second;
                if (total <= m)
                {
                    maxPoint = Math.Max(maxPoint, total);
                }
            }

            yield return maxPoint;
        }
    }
}
