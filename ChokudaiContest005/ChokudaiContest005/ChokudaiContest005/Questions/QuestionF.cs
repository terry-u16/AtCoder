using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ChokudaiContest005.Algorithms;
using ChokudaiContest005.Collections;
using ChokudaiContest005.Numerics;
using ChokudaiContest005.Questions;

namespace ChokudaiContest005.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var sw = new Stopwatch();
            sw.Start();
            var rand = new XorShift();

            var id = io.ReadInt();
            var size = io.ReadInt();
            var maxColor = io.ReadInt();

            var panels = new int[size][];

            for (int row = 0; row < panels.Length; row++)
            {
                panels[row] = new int[size];
                for (int column = 0; column < panels[row].Length; column++)
                {
                    panels[row][column] = io.ReadChar() - '0';
                }
            }


            var queryCount = 9999;
            io.WriteLine(queryCount);
            for (int i = 0; i < queryCount; i++)
            {
                io.WriteLine($"{rand.Next(size) + 1} {rand.Next(size) + 1} {rand.Next(maxColor) + 1}");
            }
        }
    }
}
