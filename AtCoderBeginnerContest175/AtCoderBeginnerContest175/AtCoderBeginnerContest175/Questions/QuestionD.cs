using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest175.Algorithms;
using AtCoderBeginnerContest175.Collections;
using AtCoderBeginnerContest175.Extensions;
using AtCoderBeginnerContest175.Numerics;
using AtCoderBeginnerContest175.Questions;

namespace AtCoderBeginnerContest175.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var p = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var c = inputStream.ReadLongArray();

            long max = long.MinValue;
            for (int start = 0; start < n; start++)
            {
                var current = start;
                var operationCount = 0;
                var points = new long[n + 1];
                var seen = Enumerable.Repeat(-1, n).ToArray();
                seen[current] = 0;

                while (true)
                {
                    operationCount++;
                    current = p[current];
                    points[operationCount] = points[operationCount - 1] + c[current];

                    if (seen[current] != -1)
                    {
                        var beforeLoopCount = seen[current];
                        var beforeLoopPoint = points[beforeLoopCount];
                        var loopPoint = points[operationCount] - points[seen[current]];

                        long currentMax = long.MinValue;
                        for (int i = 1; i <= operationCount; i++)
                        {
                            currentMax = Math.Max(currentMax, points[i]);
                        }

                        if (loopPoint > 0)
                        {
                            var loopLength = operationCount - beforeLoopCount;
                            var loopCount = (k - beforeLoopCount) / loopLength;
                            var mod = (k - beforeLoopCount) % loopLength;

                            var loopBasePoint = (points[operationCount] - points[beforeLoopCount]) * loopCount;

                            for (int i = 0; i <= mod; i++)
                            {
                                currentMax = Math.Max(currentMax, loopBasePoint + points[beforeLoopCount + i]);
                            }

                            loopBasePoint -= loopPoint;

                            for (int i = mod; i < loopLength; i++)
                            {
                                currentMax = Math.Max(currentMax, loopBasePoint + points[beforeLoopCount + i]);
                            }
                        }

                        max = Math.Max(max, currentMax);
                        break;
                    }
                    else if (operationCount == k)
                    {
                        long currentMax = long.MinValue;
                        for (int i = 1; i <= operationCount; i++)
                        {
                            currentMax = Math.Max(currentMax, points[i]);
                        }
                        max = Math.Max(max, currentMax);
                        break;
                    }

                    seen[current] = operationCount;
                }
            }

            yield return max;
        }
    }
}
