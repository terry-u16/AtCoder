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

namespace Kujikatsu039.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc082/tasks/arc087_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        const int Size = 20000;
        const int Offset = 10000;
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var operations = Decode(inputStream.ReadLine());
            var (x, y) = inputStream.ReadValue<int, int>();
            var reachable = new bool[2][] { new bool[Size], new bool[Size] };
            reachable[0][operations[0] + Offset] = true;
            reachable[1][Offset] = true;

            for (int op = 1; op < operations.Count; op++)
            {
                var direction = op & 1;
                var next = new bool[Size];
                for (int i = 0; i < reachable[direction].Length; i++)
                {
                    if (reachable[direction][i])
                    {
                        next[i - operations[op]] = true;
                        next[i + operations[op]] = true;
                    }
                }
                reachable[direction] = next;
            }

            yield return reachable[0][x + Offset] && reachable[1][y + Offset] ? "Yes" : "No";
        }

        List<int> Decode(string s)
        {
            var streak = 0;
            var operations = new List<int>();
            foreach (var c in s)
            {
                if (c == 'F')
                {
                    streak++;
                }
                else
                {
                    operations.Add(streak);
                    streak = 0;
                }
            }
            operations.Add(streak);
            return operations;
        }
    }
}
