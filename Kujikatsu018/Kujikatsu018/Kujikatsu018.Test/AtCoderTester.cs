using System;
using Xunit;
using Kujikatsu018.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu018.Collections;

namespace Kujikatsu018.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5
error
2", @"*rr*r")]
        [InlineData(@"6
eleven
5", @"e*e*e*")]
        [InlineData(@"9
education
7", @"******i**")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"uncopyrightable", @"yes")]
        [InlineData(@"different", @"no")]
        [InlineData(@"no", @"yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10 20", @"10")]
        [InlineData(@"10 -10", @"1")]
        [InlineData(@"-10 -20", @"12")]
        [InlineData(@"0 0", @"0")]
        [InlineData(@"0 -1", @"2")]
        [InlineData(@"-1 0", @"1")]
        [InlineData(@"5 2", @"5")]
        [InlineData(@"5 0", @"6")]
        [InlineData(@"-10 10", @"1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
6
8
1
2
3", @"21")]
        [InlineData(@"6
3
1
4
1
5
9", @"25")]
        [InlineData(@"3
5
5
1", @"8")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
0
1
1
2", @"3")]
        [InlineData(@"3
1
2
1", @"-1")]
        [InlineData(@"9
0
1
1
0
1
2
2
1
2", @"8")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 3
#.#
#S.
###", @"1")]
        [InlineData(@"3 3 3
###
#S#
###", @"2")]
        [InlineData(@"7 7 2
#######
#######
##...##
###S###
##.#.##
###.###
#######", @"2")]
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
