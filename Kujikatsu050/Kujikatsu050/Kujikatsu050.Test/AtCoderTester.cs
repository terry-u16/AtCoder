using System;
using Xunit;
using Kujikatsu050.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu050.Collections;

namespace Kujikatsu050.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"AtCoder Beginner Contest", @"ABC")]
        [InlineData(@"AtCoder Snuke Contest", @"ASC")]
        [InlineData(@"AtCoder X Contest", @"AXC")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 1
5 4 2 1", @"Yes")]
        [InlineData(@"3 2
380 19 1", @"No")]
        [InlineData(@"12 3
4 56 78 901 2 345 67 890 123 45 6 789", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
cbaa
daacc
acacac", @"aac")]
        [InlineData(@"3
a
aa
b", @"")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
01
10", @"2")]
        [InlineData(@"3
011
101
110", @"-1")]
        [InlineData(@"6
010110
101001
010100
101000
100000
010000", @"4")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 3
1 3 2
2 4 3
1 4 6", @"5")]
        [InlineData(@"4 2
1 2 1
3 4 2", @"-1")]
        [InlineData(@"10 7
1 5 18
3 4 8
1 3 5
4 7 10
5 9 8
6 10 5
8 10 3", @"28")]
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
