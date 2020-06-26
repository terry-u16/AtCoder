using System;
using Xunit;
using Kujikatsu012.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu012.Collections;

namespace Kujikatsu012.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4 150
150 140 100 200", @"2")]
        [InlineData(@"1 500
499", @"0")]
        [InlineData(@"5 1
100 200 300 400 500", @"5")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1
10
2", @"4")]
        [InlineData(@"2
9
3 6", @"12")]
        [InlineData(@"5
20
11 12 9 17 12", @"74")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 5
##...
.##..
..##.
...##", @"Possible")]
        [InlineData(@"5 3
###
..#
###
#..
###", @"Impossible")]
        [InlineData(@"4 5
##...
.###.
.###.
...##", @"Impossible")]
        [InlineData(@"3 3
###
..#
.##", @"Impossible")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"0 0 1 2", @"UURDDLLUUURRDRDDDLLU")]
        [InlineData(@"-2 -2 1 1", @"UURRURRDDDLLDLLULUUURRURRDDDLLDL")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
4 3
4 1
2 2", @"5")]
        [InlineData(@"5 3
1 2
1 3
1 4
2 1
2 3", @"10")]
        [InlineData(@"1 1
2 1", @"0")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3 2", @"2 4 1 5 3")]
        [InlineData(@"7 7 1", @"1 2 3 4 5 6 7")]
        [InlineData(@"300000 300000 300000", @"-1")]
        [InlineData(@"6 2 2", @"-1")]
        [InlineData(@"6 2 3", @"5 6 3 4 1 2")]
        [InlineData(@"6 2 4", @"5 6 3 4 2 1")]
        [InlineData(@"6 2 5", @"5 6 4 3 2 1")]
        [InlineData(@"6 2 6", @"-1")]
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
