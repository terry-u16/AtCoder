using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu052.Algorithms;
using Kujikatsu052.Collections;
using Kujikatsu052.Extensions;
using Kujikatsu052.Numerics;
using Kujikatsu052.Questions;

namespace Kujikatsu052.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc039/tasks/agc039_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var k = inputStream.ReadLong();

            var quadS = (s + s + s + s).ToCharArray();

            for (int i = 1; i < quadS.Length; i++)
            {
                if (quadS[i - 1] == quadS[i])
                {
                    quadS[i] = '!';
                }
            }

            var firstS = quadS.Take(s.Length).Join();
            var doubleS = quadS.Skip(s.Length).Take(s.Length * 2).Join();
            var lastS = quadS.Skip(s.Length * 3).Join();
            long result = 0;

            result += firstS.Count(c => c == '!');
            result += doubleS.Count(c => c == '!') * ((k - 1) / 2);

            if ((k - 1) % 2 == 1)
            {
                result += lastS.Count(c => c == '!');
            }

            yield return result;
        }
    }
}
