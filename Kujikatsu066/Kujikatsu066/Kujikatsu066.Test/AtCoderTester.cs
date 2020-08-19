using System;
using Xunit;
using Kujikatsu066.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu066.Collections;

namespace Kujikatsu066.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"6 2", @"2")]
        [InlineData(@"14 3", @"2")]
        [InlineData(@"20 4", @"3")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 -10
1 2 3
3 2 1
1 2 2", @"1")]
        [InlineData(@"5 2 -4
-2 5
100 41
100 40
-3 0
-6 -2
18 -13", @"2")]
        [InlineData(@"3 3 0
100 -100 0
0 100 100
100 100 100
-100 100 100", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 1
3", @"4")]
        [InlineData(@"10 2
4
5", @"0")]
        [InlineData(@"100 5
1
23
45
67
89", @"608200469")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2 4", @"5
4
1
0")]
        [InlineData(@"3 1 3", @"3
0")]
        [InlineData(@"7 3 7", @"7
8
4
2
0
0")]
        [InlineData(@"10 4 8", @"10
12
10
8
4
1
0
0
0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"??2??5", @"768")]
        [InlineData(@"?44", @"1")]
        [InlineData(@"7?4", @"0")]
        [InlineData(@"?6?42???8??2??06243????9??3???7258??5??7???????774????4?1??17???9?5?70???76???", @"153716888")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5 2
3 2 3 4
.....
.@..@
..@..", @"5")]
        [InlineData(@"1 6 4
1 1 1 6
......", @"2")]
        [InlineData(@"3 3 1
2 1 2 3
.@.
.@.
.@.", @"-1")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5 2
3 2 3 4
.....
.@..@
..@..", @"5")]
        [InlineData(@"1 6 4
1 1 1 6
......", @"2")]
        [InlineData(@"3 3 1
2 1 2 3
.@.
.@.
.@.", @"-1")]
        public void QuestionFAnotherTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF2();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 3 2
1 2 3", @"Yes")]
        [InlineData(@"3
1 2 3
2 2 2", @"No")]
        [InlineData(@"6
3 1 2 6 3 4
2 2 8 3 4 3", @"Yes")]
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
