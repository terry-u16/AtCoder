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
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadInt();
            if (x < 600)
            {
                yield return 8;
            }
            else if (x < 800)
            {
                yield return 7;
            }
            else if (x < 1000)
            {
                yield return 6;
            }
            else if (x < 1200)
            {
                yield return 5;
            }
            else if (x < 1400)
            {
                yield return 4;
            }
            else if (x < 1600)
            {
                yield return 3;
            }
            else if (x < 1800)
            {
                yield return 2;
            }
            else
            {
                yield return 1;
            }
        }
    }
}
