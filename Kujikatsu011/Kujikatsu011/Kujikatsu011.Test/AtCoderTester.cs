using System;
using Xunit;
using Kujikatsu011.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu011.Collections;

namespace Kujikatsu011.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 2 7", @"B")]
        [InlineData(@"1 999 1000", @"A")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"11009 11332", @"4")]
        [InlineData(@"31415 92653", @"612")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10 7 100", @"9")]
        [InlineData(@"2 1 100000000000", @"1000000000")]
        [InlineData(@"1000000000 1000000000 100", @"0")]
        [InlineData(@"1234 56789 314159265", @"254309")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
1 1
2 2", @"1")]
        [InlineData(@"3
1 4
4 6
7 8", @"1")]
        [InlineData(@"4
1 1
1 2
2 1
2 2", @"2")]
        [InlineData(@"4
2 2
1 2
1 1
2 1", @"2")]
        [InlineData(@"1
1 1", @"1")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 1
1 1
1 2
2 2
1 2", @"3")]
        [InlineData(@"10 3 2
1 5
2 8
7 10
1 7
3 10", @"1
1")]
        [InlineData(@"10 10 10
1 6
2 9
4 5
4 7
4 7
5 8
6 6
6 7
7 9
10 10
1 8
1 9
1 10
2 8
2 9
2 10
3 8
3 9
3 10
1 10", @"7
9
10
6
8
9
6
7
8
10")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
-10 10 -10 10 -10", @"10")]
        [InlineData(@"4 2
10 -10 -10 10", @"20")]
        [InlineData(@"1 1
-10", @"0")]
        [InlineData(@"10 5
5 -4 -5 -8 -4 7 2 -4 0 7", @"17")]
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
