using System;
using Xunit;
using Kujikatsu071.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu071.Collections;

namespace Kujikatsu071.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"+-++", @"2")]
        [InlineData(@"-+--", @"-2")]
        [InlineData(@"----", @"-4")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 3 1", @"3 1 2")]
        [InlineData(@"5
1 2 3 4 5", @"1 2 3 4 5")]
        [InlineData(@"8
8 2 7 3 4 5 6 1", @"8 2 4 5 6 7 3 1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
20 11 9 24", @"26 5 7 22")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3 1 4", @"2")]
        [InlineData(@"5
1 1 1 1 1", @"5")]
        [InlineData(@"6
40 1 30 2 7 20", @"4")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2
1 1 3 4", @"11")]
        [InlineData(@"6 3
10 10 10 -10 -10 -10", @"360")]
        [InlineData(@"3 1
1 1 1", @"0")]
        [InlineData(@"10 6
1000000000 1000000000 1000000000 1000000000 1000000000 0 0 0 0 0", @"999998537")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"A??C", @"8")]
        [InlineData(@"ABCBC", @"3")]
        [InlineData(@"????C?????B??????A???????", @"979596887")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1 2
1 3
3 4
3 5", @"1 2 5 4 3")]
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
