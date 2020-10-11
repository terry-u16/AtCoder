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
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var s = io.ReadString();
            var t = io.ReadString();

            if (s == "Y")
            {
                io.WriteLine(t.ToUpper());
            }
            else
            {
                io.WriteLine(t);
            }
        }
    }
}
