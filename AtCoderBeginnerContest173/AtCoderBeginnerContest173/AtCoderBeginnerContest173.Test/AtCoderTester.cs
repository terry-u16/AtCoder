using System;
using Xunit;
using AtCoderBeginnerContest173.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest173.Collections;

namespace AtCoderBeginnerContest173.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1900", @"100")]
        [InlineData(@"3000", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
AC
TLE
AC
AC
WA
TLE", @"AC x 3
WA x 1
TLE x 2
RE x 0")]
        [InlineData(@"10
AC
AC
AC
AC
AC
AC
AC
AC
AC
AC", @"AC x 10
WA x 0
TLE x 0
RE x 0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 2
..#
###", @"5")]
        [InlineData(@"2 3 4
..#
###", @"1")]
        [InlineData(@"2 2 3
##
##", @"0")]
        [InlineData(@"6 6 8
..##..
.#..#.
#....#
######
#....#
#....#", @"208")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2 2 1 3", @"7")]
        [InlineData(@"7
1 1 1 1 1 1 1", @"6")]
        [InlineData(@"4
3 1 1 1", @"5")]
        [InlineData(@"4
5 5 5 1", @"15")]
        [InlineData(@"4
5 4 3 2", @"13")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2
1 2 -3 -4", @"12")]
        [InlineData(@"4 3
-1 -2 -3 -4", @"1000000001")]
        [InlineData(@"2 1
-1 1000000000", @"1000000000")]
        [InlineData(@"10 10
1000000000 100000000 10000000 1000000 100000 10000 1000 100 10 1", @"999983200")]
        [InlineData(@"3 2
1 0 -1", @"0")]
        [InlineData(@"6 5
100 100 100 100 -1 -1", @"1000000")]
        [InlineData(@"6 5
100 100 100 0 -1 -1", @"1000000")]
        [InlineData(@"6 5
100 100 100 0 0 -1", @"0")]
        [InlineData(@"4 3
100 -1 -1 -1", @"100")]
        [InlineData(@"4 1
100 -1 -1 -1", @"100")]
        [InlineData(@"4 3
100 -1 -2 -3", @"600")]
        [InlineData(@"4 4
100 0 -100 -100", @"0")]
        [InlineData(@"10 5
5 4 3 2 1 0 -1 -2 -3 -4", @"720")]
        [InlineData(@"10 9
5 4 3 2 1 0 -1 -2 -3 -4", @"2880")]
        [InlineData(@"10 7
5 4 3 2 1 0 -1 -2 -3 -4", @"1440")]
        [InlineData(@"1 1
1", @"1")]
        [InlineData(@"1 1
-1", @"1000000006")]
        [InlineData(@"5 5
5 4 -3 -2 -1", @"999999887")]
        [InlineData(@"5 3
5 4 -3 -2 -1", @"30")]
        [InlineData(@"4 4
5 -3 -2 -1", @"999999977")]
        [InlineData(@"4 2
5 0 0 -1", @"0")]
        [InlineData(@"3 3
2 -2 -2", @"8")]
        [InlineData(@"4 3
2 2 -2 -2", @"8")]
        [InlineData(@"5 3
-1 -2 -3 -4 -5", @"1000000001")]
        [InlineData(@"5 3
0 -2 -3 -4 -5", @"0")]
        [InlineData(@"4 4
1 -2 -3 -4", @"999999983")]
        [InlineData(@"3 2
1 -2 -3", @"6")]
        [InlineData(@"3 1
1 -2 -3", @"1")]
        [InlineData(@"5 1
0 0 0 0 0", @"0")]
        [InlineData(@"5 3
1000 1000 10 -100 -100", @"10000000")]
        [InlineData(@"5 4
100 100 100 -100 -100", @"100000000")]
        [InlineData(@"4 4
100 -100 -100 -100", @"900000007")]
        [InlineData(@"2 1
100 0", @"100")]
        [InlineData(@"2 1
-100 0", @"0")]
        [InlineData(@"5 3
-5 -1 1 2 3", @"15")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 3
2 3", @"7")]
        [InlineData(@"2
1 2", @"3")]
        [InlineData(@"10
5 3
5 7
8 9
1 9
9 10
8 4
7 4
6 10
7 2", @"113")]
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
