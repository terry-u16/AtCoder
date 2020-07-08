using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu023.Algorithms;
using Kujikatsu023.Collections;
using Kujikatsu023.Extensions;
using Kujikatsu023.Numerics;
using Kujikatsu023.Questions;

namespace Kujikatsu023.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc107/tasks/abc107_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var a = new List<List<char>>();
            for (int row = 0; row < height; row++)
            {
                var s = inputStream.ReadLine();
                if (s.Any(c => c == '#'))
                {
                    a.Add(s.ToList());
                }
            }

            for (int column = width - 1; column >= 0; column--)
            {
                var remove = true;
                for (int row = 0; row < a.Count; row++)
                {
                    if (a[row][column] == '#')
                    {
                        remove = false;
                    }
                }
                if (remove)
                {
                    for (int row = 0; row < a.Count; row++)
                    {
                        a[row].RemoveAt(column);
                    }
                }
            }

            foreach (var r in a)
            {
                yield return string.Concat(r);
            }
        }
    }
}
