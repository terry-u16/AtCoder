using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu115.Algorithms;
using Kujikatsu115.Collections;
using Kujikatsu115.Numerics;
using Kujikatsu115.Questions;
using System.Text.RegularExpressions;

namespace Kujikatsu115.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var s = io.ReadString();

            if (Regex.IsMatch(s, @"^A[a-z]+C[a-z]+$"))
            {
                io.WriteLine("AC");
            }
            else
            {
                io.WriteLine("WA");
            }
        }
    }
}
