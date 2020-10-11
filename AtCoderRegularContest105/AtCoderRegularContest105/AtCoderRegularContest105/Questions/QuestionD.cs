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
using AtCoderRegularContest105.Algorithms;
using AtCoderRegularContest105.Collections;
using AtCoderRegularContest105.Numerics;
using AtCoderRegularContest105.Questions;

namespace AtCoderRegularContest105.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();
            var dictionary = new Dictionary<int, int>();

            for (int t = 0; t < tests; t++)
            {
                dictionary.Clear();
                var n = io.ReadInt();
                var a = io.ReadIntArray(n);

                foreach (var ai in a)
                {
                    if (dictionary.TryGetValue(ai, out var c))
                    {
                        dictionary[ai] = c + 1;
                    }
                    else
                    {
                        dictionary[ai] = 1;
                    }
                }

                var allTwo = true;

                foreach (var (_, count) in dictionary)
                {
                    if ((count & 1) != 0)
                    {
                        allTwo = false;
                        break;
                    }
                }

                if ((n & 1) == 0)
                {
                    if (allTwo)
                    {
                        io.WriteLine("Second");
                    }
                    else
                    {
                        io.WriteLine("First");
                    }
                }
                else
                {
                    io.WriteLine("Second");
                }
            }
        }
    }
}
