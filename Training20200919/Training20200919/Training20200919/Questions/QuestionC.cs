using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200919.Algorithms;
using Training20200919.Collections;
using Training20200919.Numerics;
using Training20200919.Questions;
using System.Runtime.Intrinsics.X86;

namespace Training20200919.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var girls = io.ReadInt();
            var boys = io.ReadInt();
            var girlsGroup = io.ReadInt();
            var boysGroup = io.ReadInt();
            var chocolatesCount = io.ReadInt();

            var chocolates = Enumerable.Repeat(0, boys).Select(_ => new List<Chocolate>()).ToArray();
            for (int i = 0; i < chocolatesCount; i++)
            {
                var g = io.ReadInt() - 1;
                var b = io.ReadInt() - 1;
                var h = io.ReadInt();

                chocolates[b].Add(new Chocolate(g, h));
            }

            int max = 0;

            for (var flag = BitSet.Zero; flag < 1 << girls; flag++)
            {
                if (Popcnt.PopCount(flag) != girlsGroup)
                {
                    continue;
                }

                var currentMax = new int[boys + 1];

                for (int boy = 0; boy < chocolates.Length; boy++)
                {
                    int sum = 0;
                    foreach (var choco in chocolates[boy])
                    {
                        if (flag[choco.Girl])
                        {
                            sum += choco.Happiness;
                        }
                    }

                    for (int i = currentMax.Length - 2; i >= 0; i--)
                    {
                        currentMax[i + 1] = Math.Max(currentMax[i + 1], currentMax[i] + sum);
                    }
                }

                max = Math.Max(max, currentMax[boysGroup]);
            }

            io.WriteLine(max);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Chocolate
        {
            public int Girl { get; }
            public int Happiness { get; }

            public Chocolate(int girl, int happiness)
            {
                Girl = girl;
                Happiness = happiness;
            }

            public override string ToString() => $"{nameof(Girl)}: {Girl}, {nameof(Happiness)}: {Happiness}";
        }
    }
}
