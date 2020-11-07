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
using AtCoderGrandContest048.Algorithms;
using AtCoderGrandContest048.Collections;
using AtCoderGrandContest048.Numerics;
using AtCoderGrandContest048.Questions;
using System.Diagnostics.CodeAnalysis;

namespace AtCoderGrandContest048.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var l = io.ReadInt();
            Span<int> starts = new int[n + 2];
            Span<int> goals = new int[n + 2];

            for (int i = 1; i <= n; i++)
            {
                starts[i] = io.ReadInt();
            }

            starts[^1] = l + 1;

            for (int i = 1; i <= n; i++)
            {
                goals[i] = io.ReadInt();
            }

            goals[^1] = l + 1;

            long count = 0;
            var goalQueue = new Queue<int>();

            for (int i = 1; i <= n; i++)
            {
                var start = starts[i];
                var goal = goals[i];

                var loop = false;

                while (goalQueue.Count > 0 && goalQueue.Peek() + goalQueue.Count == start)
                {
                    if (!loop)
                    {
                        count += goalQueue.Count;
                        loop = true;
                    }

                    goalQueue.Dequeue();
                }

                if (start < goal)
                {
                    if (starts[i + 1] - 1 == goal)
                    {
                        count++;

                        while (goalQueue.Count > 0 && goalQueue.Peek() + goalQueue.Count == goal)
                        {
                            count++;
                            goalQueue.Dequeue();
                        }
                    }
                    else
                    {
                        goalQueue.Enqueue(goal);
                    }
                }
            }

            if (goalQueue.Count > 0)
            {
                io.WriteLine(-1);
                return;
            }

            for (int i = n; i >= 1; i--)
            {
                var start = starts[i];
                var goal = goals[i];

                var loop = false;

                while (goalQueue.Count > 0 && goalQueue.Peek() - goalQueue.Count == start)
                {
                    if (!loop)
                    {
                        count += goalQueue.Count;
                        loop = true;
                    }

                    goalQueue.Dequeue();
                }

                if (goal < start)
                {
                    if (starts[i - 1] + 1 == goal)
                    {
                        count++;

                        while (goalQueue.Count > 0 && goalQueue.Peek() - goalQueue.Count == goal)
                        {
                            count++;
                            goalQueue.Dequeue();
                        }
                    }
                    else
                    {
                        goalQueue.Enqueue(goal);
                    }
                }
            }

            if (goalQueue.Count > 0)
            {
                io.WriteLine(-1);
                return;
            }

            io.WriteLine(count);
        }
    }
}
