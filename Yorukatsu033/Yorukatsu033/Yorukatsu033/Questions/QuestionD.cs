using Yorukatsu033.Questions;
using Yorukatsu033.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu033.Questions
{
    /// <summary>
    /// ABC099 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var withdrawals = new List<int>();
            withdrawals.Add(1);

            for (int i = 6; i <= n; i *= 6)
            {
                withdrawals.Add(i);
            }
            for (int i = 9; i <= n; i *= 9)
            {
                withdrawals.Add(i);
            }

            var withdrawalCounts = new int[n + 1];
            for (int i = 1; i < withdrawalCounts.Length; i++)
            {
                withdrawalCounts[i] = int.MaxValue;
            }

            for (int i = 1; i < withdrawalCounts.Length; i++)
            {
                foreach (var withdrawal in withdrawals)
                {
                    if (i - withdrawal >= 0)
                    {
                        UpdateWhenSmall(ref withdrawalCounts[i], withdrawalCounts[i - withdrawal] + 1);
                    }
                }
            }

            yield return withdrawalCounts[n];
        }

        public static void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }
    }
}
