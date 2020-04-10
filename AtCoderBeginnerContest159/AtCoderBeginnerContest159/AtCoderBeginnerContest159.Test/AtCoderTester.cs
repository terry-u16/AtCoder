using System;
using Xunit;
using AtCoderBeginnerContest159.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest159.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 1", @"1")]
        [InlineData(@"4 3", @"9")]
        [InlineData(@"1 1", @"0")]
        [InlineData(@"13 3", @"81")]
        [InlineData(@"0 3", @"3")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"akasaka", @"Yes")]
        [InlineData(@"level", @"No")]
        [InlineData(@"atcoder", @"No")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3", 1.000000000000)]
        [InlineData(@"999", 36926037.000000000000)]
        public void QuestionCTest(string input, double output)
        {
            IAtCoderQuestion question = new QuestionC();

            var answer = question.Solve(input).Cast<double>().First();

            Assert.True(Math.Abs(output - answer) < 1.0e-6);
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
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5 4
11100
10001
00111", @"2")]
        [InlineData(@"3 5 8
11100
10001
00111", @"0")]
        [InlineData(@"4 10 4
1110010010
1000101110
0011101001
1101000111", @"3")]
        [InlineData(@"4 4 1
1111
1111
1111
1111", @"6")]
        [InlineData(@"4 4 4
1111
1111
1111
1111", @"2")]

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

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
