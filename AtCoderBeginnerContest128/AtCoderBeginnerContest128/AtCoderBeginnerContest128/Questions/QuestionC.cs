using AtCoderBeginnerContest128.Questions;
using AtCoderBeginnerContest128.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest128.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var switchCount = nm[0];
            var bulbCount = nm[1];

            var bulbSwitches = new int[bulbCount][];
            for (int i = 0; i < bulbCount; i++)
            {
                bulbSwitches[i] = inputStream.ReadIntArray().Skip(1).Select(n => n - 1).ToArray();
            }

            var switchMods = inputStream.ReadIntArray();

            var count = 0;

            for (int switchFlag = 0; switchFlag < (1 << switchCount); switchFlag++)
            {
                var isAllOn = true;
                for (int bulbIndex = 0; bulbIndex < bulbSwitches.Length; bulbIndex++)
                {
                    var onCount = bulbSwitches[bulbIndex].Count(s => (switchFlag & (1 << s)) > 0);
                    if (onCount % 2 != switchMods[bulbIndex])
                    {
                        isAllOn = false;
                        break;
                    }
                }

                if (isAllOn)
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
