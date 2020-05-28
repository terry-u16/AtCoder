using Training20200528.Questions;
using Training20200528.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200528.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc118/tasks/abc118_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var matches = nm[0];
            var availableNumerics = inputStream.ReadIntArray();
            var maxDigits = GetMaximumDigits(matches, availableNumerics);

            yield return GetMaximumInteger(availableNumerics, maxDigits);
        }

        string GetMaximumInteger(int[] availableNumerics, int[] maxDigits)
        {
            Array.Sort(availableNumerics);
            Array.Reverse(availableNumerics);

            var result = new List<int>();

            int match = maxDigits.Length - 1;
            while (match > 0)
            {
                foreach (var current in availableNumerics)
                {
                    var used = GetNeededMatches(current);
                    if (match >= used && maxDigits[match - used] == maxDigits[match] - 1)
                    {
                        match -= used;
                        result.Add(current);
                        break;
                    }
                }
            }

            return string.Concat(result);
        }

        int[] GetMaximumDigits(int matches, int[] availableNumerics)
        {
            var neededMatches = availableNumerics.Select(GetNeededMatches).Distinct().ToArray();
            var maxDigits = Enumerable.Repeat(-(1 << 20), matches + 1).ToArray();
            maxDigits[0] = 0;

            for (int i = 0; i < maxDigits.Length; i++)
            {
                foreach (var neededMatch in neededMatches)
                {
                    if (i + neededMatch < maxDigits.Length)
                    {
                        maxDigits[i + neededMatch] = Math.Max(maxDigits[i + neededMatch], maxDigits[i] + 1);
                    }
                }
            }

            return maxDigits;
        }

        int GetNeededMatches(int n)
        {
            switch (n)
            {
                case 1:
                    return 2;
                case 2:
                    return 5;
                case 3:
                    return 5;
                case 4:
                    return 4;
                case 5:
                    return 5;
                case 6:
                    return 6;
                case 7:
                    return 3;
                case 8:
                    return 7;
                case 9:
                    return 6;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
