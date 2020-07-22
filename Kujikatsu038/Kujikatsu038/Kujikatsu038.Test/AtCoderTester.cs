using System;
using Xunit;
using Kujikatsu038.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu038.Collections;

namespace Kujikatsu038.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 3", @"9")]
        [InlineData(@"3 4", @"7")]
        [InlineData(@"6 6", @"12")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
6 5 6 8", @"3")]
        [InlineData(@"5
4 5 3 5 4", @"3")]
        [InlineData(@"5
9 5 6 8 4", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2 2", @"Yes")]
        [InlineData(@"2 2 1", @"No")]
        [InlineData(@"3 5 8", @"Yes")]
        [InlineData(@"7 9 20", @"No")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 5
3 1 4 1 5 9 2", @"3")]
        [InlineData(@"15 10
1 5 6 10 11 11 11 20 21 25 25 26 99 99 99", @"6")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4
1 3
1 2 1
2 3 1
3 4 1
4 1 1", @"2")]
        [InlineData(@"3 3
1 3
1 2 1
2 3 1
3 1 2", @"2")]
        [InlineData(@"3 3
1 3
1 2 1
2 3 1
3 1 2", @"2")]
        [InlineData(@"8 13
4 2
7 3 9
6 2 3
1 6 4
7 6 9
3 8 9
1 2 2
2 8 12
8 6 9
2 5 5
4 2 18
5 3 7
5 1 515371567
4 8 6", @"6")]
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
