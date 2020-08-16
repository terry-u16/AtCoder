using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200727.Algorithms;
using Training20200727.Collections;
using Training20200727.Extensions;
using Training20200727.Numerics;
using Training20200727.Questions;

namespace Training20200727.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dp/tasks/dp_k
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();

            var wins = new bool[2 * k + 1];

            for (int i = k + 1 ; i < wins.Length; i++)
            {
                wins[i] = true;
            }

            for (int i = k; i >= 0; i--)
            {
                wins[i] = a.Any(ai => !wins[i + ai]);
            }

            yield return wins[0] ? "First" : "Second";
        }
    }
}
