using System;
using Xunit;
using Kujikatsu052.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu052.Collections;

namespace Kujikatsu052.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2
ip cc", @"icpc")]
        [InlineData(@"8
hmhmnknk uuuuuuuu", @"humuhumunukunuku")]
        [InlineData(@"5
aaaaa aaaaa", @"aaaaaaaaaa")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 5
4 7 10 6 5", @"8")]
        [InlineData(@"10 5
4 7 10 6 5", @"9")]
        [InlineData(@"100 0", @"100")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"issii
2", @"4")]
        [InlineData(@"qq
81", @"81")]
        [InlineData(@"cooooooooonteeeeeeeeeest
999993333", @"8999939997")]
        [InlineData(@"aaa
1", @"1")]
        [InlineData(@"aaa
2", @"3")]
        [InlineData(@"aaa
3", @"4")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
-10 5 -4", @"19")]
        [InlineData(@"5
10 -4 -8 -11 3", @"30")]
        [InlineData(@"11
-1000000000 1000000000 -1000000000 1000000000 -1000000000 0 1000000000 -1000000000 1000000000 -1000000000 1000000000", @"10000000000")]
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

        [Theory]
        [InlineData(@"3 1 1
1 2 1
2 1 2
3 3 10", @"3")]
        [InlineData(@"1 1 10
10 10 10", @"-1")]
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
