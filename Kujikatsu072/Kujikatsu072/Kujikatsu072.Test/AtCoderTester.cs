using System;
using Xunit;
using Kujikatsu072.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu072.Collections;

namespace Kujikatsu072.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"100", @"ABC100")]
        [InlineData(@"425", @"ABC425")]
        [InlineData(@"999", @"ABC999")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
3 1 4 1 5 9 2", @"4")]
        [InlineData(@"10
0 1 2 3 4 5 6 7 8 9", @"3")]
        [InlineData(@"1
99999", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7", @"2")]
        [InlineData(@"149696127901", @"27217477801")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"8", @"10")]
        [InlineData(@"1000000000000", @"2499686339916")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 3 2", @"1")]
        [InlineData(@"1 3 1", @"2")]
        [InlineData(@"2 3 3", @"1")]
        [InlineData(@"2 3 1", @"5")]
        [InlineData(@"7 1 1", @"1")]
        [InlineData(@"15 8 5", @"437760187")]
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
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
S.o
.o.
o.T", @"2")]
        [InlineData(@"3 4
S...
.oo.
...T", @"0")]
        [InlineData(@"4 3
.S.
.o.
.o.
.T.", @"-1")]
        [InlineData(@"10 10
.o...o..o.
....o.....
....oo.oo.
..oooo..o.
....oo....
..o..o....
o..o....So
o....T....
....o.....
........oo", @"5")]
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
