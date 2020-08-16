using System;
using Xunit;
using Kujikatsu042.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu042.Collections;

namespace Kujikatsu042.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"AtCoder Beginner Contest", @"ABC")]
        [InlineData(@"AtCoder Snuke Contest", @"ASC")]
        [InlineData(@"AtCoder X Contest", @"AXC")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3", @"1.000000000000")]
        [InlineData(@"999", @"36926037.000000000000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            AssertNearlyEqual(outputs, answers);
        }

        [Theory]
        [InlineData(@"33", @"2 -1")]
        [InlineData(@"1", @"0 -1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
())", @"(())")]
        [InlineData(@"6
)))())", @"(((()))())")]
        [InlineData(@"8
))))((((", @"(((())))(((())))")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1 2
2 3
3 4
4 5
1 2 3 4 5", @"10
1 2 3 4 5")]
        [InlineData(@"5
1 2
1 3
1 4
1 5
3141 59 26 53 59", @"197
59 26 3141 59 53")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
1 2
3 2", @"2")]
        [InlineData(@"3
8 3
0 1
4 8", @"9")]
        [InlineData(@"1
1 1", @"0")]
        [InlineData(@"4
8 3
5 4
0 2
4 8", @"14")]
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
