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
    public class QuestionE : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var queries = io.ReadInt();

            var followees = Enumerable.Repeat(0, n).Select(_ => new SortedSet<int>()).ToArray();

            for (int q = 0; q < queries; q++)
            {
                var type = io.ReadInt();
                var user = io.ReadInt() - 1;

                if (type == 1)
                {
                    var another = io.ReadInt() - 1;
                    followees[user].Add(another);
                }
                else if (type == 2)
                {
                    for (int i = 0; i < followees.Length; i++)
                    {
                        if (i == user)
                        {
                            continue;
                        }

                        if (followees[i].Contains(user))
                        {
                            followees[user].Add(i);
                        }
                    }
                }
                else
                {
                    var toAdd = new SortedSet<int>();

                    foreach (var another in followees[user])
                    {
                        foreach (var fol in followees[another])
                        {
                            if (fol != user)
                            {
                                toAdd.Add(fol);
                            }
                        }
                    }

                    foreach (var another in toAdd)
                    {
                        followees[user].Add(another);
                    }
                }
            }

            foreach (var fol in followees)
            {
                var result = new char[n];
                result.AsSpan().Fill('N');

                foreach (var f in fol)
                {
                    result[f] = 'Y';
                }

                io.WriteLine(string.Concat(result));
            }
        }
    }
}
