using System;
using Xunit;
using Kujikatsu015.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu015.Collections;

namespace Kujikatsu015.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"YAKINIKU", @"Yes")]
        [InlineData(@"TAKOYAKI", @"No")]
        [InlineData(@"YAK", @"No")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
abc
cde", @"5")]
        [InlineData(@"1
a
z", @"2")]
        [InlineData(@"4
expr
expr", @"4")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2 4 4 3", @"4
3
3
4")]
        [InlineData(@"2
1 2", @"2
1")]
        [InlineData(@"6
5 5 4 4 3 3", @"4
4
4
4
4
4")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 3
5 2 2", @"Yes")]
        [InlineData(@"5
3 1 4 1 5
2 7 1 8 2", @"No")]
        [InlineData(@"5
2 7 1 8 2
3 1 4 1 5", @"No")]
        [InlineData(@"3
1 2 3
3 2 2", @"Yes")]
        [InlineData(@"3
1 2 4
5 2 2", @"Yes")]
        [InlineData(@"3
1 2 4
4 2 2", @"No")]
        [InlineData(@"3
3 1 4
4 2 2", @"No")]
        [InlineData(@"3
3 0 4
4 2 2", @"No")]
        [InlineData(@"3
3 0 4
4 3 2", @"No")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 6
2 1
3 4
4 10
3 4", @"11")]
        [InlineData(@"4 6
2 1
3 7
4 10
3 6", @"13")]
        [InlineData(@"4 10
1 100
1 100
1 100
1 100", @"400")]
        [InlineData(@"4 1
10 100
10 100
10 100
10 100", @"0")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 6
1 3 2
7 13 10
18 20 13
3 4 2
0
1
2
3
5
8", @"2
2
10
-1
13
-1")]
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
