using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu027.Algorithms;
using Kujikatsu027.Collections;
using Kujikatsu027.Extensions;
using Kujikatsu027.Numerics;
using Kujikatsu027.Questions;

namespace Kujikatsu027.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc013/tasks/agc013_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var count = 1;
            var mode = Mode.None;
            var last = 0;

            foreach (var ai in a)
            {
                switch (mode)
                {
                    case Mode.None:
                        mode = Mode.Equal;
                        break;
                    case Mode.Equal:
                        if (ai > last)
                        {
                            mode = Mode.Ascending;
                        }
                        else if (ai < last)
                        {
                            mode = Mode.Descending;
                        }
                        break;
                    case Mode.Ascending:
                        if (ai < last)
                        {
                            count++;
                            mode = Mode.Equal;
                        }
                        break;
                    case Mode.Descending:
                        if (ai > last)
                        {
                            count++;
                            mode = Mode.Equal;
                        }
                        break;
                }
                last = ai;
            }

            yield return count;
        }

        enum Mode
        {
            None,
            Equal,
            Ascending,
            Descending
        }
    }
}
