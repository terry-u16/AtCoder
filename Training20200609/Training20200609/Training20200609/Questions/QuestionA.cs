using Training20200609.Questions;
using Training20200609.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200609.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc016/tasks/agc016_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var bits = s.Select(ToBit).ToArray();

            int count = 0;
            while (!Check(bits))
            {
                bits = Join(bits);
                count++;
            }

            yield return count;
        }

        int ToBit(char c)
        {
            return 1 << (c - 'a');
        }

        bool Check(int[] array)
        {
            return Enumerable.Range(0, 26).Any(shift => array.All(b => ((b >> shift) & 1) == 1));
        }

        int[] Join(int[] array)
        {
            var result = new int[array.Length - 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = array[i] | array[i + 1];
            }

            return result;
        }
    }
}
