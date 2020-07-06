using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200706.Algorithms;
using Training20200706.Collections;
using Training20200706.Extensions;
using Training20200706.Numerics;
using Training20200706.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Training20200706.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/joi2014yo/tasks/joi2014yo_d
    /// </summary>
    public class QuestionH : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 10007;
            var totalDays = inputStream.ReadInt();
            var responsibles = inputStream.ReadLine();
            var schedules = new Modular[totalDays, 1 << 3];

            {
                // 初日
                var hasKeyPerson = ToNumber('J');
                for (var flags = BitSet.Zero; flags < (1 << 3); flags++)
                {
                    if (flags[hasKeyPerson] && flags[ToNumber(responsibles[0])])
                    {
                        schedules[0, flags] = 1;
                    }
                }
            }

            for (int day = 1; day < totalDays; day++)
            {
                for (var flags = BitSet.Zero; flags < (1 << 3); flags++)
                {
                    for (var yesterdayFlag = BitSet.Zero; yesterdayFlag < (1 << 3); yesterdayFlag++)
                    {
                        if (flags[ToNumber(responsibles[day])] && (flags & yesterdayFlag) > 0)
                        {
                            schedules[day, flags] += schedules[day - 1, yesterdayFlag];
                        }
                    }
                }
            }

            var result = Modular.Zero;
            for (var flags = BitSet.Zero; flags < (1 << 3); flags++)
            {
                result += schedules[totalDays - 1, flags];
            }

            yield return result.Value;
        }

        int ToNumber(char c)
        {
            var result = c switch
            {
                'J' => 0,
                'O' => 1,
                'I' => 2,
                _ => -1
            };
            return result;
        }
    }
}
