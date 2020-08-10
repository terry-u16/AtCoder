using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200810.Algorithms;
using Training20200810.Collections;
using Training20200810.Extensions;
using Training20200810.Numerics;
using Training20200810.Questions;

namespace Training20200810.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc093/tasks/arc093_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (whites, blacks) = inputStream.ReadValue<int, int>();
            var result = new bool[100, 100];
            for (int row = 0; row < 100; row++)
            {
                for (int column = 0; column < 50; column++)
                {
                    result[row, column] = true;
                }
            }

            var whiteGroups = 1;
            for (int row = 0; row < 100; row += 2)
            {
                for (int column = 0; column < 50; column += 2)
                {
                    if (whiteGroups == whites)
                    {
                        row = 10000;
                        break;
                    }

                    result[row, column] = false;
                    whiteGroups++;
                }
            }

            var blackGroups = 1;
            for (int row = 0; row < 100; row += 2)
            {
                for (int column = 51; column < 100; column += 2)
                {
                    if (blackGroups == blacks)
                    {
                        row = 10000;
                        break;
                    }

                    result[row, column] = true;
                    blackGroups++;
                }
            }

            yield return "100 100";

            for (int row = 0; row < 100; row++)
            {
                var s = "";
                for (int column = 0; column < 100; column++)
                {
                    s += result[row, column] ? '#' : '.';
                }
                yield return s;
            }
        }
    }
}
