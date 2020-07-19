using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikastu034.Algorithms;
using Kujikastu034.Collections;
using Kujikastu034.Extensions;
using Kujikastu034.Numerics;
using Kujikastu034.Questions;

namespace Kujikastu034.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc146/tasks/abc146_f
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<int, int>();
            var s = inputStream.ReadLine();

            var current = n;
            var dices = new Stack<int>();

            while (current > 0)
            {
                var ok = false;
                for (int dice = m; dice > 0; dice--)
                {
                    var square = current - dice;
                    if (square >= 0 && s[square] == '0')
                    {
                        dices.Push(dice);
                        current = square;
                        ok = true;
                        break;
                    }
                }

                if (!ok)
                {
                    yield return -1;
                    yield break;
                }
            }

            yield return dices.Join(' ');
        }
    }
}
