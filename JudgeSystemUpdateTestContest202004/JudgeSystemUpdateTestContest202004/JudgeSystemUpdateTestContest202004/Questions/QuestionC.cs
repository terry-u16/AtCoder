using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JudgeSystemUpdateTestContest202004.Extensions;

namespace JudgeSystemUpdateTestContest202004.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var a = inputStream.ReadIntArray();
            var n = a.Sum();

            var blocksCount = new int[3];
            int count = 0;
            GetCount(blocksCount, a, ref count);
            yield return count.ToString();
        }

        private void GetCount(int[] blocks, int[] a, ref int count)
        {
            if (blocks[0] < a[0])
            {
                var b = (int[])blocks.Clone();
                b[0] += 1;
                GetCount(b, a, ref count);
            }
            if (blocks[1] < a[1] && blocks[1] < blocks[0])
            {
                var b = (int[])blocks.Clone();
                b[1] += 1;
                GetCount(b, a, ref count);
            }
            if (blocks[2] < a[2] && blocks[2] < blocks[1])
            {
                var b = (int[])blocks.Clone();
                b[2] += 1;
                GetCount(b, a, ref count);
            }

            if (blocks[0] == a[0] && blocks[1] == a[1] && blocks[2] == a[2])
            {
                count++;
            }
        }
    }
}
