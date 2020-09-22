using System;
using Xunit;
using Kujikatsu100.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu100.Collections;

namespace Kujikatsu100.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1 2 1 1", @"2")]
        [InlineData(@"3 5 -4 -2", @"-6")]
        [InlineData(@"-1000000000 0 -1000000000 0", @"1000000000000000000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5
.....
.#.#.
.....", @"11211
1#2#1
11211")]
        [InlineData(@"3 5
#####
#####
#####", @"#####
#####
#####")]
        [InlineData(@"6 6
#####.
#.#.##
####.#
.#..#.
#.##..
#.#...", @"#####3
#8#7##
####5#
4#65#2
#5##21
#4#310")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 10 100", @"Yes")]
        [InlineData(@"4
1 2 3 4", @"No")]
        [InlineData(@"3
1 4 1", @"Yes")]
        [InlineData(@"2
1 1", @"No")]
        [InlineData(@"6
2 7 1 8 2 8", @"Yes")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 3
3 2 2", @"0")]
        [InlineData(@"6 3
1 4 1", @"1")]
        [InlineData(@"100 1
100", @"99")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
1 2", @"2
1")]
        [InlineData(@"10
1 2 1 3 2 4 2 5 8 1", @"10
7
0
4
0
3
0
2
3
0")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = SplitByNewLine(question.Solve(input).Trim());

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
