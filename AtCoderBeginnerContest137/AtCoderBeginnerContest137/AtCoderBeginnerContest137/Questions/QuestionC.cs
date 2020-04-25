using AtCoderBeginnerContest137.Questions;
using AtCoderBeginnerContest137.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest137.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var dictionary = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var charArray = inputStream.ReadLine().ToCharArray();
                Array.Sort(charArray);
                var s = new string(charArray);

                if (dictionary.ContainsKey(s))
                {
                    dictionary[s]++;
                }
                else
                {
                    dictionary.Add(s, 1);
                }
            }

            var sum = 0L;
            foreach (var pair in dictionary)
            {
                if (pair.Value >= 2)
                {
                    sum += Combination(pair.Value, 2);
                }
            }

            yield return sum;
        }

        public static long Combination(int n, int r)
        {
            CheckNR(n, r);
            r = Math.Min(r, n - r);

            // See https://stackoverflow.com/questions/1838368/calculating-the-amount-of-combinations
            long result = 1;
            for (int i = 1; i <= r; i++)
            {
                result *= n--;
                result /= i;
            }
            return result;
        }

        private static void CheckNR(int n, int r)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は正の整数でなければなりません。");
            }
            if (r < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(r), $"{nameof(r)}は0以上の整数でなければなりません。");
            }
            if (n < r)
            {
                throw new ArgumentOutOfRangeException($"{nameof(n)},{nameof(r)}", $"{nameof(r)}は{nameof(n)}以下でなければなりません。");
            }
        }

    }
}
