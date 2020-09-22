using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200922.Algorithms;
using Training20200922.Collections;
using Training20200922.Numerics;
using Training20200922.Questions;

namespace Training20200922.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var ls = io.ReadIntArray(3);
            Array.Sort(ls);

            if (ls[0] + ls[1] >= ls[2])
            {
                var r = ls.Sum();
                io.WriteLine(r * r * Math.PI);
            }
            else
            {
                var r1 = ls.Sum();
                var r0 = ls[2] - (ls[0] + ls[1]);
                io.WriteLine((r1 * r1 - r0 * r0) * Math.PI);
            }
        }
    }
}
