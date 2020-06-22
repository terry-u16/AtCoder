using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu008.Algorithms;
using Kujikatsu008.Collections;
using Kujikatsu008.Extensions;
using Kujikatsu008.Numerics;
using Kujikatsu008.Questions;

namespace Kujikatsu008.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc076/tasks/abc076_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var t = inputStream.ReadIntArray();
            var v = inputStream.ReadIntArray();
            var totalHalfSeconds = t.Sum() * 2;
            var maxSpeed = new double[totalHalfSeconds + 1];

            for (int i = 0; i < maxSpeed.Length; i++)
            {
                maxSpeed[i] = Math.Min(i * 0.5, (totalHalfSeconds - i) * 0.5);
            }

            var beginTime = 0;
            for (int section = 0; section < t.Length; section++)
            {
                var endTime = beginTime + t[section];
                var baseSpeed = v[section];
                for (int halfTime = 0; halfTime < maxSpeed.Length; halfTime++)
                {
                    var timeToBegin = 2 * beginTime - halfTime;
                    var timeSinceEnd = halfTime - 2 * endTime;
                    if (timeToBegin > 0)
                    {
                        maxSpeed[halfTime] = Math.Min(maxSpeed[halfTime], timeToBegin * 0.5 + baseSpeed);
                    }
                    else if (timeSinceEnd > 0)
                    {
                        maxSpeed[halfTime] = Math.Min(maxSpeed[halfTime], timeSinceEnd * 0.5 + baseSpeed);
                    }
                    else
                    {
                        maxSpeed[halfTime] = Math.Min(maxSpeed[halfTime], baseSpeed);
                    }
                }
                beginTime += t[section];
            }

            double total = 0;
            for (int time = 0; time + 1 < maxSpeed.Length; time++)
            {
                total += (maxSpeed[time] + maxSpeed[time + 1]) / 4.0;
            }

            yield return total;
        }
    }
}
