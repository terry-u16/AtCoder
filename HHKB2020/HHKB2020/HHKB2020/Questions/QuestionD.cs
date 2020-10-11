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
    public class QuestionD : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();
            var invTwo = Modular.One / new Modular(2);

            for (int t = 0; t < tests; t++)
            {
                var n = io.ReadInt();
                var a = io.ReadInt();
                var b = io.ReadInt();

                // a > bにする
                a.SwapIfSmallerThan(ref b);

                if (a + b > n)
                {
                    io.WriteLine(0);
                    continue;
                }

                var result = Square(new Modular(n - a + 1)) * Square(new Modular(n - b + 1));
                result -= Square(new Modular(a - b + 1)) * Square(new Modular(n - a + 1));

                var line = new Modular(n - a - b + 1) * new Modular(b - 1) + new Modular(b - 1) * new Modular(b) * invTwo;
                result -= line * (a - b + 1) * (n - a + 1) * 4;
                result -= Square(line) * 4;

                io.WriteLine(result);
            }
        }

        Modular Square(Modular n) => n * n;
    }
}
