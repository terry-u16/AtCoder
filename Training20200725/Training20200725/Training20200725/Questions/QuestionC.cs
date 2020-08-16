using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200725.Algorithms;
using Training20200725.Collections;
using Training20200725.Extensions;
using Training20200725.Numerics;
using Training20200725.Questions;

namespace Training20200725.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc039/tasks/arc039_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (children, candies) = inputStream.ReadValue<int, int>();
            Modular.InitializeCombinationTable();

            if (children > candies)
            {
                yield return Modular.CombinationWithRepetition(children, candies);
            }
            else
            {
                var less = candies / children;
                var moreChildren = candies - less * children;
                yield return Modular.Combination(children, moreChildren);
            }
        }
    }
}
