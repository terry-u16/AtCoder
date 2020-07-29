using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200727.Algorithms;
using Training20200727.Collections;
using Training20200727.Extensions;
using Training20200727.Numerics;
using Training20200727.Questions;

namespace Training20200727.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dp/tasks/dp_o
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        int people;
        bool[][] compatibilities;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            people = inputStream.ReadInt();
            compatibilities = new bool[people][];
            for (int i = 0; i < compatibilities.Length; i++)
            {
                compatibilities[i] = inputStream.ReadIntArray().Select(ai => ai == 1).ToArray();
            }

            var counts = Enumerable.Repeat(0, people + 1).Select(_ => new Modular[1 << people]).ToArray();
            counts[0][0] = 1;

            for (int man = 0; man < people; man++)
            {
                var currentCompatibilityes = compatibilities[man];
                var current = counts[man];
                var next = counts[man + 1];
                for (var flags = BitSet.Zero; flags < (1 << people); flags++)
                {
                    if (flags.Count() == man)
                    {
                        for (int woman = 0; woman < people; woman++)
                        {
                            if (!flags[woman] && currentCompatibilityes[woman])
                            {
                                next[flags | (1u << woman)] += current[flags];
                            }
                        }
                    }
                }
            }

            yield return counts[people][(1 << people) - 1];
        }
    }
}
