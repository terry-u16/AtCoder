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
using AtCoderRegularContest106.Algorithms;
using AtCoderRegularContest106.Collections;
using AtCoderRegularContest106.Numerics;
using AtCoderRegularContest106.Questions;

namespace AtCoderRegularContest106.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var nodes = io.ReadInt();
            var edges = io.ReadInt();
            var init = io.ReadIntArray(nodes);
            var target = io.ReadIntArray(nodes);

            var uf = new UnionFind(nodes);

            for (int i = 0; i < edges; i++)
            {
                uf.Unite(io.ReadInt() - 1, io.ReadInt() - 1);
            }

            var groups = uf.GetAllGroups();

            foreach (var group in groups)
            {
                long initSum = 0;
                long targetSum = 0;

                foreach (var v in group)
                {
                    initSum += init[v];
                    targetSum += target[v];
                }

                if (initSum != targetSum)
                {
                    io.WriteLine("No");
                    return;
                }
            }

            io.WriteLine("Yes");
        }
    }
}
