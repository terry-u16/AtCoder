using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest174.Algorithms;
using AtCoderBeginnerContest174.Collections;
using AtCoderBeginnerContest174.Extensions;
using AtCoderBeginnerContest174.Numerics;
using AtCoderBeginnerContest174.Questions;

namespace AtCoderBeginnerContest174.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var isWhite = inputStream.ReadLine().Select(c => c == 'W').ToArray();

            var count = 0;
            var right = isWhite.Length - 1;
            for (int left = 0; left < isWhite.Length; left++)
            {
                while (right > left && isWhite[right])
                {
                    right--;
                }

                if (right <= left)
                {
                    break;
                }

                if (isWhite[left])
                {
                    count++;
                    isWhite[left] = false;
                    isWhite[right] = true;
                    right--;
                }
            }

            yield return count;
        }
    }
}
