using System;
using Xunit;
using Kujikatsu008.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu008.Collections;

namespace Kujikatsu008.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 1 4", @"3")]
        [InlineData(@"3 3 33", @"2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 5", @"9")]
        [InlineData(@"2
3", @"6")]
        [InlineData(@"6
0 153 10 10 23", @"53")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"aca
accc
ca", @"A")]
        [InlineData(@"abcb
aacb
bccc", @"C")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
2 3 3 1 3 1", @"3")]
        [InlineData(@"6
5 2 4 2 8 8", @"0")]
        [InlineData(@"32
3 1 4 1 5 9 2 6 5 3 5 8 9 7 9 3 2 3 8 4 6 2 6 4 3 3 8 3 2 7 9 5", @"22")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
11 1 2 4 8
11 1 2 2 8
32 10 8 5 4
29384293847243 454353412 332423423 934923490 1
900000000000000000 332423423 454353412 934923490 987654321", @"20
19
26
3821859835
23441258666")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1
100
30", @"2100.000000000000000")]
        [InlineData(@"2
60 50
34 38", @"2632.000000000000000")]
        [InlineData(@"3
12 14 2
6 2 7", @"76.000000000000000")]
        [InlineData(@"1
9
10", @"20.250000000000000000")]
        [InlineData(@"10
64 55 27 35 76 119 7 18 49 100
29 19 31 39 27 48 41 87 55 70", @"20291.000000000000")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            AssertNearlyEqual(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
0 2 1
1 2 3", @"1 3")]
        [InlineData(@"5
0 0 0 0 0
2 2 2 2 2", @"0 2
1 2
2 2
3 2
4 2")]
        [InlineData(@"6
0 1 3 7 6 4
1 5 4 6 2 3", @"2 2
5 5")]
        [InlineData(@"2
1 2
0 0", @"")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

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
