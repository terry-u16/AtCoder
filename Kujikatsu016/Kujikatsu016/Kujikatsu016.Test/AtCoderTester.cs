using System;
using Xunit;
using Kujikatsu016.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu016.Collections;

namespace Kujikatsu016.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"6", @"2")]
        [InlineData(@"27", @"5")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
5 2 3 4 1", @"YES")]
        [InlineData(@"5
2 4 3 5 1", @"NO")]
        [InlineData(@"7
1 2 3 4 5 6 7", @"YES")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2 4", @"45.0000000000")]
        [InlineData(@"12 21 10", @"89.7834636934")]
        [InlineData(@"3 1 8", @"4.2363947991")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            AssertNearlyEqual(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2", @"10")]
        [InlineData(@"200000 200001", @"1")]
        [InlineData(@"141421 35623", @"220280457")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 20
2 80
9 120
16 1", @"191")]
        [InlineData(@"3 20
2 80
9 1
16 120", @"192")]
        [InlineData(@"1 100000000000000
50000000000000 1", @"0")]
        [InlineData(@"15 10000000000
400000000 1000000000
800000000 1000000000
1900000000 1000000000
2400000000 1000000000
2900000000 1000000000
3300000000 1000000000
3700000000 1000000000
3800000000 1000000000
4000000000 1000000000
4100000000 1000000000
5200000000 1000000000
6600000000 1000000000
8000000000 1000000000
9300000000 1000000000
9700000000 1000000000", @"6500000000")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 1 1
13 5 7", @"4")]
        [InlineData(@"4
1 2 3 4
2 3 4 5", @"-1")]
        [InlineData(@"5
5 6 5 2 1
9817 1108 6890 4343 8704", @"25")]
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
