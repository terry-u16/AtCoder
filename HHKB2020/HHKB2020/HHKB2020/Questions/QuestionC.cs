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
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            const int Max = 200001;
            var n = io.ReadInt();

            var set = new RedBlackTree<int>();

            for (int i = 0; i <= Max; i++)
            {
                set.Add(i);
            }

            for (int i = 0; i < n; i++)
            {
                set.Remove(io.ReadInt());
                io.WriteLine(set.Min);
            }
        }
    }
}
