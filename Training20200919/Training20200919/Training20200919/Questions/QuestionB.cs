using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200919.Algorithms;
using Training20200919.Collections;
using Training20200919.Numerics;
using Training20200919.Questions;

namespace Training20200919.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var s = io.ReadLine();
            io.WriteLine(s.Replace("hi", "").Length == 0 ? "Yes" : "No");
        }
    }
}
