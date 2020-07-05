using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest173.Algorithms;
using AtCoderBeginnerContest173.Collections;
using AtCoderBeginnerContest173.Extensions;
using AtCoderBeginnerContest173.Numerics;
using AtCoderBeginnerContest173.Questions;

namespace AtCoderBeginnerContest173.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, k) = inputStream.ReadValue<int, int, int>();
            var map = new char[height, width];
            for (int row = 0; row < height; row++)
            {
                var s = inputStream.ReadLine();
                for (int column = 0; column < s.Length; column++)
                {
                    map[row, column] = s[column];
                }
            }

            var overall = 0;
            for (var rowSelection = BitSet.Zero; rowSelection < (1 << height); rowSelection++)
            {
                for (var columnSelection = BitSet.Zero; columnSelection < (1 << width); columnSelection++)
                {
                    var currentMap = new char[height, width];
                    for (int row = 0; row < height; row++)
                    {
                        for (int column = 0; column < width; column++)
                        {
                            currentMap[row, column] = map[row, column];
                        }
                    }

                    for (int row = 0; row < height; row++)
                    {
                        for (int column = 0; column < width; column++)
                        {
                            if (rowSelection[row] || columnSelection[column])
                            {
                                currentMap[row, column] = 'r';
                            }
                        }
                    }

                    var count = 0;
                    for (int row = 0; row < height; row++)
                    {
                        for (int column = 0; column < width; column++)
                        {
                            if (currentMap[row, column] == '#')
                            {
                                count++;
                            }
                        }
                    }

                    if (count == k)
                    {
                        overall++;
                    }
                }
            }

            yield return overall;
        }
    }
}
