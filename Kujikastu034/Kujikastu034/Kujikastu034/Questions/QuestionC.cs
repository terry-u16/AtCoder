using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikastu034.Algorithms;
using Kujikastu034.Collections;
using Kujikastu034.Extensions;
using Kujikastu034.Numerics;
using Kujikastu034.Questions;

namespace Kujikastu034.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc173/tasks/abc173_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, k) = inputStream.ReadValue<int, int, int>();
            var map = new char[height][];

            for (int i = 0; i < height; i++)
            {
                map[i] = inputStream.ReadLine().ToCharArray();
            }

            var count = 0;
            for (var hFlag = BitSet.Zero; hFlag < (1 << height); hFlag++)
            {
                for (var wFlag = BitSet.Zero; wFlag < (1 << width); wFlag++)
                {
                    var blacks = 0;
                    for (int row = 0; row < height; row++)
                    {
                        for (int column = 0; column < width; column++)
                        {
                            if (!hFlag[row] && !wFlag[column] && map[row][column] == '#')
                            {
                                blacks++;
                            }
                        }
                    }

                    if (blacks == k)
                    {
                        count++;
                    }
                }
            }

            yield return count;
        }
    }
}
