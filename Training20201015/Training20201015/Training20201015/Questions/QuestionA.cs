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
using Training20201015.Algorithms;
using Training20201015.Collections;
using Training20201015.Numerics;
using Training20201015.Questions;

namespace Training20201015.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var m = io.ReadInt();
            var d = io.ReadInt();

            var doubling = new int[32, n];

            Construct();

            for (int i = 1; i < 32; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    doubling[i, j] = doubling[i - 1, doubling[i - 1, j]];
                }
            }

            var results = Enumerable.Range(0, n).ToArray();

            for (int i = 0; i < 32; i++)
            {
                if (((d >> i) & 1) == 1)
                {
                    var next = new int[n];
                    for (int j = 0; j < next.Length; j++)
                    {
                        next[j] = doubling[i, results[j]];
                    }
                    results = next;
                }
            }

            foreach (var r in results)
            {
                io.WriteLine(r + 1);
            }

            void Construct()
            {
                var lanes = Enumerable.Range(0, n).ToArray();

                for (int i = 0; i < m; i++)
                {
                    var a = io.ReadInt();
                    a--;
                    Swap(ref lanes[a], ref lanes[a + 1]);
                }

                for (int i = 0; i < lanes.Length; i++)
                {
                    doubling[0, lanes[i]] = i;
                }
            }
        }


        void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
