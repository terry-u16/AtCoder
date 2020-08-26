using System;
using Xunit;
using ForciaVirtualContest014.Questions;
using System.Collections.Generic;
using System.Linq;
using ForciaVirtualContest014.Collections;

namespace ForciaVirtualContest014.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"abcabc
2", @"3")]
        [InlineData(@"aaaaa
1", @"1")]
        [InlineData(@"hello
10", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

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
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2
1 1 3 4", @"11")]
        [InlineData(@"6 3
10 10 10 -10 -10 -10", @"360")]
        [InlineData(@"3 1
1 1 1", @"0")]
        [InlineData(@"10 6
1000000000 1000000000 1000000000 1000000000 1000000000 0 0 0 0 0", @"999998537")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
3 2 2 3 3", @"Possible")]
        [InlineData(@"3
1 1 2", @"Impossible")]
        [InlineData(@"10
1 2 2 2 2 2 2 2 2 2", @"Possible")]
        [InlineData(@"10
1 1 2 2 2 2 2 2 2 2", @"Impossible")]
        [InlineData(@"6
1 1 1 1 1 5", @"Impossible")]
        [InlineData(@"5
4 3 2 3 4", @"Possible")]
        [InlineData(@"2
1 1", @"Possible")]
        [InlineData(@"2
2 2", @"Impossible")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
