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
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            long count = 0;

            var eratos = new Eratosthenes(n);

            for (int c = 1; c < n; c++)
            {
                var remain = n - c;
                var divs = eratos.GetDivisiors(remain);
                count += divs.Count();
            }

            io.WriteLine(count);
        }
    }
}
