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
using System.Runtime.Intrinsics.X86;
using Training20201019.Algorithms;
using Training20201019.Collections;
using Training20201019.Numerics;
using Training20201019.Questions;

namespace Training20201019.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var height = io.ReadInt();
            var width = io.ReadInt();

            var a = io.ReadInt();
            var b = io.ReadInt();

            var map = new char[height][];

            for (int row = 0; row < map.Length; row++)
            {
                var x = row < b;
                map[row] = new char[width];

                for (int column = 0; column < map[row].Length; column++)
                {
                    var y = column < a;
                    map[row][column] = (x ^ y) ? '1' : '0';
                }                
            }

            for (int row = 0; row < map.Length; row++)
            {
                io.WriteLine(string.Concat(map[row]));
            }
        }
    }
}
