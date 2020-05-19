using Yorukatsu043.Questions;
using Yorukatsu043.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu043.Questions
{
    /// <summary>
    /// ARC069 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var statements = inputStream.ReadLine().Select(c => c == 'x').ToArray();

            bool[] actual;

            if (Check(statements, false, false, out actual))
            {
                yield return actual.ToSheepOrWolf();
            }
            else if (Check(statements, true, false, out actual))
            {
                yield return actual.ToSheepOrWolf();
            }
            else if (Check(statements, false, true, out actual))
            {
                yield return actual.ToSheepOrWolf();
            }
            else if (Check(statements, true, true, out actual))
            {
                yield return actual.ToSheepOrWolf();
            }
            else
            {
                yield return -1;
            }
        }


        bool Check(bool[] statements, bool first, bool second, out bool[] actual)
        {
            actual = new bool[statements.Length];
            actual[0] = first;
            actual[1] = second;

            for (int i = 1; i + 1 < statements.Length; i++)
            {
                actual[i + 1] = statements[i] ^ actual[i - 1] ^ actual[i];
            }

            var length = actual.Length;
            return ((statements[0] ^ actual[0]) == (actual[length - 1] ^ actual[1])) && ((statements[length - 1] ^ actual[length - 1]) == (actual[length - 2] ^ actual[0]));
        }
    }

    public static class ZooExtension
    {
        public static string ToSheepOrWolf(this IEnumerable<bool> isWolf) => string.Concat(isWolf.Select(b => b ? 'W' : 'S'));
    }
}
