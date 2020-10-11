using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HHKB2020.Algorithms;
using HHKB2020.Collections;
using HHKB2020.Numerics;
using HHKB2020.Questions;

namespace HHKB2020.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var height = io.ReadInt();
            var width = io.ReadInt();
            var map = new string[height];

            for (int row = 0; row < map.Length; row++)
            {
                map[row] = io.ReadString();
            }

            var count = 0;

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (map[row][column] == '.')
                    {
                        if (row + 1 < height && map[row + 1][column] == '.')
                        {
                            count++;
                        }

                        if (column + 1 < width && map[row][column + 1] == '.')
                        {
                            count++;
                        }
                    }
                }
            }

            io.WriteLine(count);
        }
    }
}
