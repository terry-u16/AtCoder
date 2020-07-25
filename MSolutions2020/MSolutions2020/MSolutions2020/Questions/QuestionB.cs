using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MSolutions2020.Algorithms;
using MSolutions2020.Collections;
using MSolutions2020.Extensions;
using MSolutions2020.Numerics;
using MSolutions2020.Questions;

namespace MSolutions2020.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (red, green, blue) = inputStream.ReadValue<int, int, int>();
            var k = inputStream.ReadInt();

            for (int i = 0; i < k; i++)
            {
                if (green <= red)
                {
                    green *= 2;
                }
                else
                {
                    blue *= 2;
                }
            }

            yield return green > red && blue > green ? "Yes" : "No"; ;
        }
    }
}
