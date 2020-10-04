using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderRegularContest104.Algorithms;
using AtCoderRegularContest104.Collections;
using AtCoderRegularContest104.Numerics;
using AtCoderRegularContest104.Questions;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using AtCoder;
using AtCoder.Internal;
using System.Diagnostics.CodeAnalysis;

namespace AtCoderRegularContest104.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        const int Inf = 1 << 28;

        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var appeared = new HashSet<int>();

            var getOn = new int[2 * n];
            var getOff = new int[2 * n];
            getOn.AsSpan().Fill(-1);
            getOff.AsSpan().Fill(-1);

            for (int i = 0; i < n; i++)
            {
                var a = io.ReadInt() - 1;
                var b = io.ReadInt() - 1;

                if (a >= 0)
                {
                    if (getOn[a] != -1 || getOff[a] != -1)
                    {
                        io.WriteLine("No");
                        return;
                    }
                    else
                    {
                        getOn[a] = i;
                    }
                }

                if (b >= 0)
                {
                    if (getOn[b] != -1 || getOff[b] != -1)
                    {
                        io.WriteLine("No");
                        return;
                    }
                    else
                    {
                        getOff[b] = i;
                    }
                }
            }


        }
    }
}
