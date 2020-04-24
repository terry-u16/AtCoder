using System;
using Xunit;
using Yorukatsu024.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu024.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4", @"0.5000000000")]
        [InlineData(@"5", @"0.6000000000")]
        [InlineData(@"1", @"1.0000000000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            foreach (var pair in outputs.Zip(answers, (exp, act) => new { exp, act }))
            {
                NearlyEquals(double.Parse(pair.exp), double.Parse(pair.act));
            }
        }

        [Theory]
        [InlineData(@"5 3
10
15
11
14
12", @"2")]
        [InlineData(@"5 3
5
7
5
7
7", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1 1 2 1 2", @"2
2
3
2
3")]
        [InlineData(@"4
1 2 3 4", @"0
0
0
0")]
        [InlineData(@"5
3 3 3 3 3", @"6
6
6
6
6")]
        [InlineData(@"8
1 2 1 4 2 1 4 1", @"5
7
5
7
7
5
7
5")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
-30 -10 10 20 50", @"40")]
        [InlineData(@"3 2
10 20 30", @"20")]
        [InlineData(@"1 1
0", @"0")]
        [InlineData(@"8 5
-9 -7 -4 -3 1 2 3 4", @"10")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
3 1 4
1 5 9
2 6 5
3 5 8
9 7 9", @"56")]
        [InlineData(@"5 3
1 -2 3
-4 5 -6
7 -8 -9
-10 11 -12
13 -14 15", @"54")]
        [InlineData(@"10 5
10 -80 21
23 8 38
-94 28 11
-26 -2 18
-69 72 79
-26 -86 -54
-72 -50 59
21 65 -32
40 -94 87
-62 18 82", @"638")]
        [InlineData(@"3 2
2000000000 -9000000000 4000000000
7000000000 -5000000000 3000000000
6000000000 -1000000000 8000000000", @"30000000000")]
        [InlineData(@"5 0
3 1 4
1 5 9
2 6 5
3 5 8
9 7 9", @"0")]

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

        void NearlyEquals(double expected, double actual, double error = 1e-6) => Assert.InRange(Math.Abs(actual - expected), 0, error);

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
