using AtCoderBeginnerContest154.Questions;
using AtCoderBeginnerContest154.Extensions;
using AtCoderBeginnerContest154.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Numerics;

namespace AtCoderBeginnerContest154.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            string n = inputStream.ReadLine();
            var k = inputStream.ReadInt();

            yield return GetCount(n, k);
        }

        int GetCount(string n, int k)
        {
            n = n.TrimStart('0');
            if (n == string.Empty)
            {
                n = "0";
            }

            if (k <= 0)
            {
                return 1;
            }

            var nInt = BigInteger.Parse(n);
            if (k == 1 && nInt < 1)
            {
                return 0;
            }
            if (k == 2 && nInt < 11)
            {
                return 0;
            }
            else if (k == 3 && nInt < 111)
            {
                return 0;
            }

            int sum = 0;
            var digit = n.Length;
            var maxDigit = n[0] - '0';

            // 最上位桁が0
            if (digit > k)
            {
                sum += (int)BasicAlgorithm.Combination(digit - 1, k) * Pow(9, k);
            }

            // 最上位桁が1以上maxDigit未満
            sum += (maxDigit - 1) * (int)BasicAlgorithm.Combination(digit - 1, k - 1) * Pow(9, k - 1);

            // 最上位桁がmaxDigit
            sum += GetCount(n.Substring(1), k - 1);

            return sum;
        }

        int Pow(int a, int n)
        {
            int result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= a;
            }
            return result;
        }
    }
}
