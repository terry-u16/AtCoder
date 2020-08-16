using System;
using Xunit;
using Training20200727.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20200727.Collections;

namespace Training20200727.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 4
2 3", @"First")]
        [InlineData(@"2 5
2 3", @"Second")]
        [InlineData(@"2 7
2 3", @"First")]
        [InlineData(@"3 20
1 2 3", @"Second")]
        [InlineData(@"3 21
1 2 3", @"First")]
        [InlineData(@"1 100000
1", @"Second")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
10 80 90 30", @"10")]
        [InlineData(@"3
10 100 10", @"-80")]
        [InlineData(@"1
10", @"10")]
        [InlineData(@"10
1000000000 1 1000000000 1 1000000000 1 1000000000 1 1000000000 1", @"4999999995")]
        [InlineData(@"6
4 2 9 7 1 5", @"2")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
1 2 3", @"5")]
        [InlineData(@"1 10
9", @"0")]
        [InlineData(@"2 0
0 0", @"1")]
        [InlineData(@"4 100000
100000 100000 100000 100000", @"665683269")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
10 20 30 40", @"190")]
        [InlineData(@"5
10 10 10 10 10", @"120")]
        [InlineData(@"3
1000000000 1000000000 1000000000", @"5000000000")]
        [InlineData(@"6
7 6 8 6 1 1", @"68")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
0 1 1
1 0 1
1 1 1", @"3")]
        [InlineData(@"4
0 1 0 0
0 0 0 1
1 0 0 0
0 0 1 0", @"1")]
        [InlineData(@"1
0", @"0")]
        [InlineData(@"21
0 0 0 0 0 0 0 1 1 0 1 1 1 1 0 0 0 1 0 0 1
1 1 1 0 0 1 0 0 0 1 0 0 0 0 1 1 1 0 1 1 0
0 0 1 1 1 1 0 1 1 0 0 1 0 0 1 1 0 0 0 1 1
0 1 1 0 1 1 0 1 0 1 0 0 1 0 0 0 0 0 1 1 0
1 1 0 0 1 0 1 0 0 1 1 1 1 0 0 0 0 0 0 0 0
0 1 1 0 1 1 1 0 1 1 1 0 0 0 1 1 1 1 0 0 1
0 1 0 0 0 1 0 1 0 0 0 1 1 1 0 0 1 1 0 1 0
0 0 0 0 1 1 0 0 1 1 0 0 0 0 0 1 1 1 1 1 1
0 0 1 0 0 1 0 0 1 0 1 1 0 0 1 0 1 0 1 1 1
0 0 0 0 1 1 0 0 1 1 1 0 0 0 0 1 1 0 0 0 1
0 1 1 0 1 1 0 0 1 1 0 0 0 1 1 1 1 0 1 1 0
0 0 1 0 0 1 1 1 1 0 1 1 0 1 1 1 0 0 0 0 1
0 1 1 0 0 1 1 1 1 0 0 0 1 0 1 1 0 1 0 1 1
1 1 1 1 1 0 0 0 0 1 0 0 1 1 0 1 1 1 0 0 1
0 0 0 1 1 0 1 1 1 1 0 0 0 0 0 0 1 1 1 1 1
1 0 1 1 0 1 0 1 0 0 1 0 0 1 1 0 1 0 1 1 0
0 0 1 1 0 0 1 1 0 0 1 1 0 0 1 1 1 1 0 0 1
0 0 0 1 0 0 1 1 0 1 0 1 0 1 1 0 0 1 1 0 1
0 0 0 0 1 1 1 0 1 0 1 1 1 0 1 1 0 0 1 1 0
1 1 0 1 1 0 0 1 1 0 1 1 0 1 1 1 1 1 0 1 0
1 0 0 1 1 0 1 1 1 1 1 0 1 0 1 1 0 0 0 0 0", @"102515160")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2
2 3", @"5")]
        [InlineData(@"4
1 2
1 3
1 4", @"9")]
        [InlineData(@"1", @"2")]
        [InlineData(@"10
8 5
10 8
6 5
1 5
4 8
2 10
3 6
9 2
1 7", @"157")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
3 1 4 2
10 20 30 40", @"60")]
        [InlineData(@"1
1
10", @"10")]
        [InlineData(@"5
1 2 3 4 5
1000000000 1000000000 1000000000 1000000000 1000000000", @"5000000000")]
        [InlineData(@"9
4 2 5 8 3 6 1 7 9
6 8 8 4 6 3 5 7 5", @"31")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2
0 1 0 0
0 0 1 1
0 0 0 1
1 0 0 0", @"6")]
        [InlineData(@"3 3
0 1 0
1 0 1
0 0 0", @"3")]
        [InlineData(@"6 2
0 0 0 0 0 0
0 0 1 0 0 0
0 0 0 0 0 0
0 0 0 0 1 0
0 0 0 0 0 1
0 0 0 0 0 0", @"1")]
        [InlineData(@"1 1
0", @"0")]
        [InlineData(@"10 1000000000000000000
0 0 1 1 0 0 0 1 1 0
0 0 0 0 0 1 1 1 0 0
0 1 0 0 0 1 0 1 0 1
1 1 1 0 1 1 0 1 1 0
0 1 1 1 0 1 0 1 1 1
0 0 0 1 0 0 1 0 1 0
0 0 0 1 1 0 0 1 0 1
1 0 0 0 1 0 1 0 0 0
0 0 0 0 0 1 0 0 0 0
1 0 1 1 1 0 1 1 1 0", @"957538352")]
        public void QuestionHTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionH();

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
