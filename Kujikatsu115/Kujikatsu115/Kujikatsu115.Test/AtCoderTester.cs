using System;
using Xunit;
using Kujikatsu115.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu115.Collections;

namespace Kujikatsu115.Test
{
    public class AtCoderTester
    {
        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"AtCoder", @"AC")]
        [InlineData(@"ACoder", @"WA")]
        [InlineData(@"AcycliC", @"WA")]
        [InlineData(@"AtCoCo", @"WA")]
        [InlineData(@"Atcoder", @"WA")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 3", @"Yes")]
        [InlineData(@"4
1 2 4 8", @"No")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
#.#", @"1")]
        [InlineData(@"5
#.##.", @"2")]
        [InlineData(@"9
.........", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 7
1 6 3", @"14")]
        [InlineData(@"4 9
7 4 0 3", @"46")]
        [InlineData(@"1 0
1000000000000", @"1000000000000")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 4
1 4 2 3 5", @"4")]
        [InlineData(@"8 4
4 2 4 2 4 2 4 2", @"7")]
        [InlineData(@"10 7
14 15 92 65 35 89 79 32 38 46", @"8")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
1 2
3 4", @"2")]
        [InlineData(@"6
4 6 0 0 3 3
0 5 6 5 0 3", @"8")]
        [InlineData(@"5
1 2 3 4 5
1 2 3 4 5", @"2")]
        [InlineData(@"1
0
0", @"0")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = SplitByNewLine(question.Solve(input).Trim());

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
