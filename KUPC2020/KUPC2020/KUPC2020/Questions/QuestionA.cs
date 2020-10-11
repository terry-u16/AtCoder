using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KUPC2020.Algorithms;
using KUPC2020.Collections;
using KUPC2020.Numerics;
using KUPC2020.Questions;

namespace KUPC2020.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var lastX = io.ReadInt();
            var lastY = io.ReadInt();
            var sum = 0;

            for (int i = 0; i < n - 1; i++)
            {
                var x = io.ReadInt();
                var y = io.ReadInt();
                sum += Math.Abs(lastX - x) + Math.Abs(lastY - y);
                lastX = x;
                lastY = y;
            }

            io.WriteLine(sum);
        }
    }
}
