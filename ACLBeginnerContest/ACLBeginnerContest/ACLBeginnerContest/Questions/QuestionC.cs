using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ACLBeginnerContest.Algorithms;
using ACLBeginnerContest.Collections;
using ACLBeginnerContest.Numerics;
using ACLBeginnerContest.Questions;
using AtCoder;
using AtCoder.Internal;

namespace ACLBeginnerContest.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var cities = io.ReadInt();
            var roads = io.ReadInt();
            var uf = new UnionFindTree(cities);

            for (int i = 0; i < roads; i++)
            {
                var a = io.ReadInt() - 1;
                var b = io.ReadInt() - 1;
                uf.Unite(a, b);
            }

            io.WriteLine(uf.Groups - 1);
        }
    }
}
