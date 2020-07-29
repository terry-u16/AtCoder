using System;
using Xunit;
using Kujikatsu044.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu044.Collections;

namespace Kujikatsu044.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 4", @"Yay!")]
        [InlineData(@"8 8", @"Yay!")]
        [InlineData(@"11 4", @":(")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
9 1 4 4 6 7", @"2")]
        [InlineData(@"8
9 1 14 5 5 4 4 14", @"0")]
        [InlineData(@"14
99592 10342 29105 78532 83018 11639 92015 77204 30914 21912 34519 80835 100000 1", @"42685")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 9", @"No")]
        [InlineData(@"2 3 10", @"Yes")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 7", @"4")]
        [InlineData(@"1 1", @"0")]
        [InlineData(@"50 4321098765432109", @"2160549382716056")]
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
        [InlineData(@"2
2 2
9 1", @"3")]
        [InlineData(@"3
1 1
0 8
7 1", @"9")]
        [InlineData(@"1
9 1", @"0")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
AB
1 1
1 2
2 2", @"Yes")]
        [InlineData(@"4 3
ABAB
1 2
2 3
3 1", @"No")]
        [InlineData(@"13 23
ABAAAABBBBAAB
7 1
10 6
1 11
2 10
2 8
2 11
11 12
8 3
7 12
11 2
13 13
11 9
4 1
9 7
9 6
8 13
8 6
4 10
8 7
4 3
2 1
8 12
6 9", @"Yes")]
        [InlineData(@"13 17
BBABBBAABABBA
7 1
7 9
11 12
3 9
11 9
2 1
11 5
12 11
10 8
1 11
1 8
7 7
9 10
8 8
8 12
6 2
13 11", @"No")]
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
