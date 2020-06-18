using System;
using Xunit;
using Kujikatsu004.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu004.Collections;

namespace Kujikatsu004.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"8", @"2")]
        [InlineData(@"2", @"0")]
        [InlineData(@"9", @"3")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
3 4", @"3.5")]
        [InlineData(@"3
500 300 200", @"375")]
        [InlineData(@"5
138 138 138 138 138", @"138")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            AssertNearlyEqual(outputs, answers, 1e-5);
        }

        [Theory]
        [InlineData(@"5 4 2
2 1 1
3 3 4", @"9")]
        [InlineData(@"5 4 3
2 1 1
3 3 4
1 4 2", @"0")]
        [InlineData(@"10 10 5
1 6 1
4 1 3
6 9 4
9 4 2
3 1 3", @"64")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 1
LRLRRL", @"3")]
        [InlineData(@"13 3
LRRLRLRRLRLLR", @"9")]
        [InlineData(@"10 1
LLLLLRRRRR", @"9")]
        [InlineData(@"9 2
RRRLRLRLL", @"7")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5
4 2 1
2 3 1", @"2")]
        [InlineData(@"3 8
4 2 1
2 3 1", @"0")]
        [InlineData(@"11 14
3 1 4 1 5 9 2 6 5 3 5
8 9 7 9 3 2 3 8 4 6 2", @"12")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"20 4
3 7 8 4", @"777773")]
        [InlineData(@"101 9
9 8 7 6 5 4 3 2 1", @"71111111111111111111111111111111111111111111111111")]
        [InlineData(@"15 3
5 4 6", @"654")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 6
1 4 3", @"1")]
        [InlineData(@"5 400
3 1 4 1 5", @"5")]
        [InlineData(@"6 20
10 4 3 10 25 2", @"3")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

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
