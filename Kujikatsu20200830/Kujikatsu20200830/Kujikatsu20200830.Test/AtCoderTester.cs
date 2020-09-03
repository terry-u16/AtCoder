using System;
using Xunit;
using Kujikatsu20200830.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu20200830.Collections;

namespace Kujikatsu20200830.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 2919", @"3719")]
        [InlineData(@"22 3051", @"3051")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10", @"Yes")]
        [InlineData(@"50", @"No")]
        [InlineData(@"81", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 2 3 4 5", @"10")]
        [InlineData(@"1 2 3 5 8", @"14")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
2 2 3 5 5", @"2")]
        [InlineData(@"9
1 2 3 4 5 6 7 8 9", @"0")]
        [InlineData(@"6
6 5 4 3 2 1", @"18")]
        [InlineData(@"7
1 1 1 1 2 3 4", @"6")]
        [InlineData(@"7
1000000001 1000000002 1000000003 1000000004 1000000005 1000000006 1000000007", @"0")]
        [InlineData(@"1
1", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
011", @"2
1
1")]
        [InlineData(@"23
00110111001011011001110", @"2
1
2
2
1
2
2
2
2
2
2
2
2
2
2
2
2
2
2
2
2
1
3")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
