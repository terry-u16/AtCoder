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
using CodeforcesRound606Div2.Questions;

namespace CodeforcesRound606Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();
            var one = "one".AsSpan();
            var two = "two".AsSpan();
            var twone = "twone".AsSpan();

            for (int t = 0; t < tests; t++)
            {
                var s = io.ReadString().ToCharArray();

                var toRemove = new Queue<int>();

                for (int i = 0; i + 4 < s.Length; i++)
                {
                    var span = s.AsSpan(i, 5);
                    if (MemoryExtensions.Equals(span, twone, StringComparison.Ordinal))
                    {
                        toRemove.Enqueue(i + 3);
                        s[i + 2] = 'x';
                    }
                }

                for (int i = 0; i + 2 < s.Length; i++)
                {
                    var span = s.AsSpan(i, 3);

                    if (MemoryExtensions.Equals(span, one, StringComparison.Ordinal) ||
                        MemoryExtensions.Equals(span, two, StringComparison.Ordinal))
                    {
                        toRemove.Enqueue(i + 2);
                    }
                }

                io.WriteLine(toRemove.Count);
                io.WriteLine(toRemove, ' ');
            }
        }
    }
}
