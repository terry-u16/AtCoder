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
using PAST001.Algorithms;
using PAST001.Collections;
using PAST001.Numerics;
using PAST001.Questions;

namespace PAST001.Questions
{
    public class QuestionG : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var happinesses = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    happinesses[i, j] = io.ReadInt();
                }
            }

            var max = Dfs(new List<int>(n));

            io.WriteLine(max);

            int Dfs(List<int> groups)
            {
                if (groups.Count == n)
                {
                    var result = 0;

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = i + 1; j < n; j++)
                        {
                            if (groups[i] == groups[j])
                            {
                                result += happinesses[i, j];
                            }
                        }
                    }

                    return result;
                }
                else
                {
                    var max = int.MinValue;

                    for (int g = 0; g < 3; g++)
                    {
                        groups.Add(g);
                        max.ChangeMax(Dfs(groups));
                        groups.RemoveAt(groups.Count - 1);
                    }

                    return max;
                }
            }
        }
    }
}
