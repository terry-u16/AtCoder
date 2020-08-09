using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound663Div2.Extensions;
using CodeforcesRound663Div2.Questions;

namespace CodeforcesRound663Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (height, width) = inputStream.ReadValue<int, int>();
                var map = new char[height][];
                for (int row = 0; row < height; row++)
                {
                    map[row] = inputStream.ReadLine().ToCharArray();
                }

                var result = 0;
                for (int row = 0; row < height - 1; row++)
                {
                    if (map[row][width - 1] == 'R')
                    {
                        result++;
                    }
                }

                for (int column = 0; column < width - 1; column++)
                {
                    if (map[height - 1][column] == 'D')
                    {
                        result++;
                    }
                }

                yield return result;
            }
        }
    }
}
