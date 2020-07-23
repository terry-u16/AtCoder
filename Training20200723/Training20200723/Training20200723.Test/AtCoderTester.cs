using System;
using Xunit;
using Training20200723.Questions;
using System.Collections.Generic;
using System.Linq;
using Training20200723.Collections;

namespace Training20200723.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 2 5
1 3
1 2 2
2 1 1", @"6")]
        [InlineData(@"2 2 3
1 3
1 2 2
2 1 1", @"3")]
        [InlineData(@"8 15 120
1 2 6 16 1 3 11 9
1 8 1
7 3 14
8 2 13
3 5 4
5 7 5
6 4 1
6 8 17
7 8 5
1 4 2
4 7 1
6 1 3
3 1 10
2 6 5
2 4 12
5 1 30", @"1488")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
2 5 3 4 1", @"0
1
1
2
2")]
        [InlineData(@"1
1000000", @"0")]
        [InlineData(@"8
66 52 56 32 27 50 72 23", @"0
1
2
2
3
4
3
1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 4
5
2 3 1 2 6 5", @"3")]
        [InlineData(@"4 1
100000000000000000000
2 3 4 1", @"1")]
        [InlineData(@"8 1
1
2 3 4 5 3 2 4 5", @"2")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
2 1
2 3", @"2")]
        [InlineData(@"5 5
1 2
2 3
3 5
1 4
4 5", @"3")]
        [InlineData(@"16 1
1 2", @"10461394944000")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 3
1 2 1
2 3 1
3 4 10
2
3 4 1
1 4 1", @"10
8")]
        [InlineData(@"8 16
8 7 38
2 8 142
5 2 722
8 6 779
4 6 820
1 3 316
1 7 417
8 3 41
1 4 801
3 2 126
4 2 71
8 4 738
4 3 336
7 5 717
5 6 316
2 1 501
10
6 1 950
6 1 493
1 6 308
3 4 298
2 5 518
1 5 402
4 7 625
7 6 124
3 8 166
2 4 708", @"13649
12878
11954
11954
11280
11058
11058
8099
8099
8099")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 6
1 3 30
2 3 40
3 6 25
6 6 10", @"80")]
        [InlineData(@"2 7
1 3 90
5 7 90", @"180")]
        [InlineData(@"1 4
1 4 70", @"0")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1 11
1 29
1 89
2 2
2 2", @"29
89")]
        [InlineData(@"12
1 8932
1 183450
1 34323
1 81486
1 127874
1 114850
1 55277
1 112706
2 3
1 39456
1 52403
2 4", @"55277
52403")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1
2
3", @"0
1
2")]
        [InlineData(@"5
1
2
3
2
1", @"0
1
4
1
0")]
        [InlineData(@"5
3
2
1
2
3", @"4
2
0
2
4")]
        [InlineData(@"8
4
3
2
3
4
3
2
1", @"7
2
0
2
7
2
1
0")]
        public void QuestionHTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionH();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4
1 2 4
3 6 10 15", @"0 1 2 0")]
        [InlineData(@"3 3
3 2 1
30 20 10", @"-1")]
        public void QuestionITest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionI();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 5
3 4", @"2")]
        [InlineData(@"10 20
2 2", @"10")]
        [InlineData(@"1 1
2 2", @"0")]
        [InlineData(@"10000000000 10000000000
4 3", @"4545454545")]
        public void QuestionJTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionJ();

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
