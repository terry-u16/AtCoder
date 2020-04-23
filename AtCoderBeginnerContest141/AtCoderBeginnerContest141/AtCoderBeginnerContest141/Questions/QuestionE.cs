using AtCoderBeginnerContest141.Questions;
using AtCoderBeginnerContest141.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;

namespace AtCoderBeginnerContest141.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            var maxLength = 0;
            for (int offset = 0; offset < s.Length; offset++)
            {
                var z = ZAlgorithm(s.Substring(offset));
                for (int i = 1; i < z.Length; i++)
                {
                    if (i >= z[i])
                    {
                        maxLength = Math.Max(maxLength, z[i]);
                    }
                }
            }

            yield return maxLength;
        }

        private int[] ZAlgorithm(string s)
        {
            var z = new int[s.Length];
            z[0] = s.Length;
            var offset = 1;
            var length = 0;

            while (offset < s.Length)
            {
                while (offset + length < s.Length && s[length] == s[offset + length])
                {
                    length++;
                }
                z[offset] = length;

                if (length == 0)
                {
                    offset++;
                    continue;
                }

                int copyLength = 1;
                while (copyLength < length && copyLength + z[copyLength] < length)
                {
                    z[offset + copyLength] = z[copyLength];
                    copyLength++;
                }
                offset += copyLength;
                length -= copyLength;
            }

            return z;
        }
    }
}
