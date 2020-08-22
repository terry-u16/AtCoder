using System;
using Xunit;
using AtCoderBeginnerContest176.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest176.Collections;

namespace AtCoderBeginnerContest176.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"20 12 6", @"12")]
        [InlineData(@"1000 1 1000", @"1000000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"123456789", @"Yes")]
        [InlineData(@"0", @"Yes")]
        [InlineData(@"31415926535897932384626433832795028841971693993751058209749445923078164062862089986280", @"No")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
2 1 5 4 3", @"4")]
        [InlineData(@"5
3 3 3 3 3", @"0")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4
1 1
4 4
..#.
..#.
.#..
.#..", @"1")]
        [InlineData(@"4 4
1 4
4 1
.##.
####
####
.##.", @"-1")]
        [InlineData(@"4 4
2 2
3 3
....
....
....
....", @"0")]
        [InlineData(@"4 5
1 2
2 5
#.###
####.
#..##
#..##", @"2")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 3
2 2
1 1
1 3", @"3")]
        [InlineData(@"3 3 4
3 3
3 1
1 1
1 2", @"3")]
        [InlineData(@"5 5 10
2 5
4 3
2 3
5 5
2 2
5 4
5 3
5 1
3 5
1 4", @"6")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
