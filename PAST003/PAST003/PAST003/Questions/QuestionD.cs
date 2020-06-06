using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var maxDigit = inputStream.ReadInt();
            var board = new string[5];

            for (int i = 0; i < 5; i++)
            {
                board[i] = inputStream.ReadLine();
            }

            var numbers = new int[maxDigit];

            for (int digit = 0; digit < maxDigit; digit++)
            {
                numbers[digit] = GetNumber(board, digit);
            }

            yield return string.Concat(numbers);
        }

        int GetNumber(string[] numbers, int digit)
        {
            var begin = 4 * digit + 1;
            var first = numbers[0].Substring(begin, 3);
            var second = numbers[1].Substring(begin, 3);
            var third = numbers[2].Substring(begin, 3);
            var fourth = numbers[3].Substring(begin, 3);
            var fifth = numbers[4].Substring(begin, 3);

            if (first == ".#.")
            {
                return 1;
            }
            else if (first == "#.#")
            {
                return 4;
            }
            else if (third == "..#")
            {
                return 7;
            }
            else if (second == "..#")
            {
                if (fourth == "#..")
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
            else if (second == "#..")
            {
                if (fourth == "..#")
                {
                    return 5;
                }
                else
                {
                    return 6;
                }
            }
            else
            {
                if (fourth == "..#")
                {
                    return 9;
                }
                else if (third == "#.#")
                {
                    return 0;
                }
                else
                {
                    return 8;
                }
            }
        }
    }
}
