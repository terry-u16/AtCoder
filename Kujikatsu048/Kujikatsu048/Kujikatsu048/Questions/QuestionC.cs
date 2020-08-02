using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu048.Algorithms;
using Kujikatsu048.Collections;
using Kujikatsu048.Extensions;
using Kujikatsu048.Numerics;
using Kujikatsu048.Questions;

namespace Kujikatsu048.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc043/tasks/abc043_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var current = new List<char>();

            foreach (var c in s)
            {
                switch (c)
                {
                    case '0':
                        current.Add('0');
                        break;
                    case '1':
                        current.Add('1');
                        break;
                    case 'B':
                        if (current.Count > 0)
                        {
                            current.RemoveAt(current.Count - 1);
                        }
                        break;
                }
            }
            yield return current.Join();
        }
    }
}
