using System;
using Xunit;
using Kujikatsu058.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu058.Collections;

namespace Kujikatsu058.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"111", @"111")]
        [InlineData(@"112", @"222")]
        [InlineData(@"750", @"777")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 4", @"1")]
        [InlineData(@"2 6", @"2")]
        [InlineData(@"1000000000000000000 1", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"RRLRL", @"0 1 2 1 1")]
        [InlineData(@"RRLLLLRLRRLL", @"0 3 3 0 0 0 1 1 0 2 2 0")]
        [InlineData(@"RRRLLRLLRRRLLLLL", @"0 0 3 2 0 2 1 0 0 0 4 4 0 0 0 0")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
abcd", @"15")]
        [InlineData(@"3
baa", @"5")]
        [InlineData(@"5
abcab", @"17")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"100
1", @"19")]
        [InlineData(@"25
2", @"14")]
        [InlineData(@"314159
2", @"937")]
        [InlineData(@"9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999
3", @"117879300")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2
1 3", @"2
1
1")]
        [InlineData(@"2
1 2", @"1
1")]
        [InlineData(@"5
1 2
2 3
3 4
3 5", @"2
8
12
3
3")]
        [InlineData(@"8
1 2
2 3
3 4
3 5
3 6
6 7
6 8", @"40
280
840
120
120
504
72
72")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
10 30 20", @"30")]
        [InlineData(@"1
10", @"10")]
        [InlineData(@"10
5 9 5 9 8 9 3 5 4 3", @"8")]
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
