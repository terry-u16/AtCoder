using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200804.Algorithms;
using Training20200804.Collections;
using Training20200804.Extensions;
using Training20200804.Numerics;
using Training20200804.Questions;

namespace Training20200804.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/keyence2019/tasks/keyence2019_d
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var rowMax = inputStream.ReadIntArray();
            var columnMax = inputStream.ReadIntArray();
            Array.Sort(rowMax);
            Array.Sort(columnMax);

            var row = height;
            var column = width;
            var lastRow = row;
            var lastColumn = column;
            var count = Modular.One;

            for (int i = height * width; i > 0; i--)
            {
                while (row > 0 && rowMax[row - 1] == i)
                {
                    row--;
                }
                while (column > 0 && columnMax[column - 1] == i)
                {
                    column--;
                }

                if (lastRow - row >= 2 || lastColumn - column >= 2)
                {
                    yield return 0;
                    yield break;
                }
                else if (lastRow - row == 1 && lastColumn - column == 1)
                {
                    count *= Modular.One;
                }
                else if (lastRow - row == 1)
                {
                    count *= width - column;
                }
                else if (lastColumn - column == 1)
                {
                    count *= height - row;
                }
                else
                {
                    var written = height * width - i;
                    var available = (height - row) * (width - column) - written;
                    if (available > 0)
                    {
                        count *= available;
                    }
                    else
                    {
                        yield return 0;
                        yield break;
                    }
                }

                lastRow = row;
                lastColumn = column;
            }

            yield return count;
        }
    }
}
