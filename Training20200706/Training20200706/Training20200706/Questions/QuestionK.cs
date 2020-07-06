using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200706.Algorithms;
using Training20200706.Collections;
using Training20200706.Extensions;
using Training20200706.Numerics;
using Training20200706.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Training20200706.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/gigacode-2019/tasks/gigacode_2019_d
    /// </summary>
    public class QuestionK : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 1000000007;
            var n = inputStream.ReadInt();
            var statements = inputStream.ReadIntArray();
            var peopleOfColor = new int[3];
            var count = Modular.One;

            foreach (var statement in statements)
            {
                count *= peopleOfColor.Count(c => c == statement);
                for (int i = 0; i < peopleOfColor.Length; i++)
                {
                    if (peopleOfColor[i] == statement)
                    {
                        peopleOfColor[i]++;
                        break;
                    }
                }
            }

            yield return count.Value;
        }
    }
}
