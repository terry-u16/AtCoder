using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu115.Algorithms;
using Kujikatsu115.Collections;
using Kujikatsu115.Numerics;
using Kujikatsu115.Questions;

namespace Kujikatsu115.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc035/tasks/agc035_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            
            var rbTree = new RedBlackTree<int>();


            for (int i = 0; i < n; i++)
            {
                rbTree.Add(io.ReadInt());
            }

            var first = rbTree.Min;
            var second = rbTree.Max;
            rbTree.Remove(first);
            rbTree.Remove(second);

            var last2 = first;
            var last1 = second;

            while (rbTree.Count > 0)
            {
                var next = last2 ^ last1;

                if (rbTree.Contains(next))
                {
                    last2 = last1;
                    last1 = next;
                    rbTree.Remove(next);
                }
                else
                {
                    io.WriteLine("No");
                    return;
                }
            }

            if ((last2 ^ last1) == first && (last1 ^ first) == second)
            {
                io.WriteLine("Yes");
            }
            else
            {
                io.WriteLine("No");
            }
        }
    }
}
