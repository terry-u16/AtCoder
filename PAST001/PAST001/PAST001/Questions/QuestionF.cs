using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PAST001.Algorithms;
using PAST001.Collections;
using PAST001.Numerics;
using PAST001.Questions;

namespace PAST001.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var s = io.ReadString();

            var start = -1;
            var words = new List<string>();

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                {
                    if (start < 0)
                    {
                        start = i;
                    }
                    else
                    {
                        words.Add(s.Substring(start, i - start + 1));
                        start = -1;
                    }
                }
            }

            words.Sort(StringComparer.OrdinalIgnoreCase);

            var result = new StringBuilder();

            foreach (var w in words)
            {
                result.Append(w);
            }

            io.WriteLine(result.ToString());
        }
    }
}
