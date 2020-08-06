using System;
using Xunit;
using Kujikatsu053.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu053.Collections;

namespace Kujikatsu053.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"25", @"Christmas")]
        [InlineData(@"22", @"Christmas Eve Eve Eve")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10 2 3
abccabaabb", @"Yes
Yes
No
No
Yes
Yes
Yes
No
No
No")]
        [InlineData(@"12 5 2
cabbabaacaba", @"No
Yes
Yes
Yes
Yes
No
Yes
Yes
No
Yes
No
No")]
        [InlineData(@"5 2 2
ccccc", @"No
No
No
No
No")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2 2 1 3", @"7")]
        [InlineData(@"7
1 1 1 1 1 1 1", @"6")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
6 9 4 2 11", @"11 6")]
        [InlineData(@"2
100 0", @"100 0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 -3 1 0", @"4")]
        [InlineData(@"5
3 -6 4 -5 7", @"0")]
        [InlineData(@"6
-1 4 3 2 -5 4", @"8")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2 2", @"8")]
        [InlineData(@"4 5 4", @"87210")]
        [InlineData(@"100 100 5000", @"817260251")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 9
1 2
1 3
2 3
1 4
1 5
4 5
1 6
1 7
6 7", @"Yes")]
        [InlineData(@"3 3
1 2
2 3
3 1", @"No")]
        [InlineData(@"18 27
17 7
12 15
18 17
13 18
13 6
5 7
7 1
14 5
15 11
7 6
1 9
5 4
18 16
4 6
7 2
7 11
6 3
12 14
5 2
10 5
7 8
10 15
3 15
9 8
7 15
5 16
18 15", @"Yes")]
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
