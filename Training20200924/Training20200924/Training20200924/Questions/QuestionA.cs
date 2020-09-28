using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200924.Algorithms;
using Training20200924.Collections;
using Training20200924.Numerics;
using Training20200924.Questions;

namespace Training20200924.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc010/tasks/arc010_3
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var blockCount = io.ReadInt();
            var kinds = io.ReadInt();
            var comboBonus = io.ReadInt();
            var completeBonus = io.ReadInt();
            var colorPoints = new int[kinds];

            var colorDictionary = new Dictionary<char, int>();

            for (int i = 0; i < colorPoints.Length; i++)
            {
                var c = io.ReadString()[0];
                var p = io.ReadInt();
                colorDictionary[c] = i;
                colorPoints[i] = p;
            }

            var blocks = io.ReadString();
            var result = new int[blockCount + 1, 1 << kinds, kinds + 1].Fill(-(1 << 28));
            result[0, 0, kinds] = 0;

            for (int i = 0; i < blocks.Length; i++)
            {
                var currentColor = colorDictionary[blocks[i]];

                for (var lastFlag = BitSet.Zero; lastFlag < 1 << kinds; lastFlag++)
                {
                    for (int lastColor = 0; lastColor <= kinds; lastColor++)
                    {
                        ChangeMax(ref result[i + 1, lastFlag, lastColor], result[i, lastFlag, lastColor]);

                        var next = result[i, lastFlag, lastColor] + colorPoints[currentColor];
                        if (lastColor == currentColor)
                        {
                            next += comboBonus;
                        }

                        ChangeMax(ref result[i + 1, lastFlag | (1u << currentColor), currentColor], next);
                    }
                }
            }

            var max = int.MinValue;
            var complete = (1 << kinds) - 1;

            for (int flag = 0; flag < 1 << kinds; flag++)
            {
                for (int lastColor = 0; lastColor <= kinds; lastColor++)
                {
                    ChangeMax(ref max, result[blockCount, flag, lastColor] + (flag == complete ? completeBonus : 0));
                }
            }

            io.WriteLine(max);
        }

        void ChangeMax(ref int a, int b)
        {
            if (a < b)
            {
                a = b;
            }
        }
    }
}
