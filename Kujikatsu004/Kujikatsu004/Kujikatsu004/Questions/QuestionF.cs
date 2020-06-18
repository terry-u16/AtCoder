using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Kujikatsu004.Algorithms;
using Kujikatsu004.Collections;
using Kujikatsu004.Extensions;
using Kujikatsu004.Numerics;
using Kujikatsu004.Questions;

namespace Kujikatsu004.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc118/tasks/abc118_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (matches, _) = inputStream.ReadValue<int, int>();
            var availableDigits = inputStream.ReadIntArray().OrderByDescending(i => i).ToArray();
            var neededMatches = availableDigits.Select(GetNeededMatches).Distinct().OrderBy(i => i).ToArray();
            var maxDigitCount = GetMaxDigitCount(matches, neededMatches);

            var answer = new Stack<int>(maxDigitCount);
            _ = TryAppend(answer, matches, maxDigitCount, availableDigits, neededMatches.Min());

            yield return string.Concat(answer.Reverse());
        }

        bool TryAppend(Stack<int> answer, int matches, int lastDigits, int[] availableDigits, int minNeededMatches)
        {
            if (lastDigits == 0)
            {
                if (matches == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                foreach (var digit in availableDigits)
                {
                    var needed = GetNeededMatches(digit);
                    var nextMatches = matches - needed;
                    if (nextMatches >= (lastDigits - 1) * minNeededMatches)
                    {
                        answer.Push(digit);
                        var canAppend = TryAppend(answer, nextMatches, lastDigits - 1, availableDigits, minNeededMatches);
                        if (canAppend)
                        {
                            return true;
                        }
                        else
                        {
                            answer.Pop();
                        }
                    }
                }
            }

            return false;
        }

        int GetMaxDigitCount(int matches, int[] neededMatches)
        {
            if (matches == 0)
            {
                return 0;
            }
            else if (matches < 0)
            {
                return int.MinValue;
            }
            else
            {
                foreach (var needed in neededMatches)
                {
                    var next = GetMaxDigitCount(matches - needed, neededMatches);
                    if (next >= 0)
                    {
                        return next + 1;
                    }
                }
            }

            return int.MinValue;
        }

        int GetNeededMatches(int n)
        {
            switch (n)
            {
                case 1:
                    return 2;
                case 2:
                case 3:
                case 5:
                    return 5;
                case 4:
                    return 4;
                case 6:
                case 9:
                    return 6;
                case 7:
                    return 3;
                case 8:
                    return 7;
                default:
                    return -1;
            }
        }
    }
}
