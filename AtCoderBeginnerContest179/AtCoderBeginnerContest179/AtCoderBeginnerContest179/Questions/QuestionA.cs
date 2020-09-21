using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest179.Algorithms;
using AtCoderBeginnerContest179.Collections;
using AtCoderBeginnerContest179.Numerics;
using AtCoderBeginnerContest179.Questions;

namespace AtCoderBeginnerContest179.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var s = io.ReadLine();

            if (s[^1] == 's')
            {
                io.WriteLine(s + "es");
            }
            else
            {
                io.WriteLine(s + "s");
            }
        }
    }
}
