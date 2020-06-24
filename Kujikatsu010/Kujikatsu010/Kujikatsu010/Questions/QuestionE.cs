using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu010.Algorithms;
using Kujikatsu010.Collections;
using Kujikatsu010.Extensions;
using Kujikatsu010.Numerics;
using Kujikatsu010.Questions;

namespace Kujikatsu010.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc069/tasks/arc069_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var statements = inputStream.ReadLine().Select(c => c == 'x').ToArray();

            var initials = new[] { (false, false), (false, true), (true, false), (true, true) };

            var ok = false;
            foreach (var (wolf1, wolf2) in initials)
            {
                var isWolf = Check(wolf1, wolf2, statements);
                if (isWolf != null)
                {
                    yield return string.Concat(isWolf.Select(b => b ? 'W' : 'S'));
                    yield break;
                }
            }

            yield return -1;
        }

        bool[] Check(bool isWolf1, bool isWolf2, bool[] statements)
        {
            bool[] isWolf = new bool[statements.Length];
            isWolf[0] = isWolf1;
            isWolf[1] = isWolf2;

            for (int i = 1; i + 1 < isWolf.Length; i++)
            {
                isWolf[i + 1] = isWolf[i - 1] ^ isWolf[i] ^ statements[i];
            }

            var ok = true;
            ok &= isWolf[0] == isWolf[^2] ^ isWolf[^1] ^ statements[^1];
            ok &= isWolf[1] == isWolf[^1] ^ isWolf[0] ^ statements[0];
            if (ok)
            {
                return isWolf;
            }
            else
            {
                return null;
            }
        }
    }
}
