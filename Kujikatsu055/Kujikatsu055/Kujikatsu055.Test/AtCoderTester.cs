using System;
using Xunit;
using Kujikatsu055.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu055.Collections;

namespace Kujikatsu055.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"CODEFESTIVAL", @"Yes")]
        [InlineData(@"FESTIVALCODE", @"No")]
        [InlineData(@"CF", @"Yes")]
        [InlineData(@"FCF", @"Yes")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"20", @"0
0
0
0
0
1
0
0
0
0
3
0
0
0
0
0
3
3
0
0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
acp
ae", @"6")]
        [InlineData(@"6 3
abcdef
abc", @"-1")]
        [InlineData(@"15 9
dnsusrayukuaiia
dujrunuma", @"45")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
2 2 2", @"1")]
        [InlineData(@"6 1
1 6 1 2 0 4", @"11")]
        [InlineData(@"5 9
3 1 4 1 5", @"0")]
        [InlineData(@"2 0
5 5", @"10")]
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
        [InlineData(@"5
3 2 4 1 2", @"2")]
        [InlineData(@"10
10 71 84 33 6 47 23 25 52 64", @"36")]
        [InlineData(@"7
1 2 3 1000000000 4 5 6", @"999999994")]
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
