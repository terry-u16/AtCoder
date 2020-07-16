using System;
using Xunit;
using Kujikatsu032.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu032.Collections;

namespace Kujikatsu032.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"10 9 10 10", @"No")]
        [InlineData(@"46 4 40 5", @"Yes")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
2
2
100", @"2")]
        [InlineData(@"5
1
0
150", @"0")]
        [InlineData(@"30
40
50
6000", @"213")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 2 3 4", @"4 2 1 3")]
        [InlineData(@"3
1 2 3", @"3 1 2")]
        [InlineData(@"1
1000000000", @"1000000000")]
        [InlineData(@"6
0 6 7 6 7 0", @"0 6 6 0 7 7")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"15", @"23")]
        [InlineData(@"1", @"1")]
        [InlineData(@"13", @"21")]
        [InlineData(@"100000", @"3234566667")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 1
1 2
1 3
2 3", @"0
1
2")]
        [InlineData(@"6 3
2 1
2 3
4 1
4 2
6 1
2 6
4 6
6 5", @"6
4
2
0
6
2")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 3
3543", @"6")]
        [InlineData(@"4 2
2020", @"10")]
        [InlineData(@"20 11
33883322005544116655", @"68")]
        [InlineData(@"6 3
152467", @"7")]
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
