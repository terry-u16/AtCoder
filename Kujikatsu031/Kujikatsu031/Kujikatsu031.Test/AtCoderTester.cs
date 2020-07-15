using System;
using Xunit;
using Kujikatsu031.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu031.Collections;

namespace Kujikatsu031.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"A", @"T")]
        [InlineData(@"G", @"C")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 4
0 3", @"7")]
        [InlineData(@"2 4
0 5", @"8")]
        [InlineData(@"4 1000000000
0 1000 1000000 1000000000", @"2000000000")]
        [InlineData(@"1 1
0", @"1")]
        [InlineData(@"9 10
0 3 5 7 100 110 200 300 311", @"67")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2
2 1", @"3")]
        [InlineData(@"3 5
1 1 1", @"0")]
        [InlineData(@"10 998244353
10 9 8 7 5 6 3 4 2 1", @"185297239")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2 4
4 3
9 3
100 5", @"3")]
        [InlineData(@"2
8 20
1 10", @"1")]
        [InlineData(@"5
10 1
2 1
4 1
6 1
8 1", @"5")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 1 2 2", @"3")]
        [InlineData(@"2 1 3 4", @"65")]
        [InlineData(@"31 41 59 265", @"387222020")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"11 3 2
ooxxxoxxxoo", @"6")]
        [InlineData(@"5 2 3
ooxoo", @"1
5")]
        [InlineData(@"5 1 0
ooooo", @"")]
        [InlineData(@"16 4 3
ooxxoxoxxxoxoxxo", @"11
16")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
19 10 14
0 3 4", @"160")]
        [InlineData(@"3
19 15 14
0 0 0", @"2")]
        [InlineData(@"2
8 13
5 13", @"-1")]
        [InlineData(@"4
2 0 1 8
2 0 1 8", @"0")]
        [InlineData(@"1
50
13", @"137438953472")]
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
