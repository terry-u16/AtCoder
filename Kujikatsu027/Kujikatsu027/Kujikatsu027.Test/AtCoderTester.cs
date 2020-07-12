using System;
using Xunit;
using Kujikatsu027.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu027.Collections;

namespace Kujikatsu027.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"6
1 2 3 2 2 1", @"2")]
        [InlineData(@"9
1 2 1 2 1 2 1 2 1", @"5")]
        [InlineData(@"7
1 2 3 2 1 999999999 1000000000", @"3")]
        [InlineData(@"1
1", @"1")]
        [InlineData(@"2
1 2", @"1")]
        [InlineData(@"5
2 2 2 2 2", @"1")]
        [InlineData(@"5
2 2 2 2 3", @"1")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
0224", @"3")]
        [InlineData(@"6
123123", @"17")]
        [InlineData(@"19
3141592653589793238", @"329")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2
2 5 2 5", @"12")]
        [InlineData(@"8 4
9 1 8 2 7 5 6 4", @"32")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
3 3 3 3", @"0")]
        [InlineData(@"3
1 0 3", @"1")]
        [InlineData(@"2
2 2", @"2")]
        [InlineData(@"7
27 0 0 0 0 0 0", @"3")]
        [InlineData(@"10
1000 193 256 777 0 1 1192 1234567891011 48 425", @"1234567894848")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
-5 1
3 7
-4 -2", @"10")]
        [InlineData(@"3
1 2
3 4
5 6", @"12")]
        [InlineData(@"5
-2 0
-2 0
7 8
9 10
-2 -1", @"34")]
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
