using System;
using Xunit;
using Kujikatsu064.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu064.Collections;

namespace Kujikatsu064.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5
1 3 4 5 7", @"2")]
        [InlineData(@"15
13 76 46 15 50 98 93 77 31 43 84 90 6 24 14", @"3")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
G W Y P Y W", @"Four")]
        [InlineData(@"9
G W W G P W P G G", @"Three")]
        [InlineData(@"8
P Y W G Y W Y Y", @"Four")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 24", @"2")]
        [InlineData(@"5 1", @"1")]
        [InlineData(@"1 111", @"111")]
        [InlineData(@"4 972439611840", @"206")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2", @"7")]
        [InlineData(@"10 0", @"100")]
        [InlineData(@"31415 9265", @"287927211")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 4
100
600
400
900
1000
150
2000
899
799", @"350
1400
301
399")]
        [InlineData(@"1 1 3
1
10000000000
2
9999999999
5000000000", @"10000000000
10000000000
14999999998")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"23
1 1 1
2 1 1", @"46")]
        [InlineData(@"10
1 2 1
2 1 2", @"40")]
        [InlineData(@"10
2 1 2
1 2 1", @"40")]
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
