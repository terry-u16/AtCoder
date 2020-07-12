using System;
using Xunit;
using Kujikatsu028.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu028.Collections;

namespace Kujikatsu028.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"happy,newyear,enjoy", @"happy newyear enjoy")]
        [InlineData(@"haiku,atcoder,tasks", @"haiku atcoder tasks")]
        [InlineData(@"abcde,fghihgf,edcba", @"abcde fghihgf edcba")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"100", @"18")]
        [InlineData(@"9995", @"35")]
        [InlineData(@"3141592653589793", @"137")]
        [InlineData(@"1", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 10
60 2 2 4
70 8 7 9
50 2 3 9", @"120")]
        [InlineData(@"3 3 10
100 3 1 4
100 1 5 9
100 2 6 5", @"-1")]
        [InlineData(@"8 5 22
100 3 7 5 3 1
164 4 5 2 7 8
334 7 2 7 2 9
234 4 7 2 8 2
541 5 4 3 3 6
235 4 8 6 9 7
394 3 6 1 6 2
872 8 4 3 7 2", @"1067")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"25", @"17")]
        [InlineData(@"1", @"1")]
        [InlineData(@"100", @"108")]
        [InlineData(@"2020", @"40812")]
        [InlineData(@"200000", @"400000008")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4
1 4
3 3
6 2
8 1", @"21")]
        [InlineData(@"4 2
0 0
1 1
2 2
3 3", @"1")]
        [InlineData(@"4 3
-1000000000 -1000000000
1000000000 1000000000
-999999999 999999999
999999999 -999999999", @"3999999996000000001")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1
1
2
4", @"3")]
        [InlineData(@"7
1
2
1
3
1
4", @"3")]
        [InlineData(@"4
4
4
1", @"3")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        void AssertNearlyEqual(IEnumerable<string> expected, IEnumerable<string> actual, double acceptableError = 1e-6)
        {
            Assert.Equal(expected.Count(), actual.Count());
            foreach (var (exp, act) in (expected, actual).Zip().Select(p => (double.Parse(p.v1), double.Parse(p.v2))))
            {
                var error = act - exp;
                Assert.InRange(Math.Abs(error), 0, acceptableError);
            }
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
