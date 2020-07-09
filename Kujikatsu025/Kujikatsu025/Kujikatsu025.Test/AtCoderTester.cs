using System;
using Xunit;
using Kujikatsu025.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu025.Collections;

namespace Kujikatsu025.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"21", @"27")]
        [InlineData(@"12", @"36")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 3", @"1")]
        [InlineData(@"4
2 5 2 5", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
1 32
2 63
1 12", @"000001000002
000002000001
000001000001")]
        [InlineData(@"2 3
2 55
2 77
2 99", @"000002000001
000002000002
000002000003")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 60
10 10
100 100", @"110")]
        [InlineData(@"3 60
10 10
10 20
10 30", @"60")]
        [InlineData(@"3 60
30 10
30 20
30 30", @"50")]
        [InlineData(@"10 100
15 23
20 18
13 17
24 12
18 29
19 27
23 21
18 20
27 15
22 25", @"145")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 2", @"Yes")]
        [InlineData(@"3
1 1 2", @"No")]
        [InlineData(@"5
4 3 4 3 4", @"No")]
        [InlineData(@"3
2 2 2", @"Yes")]
        [InlineData(@"4
2 2 2 2", @"Yes")]
        [InlineData(@"5
3 3 3 3 3", @"No")]
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
