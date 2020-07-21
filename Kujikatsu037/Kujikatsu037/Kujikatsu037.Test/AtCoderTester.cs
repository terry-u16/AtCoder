using System;
using Xunit;
using Kujikatsu037.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu037.Collections;

namespace Kujikatsu037.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1", @"Hello World")]
        [InlineData(@"2
3
5", @"8")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3 1 2
2 5 4
3 6", @"14")]
        [InlineData(@"4
2 3 4 1
13 5 8 24
45 9 15", @"74")]
        [InlineData(@"2
1 2
50 50
50", @"150")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4 6", @"5")]
        [InlineData(@"5 4 3", @"0")]
        [InlineData(@"1 7 10", @"0")]
        [InlineData(@"1 3 3", @"1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"aba
4", @"b")]
        [InlineData(@"atcoderandatcodeer
5", @"andat")]
        [InlineData(@"z
1", @"z")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
1 2
2 3", @"3")]
        [InlineData(@"3
100 100
10 10000
1 1000000000", @"9991")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2 2
1 2 3 4 5", @"4.500000
1")]
        [InlineData(@"4 2 3
10 20 10 10", @"15.000000
3")]
        [InlineData(@"5 1 5
1000000000000000 999999999999999 999999999999998 999999999999997 999999999999996", @"1000000000000000.000000
1")]
        [InlineData(@"50 1 50
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1", @"1.000000
1125899906842623")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            AssertNearlyEqual(outputs, answers);
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
