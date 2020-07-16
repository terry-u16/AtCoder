using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu032.Algorithms;
using Kujikatsu032.Collections;
using Kujikatsu032.Extensions;
using Kujikatsu032.Numerics;
using Kujikatsu032.Questions;

namespace Kujikatsu032.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc164/tasks/abc164_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (takahashiHp, takahashiAttack, aokiHp, AokiAttack) = inputStream.ReadValue<int, int, int, int>();

            while (true)
            {
                aokiHp -= takahashiAttack;
                if (aokiHp <= 0)
                {
                    yield return "Yes";
                    break;
                }
                takahashiHp -= AokiAttack;
                if (takahashiHp <= 0)
                {
                    yield return "No";
                    break;
                }
            }
        }
    }
}
