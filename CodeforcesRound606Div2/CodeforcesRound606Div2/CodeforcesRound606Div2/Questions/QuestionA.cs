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
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();
            var queue = new Queue<long>();

            for (int t = 0; t < tests; t++)
            {
                var n = io.ReadInt();
                queue.Clear();
                var count = 0;

                for (int i = 1; i <= 9; i++)
                {
                    queue.Enqueue(i);
                }

                while (queue.Peek() <= n)
                {
                    var current = queue.Dequeue();
                    queue.Enqueue(current * 10 + current % 10);
                    count++;
                }

                io.WriteLine(count);
            }
        }
    }
}
