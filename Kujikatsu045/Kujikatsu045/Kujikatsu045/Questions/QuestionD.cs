using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu045.Algorithms;
using Kujikatsu045.Collections;
using Kujikatsu045.Extensions;
using Kujikatsu045.Numerics;
using Kujikatsu045.Questions;

namespace Kujikatsu045.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (aSize, bSize) = inputStream.ReadValue<int, int>();
            var a = new char[aSize][];
            var b = new char[bSize][];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = inputStream.ReadLine().ToCharArray();
            }

            for (int i = 0; i < b.Length; i++)
            {
                b[i] = inputStream.ReadLine().ToCharArray();
            }

            var maxShift = aSize - bSize;
            for (int rowShift = 0; rowShift <= maxShift; rowShift++)
            {
                for (int columnShift = 0; columnShift <= maxShift; columnShift++)
                {
                    var ok = true;
                    for (int row = 0; row < bSize; row++)
                    {
                        for (int column = 0; column < bSize; column++)
                        {
                            if (a[row + rowShift][column + columnShift] != b[row][column])
                            {
                                ok = false;
                            }
                        }
                    }
                    if (ok)
                    {
                        yield return "Yes";
                        yield break;
                    }
                }
            }
            yield return "No";
        }
    }
}
