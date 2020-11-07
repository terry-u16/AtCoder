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
using EducationalCodeforcesRound85.Questions;

namespace EducationalCodeforcesRound85.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                SolveEach(io);
            }
        }

        private static void SolveEach(IOManager io)
        {
            var n = io.ReadInt();
            var l = io.ReadLong() - 1;
            var r = io.ReadLong();

            var result = new long[r - l];
            var index = 0;
            long prefixSum = 0;

            for (int pivot = 1; pivot <= n; pivot++)
            {
                var size = (n - pivot) * 2;

                if (l + index < prefixSum + size)
                {
                    var offset = l + index - prefixSum;
                    for (var i = offset; i < size; i++)
                    {
                        if (index >= result.Length)
                        {
                            break;
                        }
                        else if ((i & 1) == 0)
                        {
                            result[index++] = pivot;
                        }
                        else
                        {
                            var j = ((i + 1) >> 1) + pivot;
                            result[index++] = j;
                        }
                    }
                }

                prefixSum += size;
            }

            if (index < result.Length)
            {
                result[index] = 1;
            }

            io.WriteLine(result, ' ');
        }
    }
}
