using System;
using Xunit;
using Kujikatsu083.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu083.Collections;

namespace Kujikatsu083.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1 2 3", @"3 1 2")]
        [InlineData(@"100 100 100", @"100 100 100")]
        [InlineData(@"41 59 31", @"31 41 59")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 70
20 30 10", @"2")]
        [InlineData(@"3 10
20 30 10", @"1")]
        [InlineData(@"4 1111
1 10 100 1000", @"4")]
        [InlineData(@"2 10
20 20", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
WWRR", @"2")]
        [InlineData(@"2
RR", @"0")]
        [InlineData(@"8
WRWWRWRR", @"3")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
0 1 2 3 4 5", @"3")]
        [InlineData(@"3
0 0 0", @"6")]
        [InlineData(@"54
0 0 1 0 1 2 1 2 3 2 3 3 4 4 5 4 6 5 7 8 5 6 6 7 7 8 8 9 9 10 10 11 9 12 10 13 14 11 11 12 12 13 13 14 14 15 15 15 16 16 16 17 17 17", @"115295190")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
.#.
..#
#..", @"10")]
        [InlineData(@"2 4
....
....", @"0")]
        [InlineData(@"4 3
###
###
...
###", @"6")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"BBBAAAABA
BBBBA
4
7 9 2 5
7 9 1 4
1 7 2 5
1 7 2 4", @"YES
NO
YES
NO")]
        [InlineData(@"AAAAABBBBAAABBBBAAAA
BBBBAAABBBBBBAAAAABB
10
2 15 2 13
2 13 6 16
1 13 2 20
4 20 3 20
1 18 9 19
2 14 1 11
3 20 3 15
6 16 1 17
4 18 8 20
7 20 3 14", @"YES
YES
YES
YES
YES
YES
NO
NO
NO
NO")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 6
1 5 1 4", @"5")]
        [InlineData(@"10 10
10 9 8 7 6 5 4 3 2 1", @"45")]
        [InlineData(@"5 2
1 2 1 2 1", @"4")]
        [InlineData(@"5 6
1 2 3 4 5", @"4")]
        [InlineData(@"5 6
4 5 4 5 1", @"5")]
        [InlineData(@"1 5
1 3", @"1")]
        [InlineData(@"3 6
1 6 1", @"2")]
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
